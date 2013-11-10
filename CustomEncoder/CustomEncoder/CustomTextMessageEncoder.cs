
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.

using System;
using System.IO;
using System.Xml;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Collections.Generic;

namespace CustomEncoder
{
    public class CustomTextMessageEncoder : MessageEncoder
    {
        private CustomTextMessageEncoderFactory factory;
        private XmlWriterSettings writerSettings;
        private string contentType;
        
        public CustomTextMessageEncoder(CustomTextMessageEncoderFactory factory)
        {
            this.factory = factory;
            
            this.writerSettings = new XmlWriterSettings();
            this.writerSettings.Encoding = Encoding.GetEncoding(factory.CharSet);
            this.contentType = string.Format("{0}; charset={1}", 
                this.factory.MediaType, this.writerSettings.Encoding.HeaderName);
        }

        public override string ContentType
        {
            get
            {
                return this.contentType;
            }
        }

        public override string MediaType
        {
            get 
            {
                return factory.MediaType;
            }
        }

        public override bool IsContentTypeSupported(string contentType)
        {
            return base.IsContentTypeSupported(contentType) || 
                    contentType.Contains("utf-8");
        }

        public override MessageVersion MessageVersion
        {
            get 
            {
                return this.factory.MessageVersion;
            }
        }

        public override Message ReadMessage(ArraySegment<byte> buffer, BufferManager bufferManager, string contentType)
        {
            byte[] msgContents = new byte[buffer.Count];
            Array.Copy(buffer.Array, buffer.Offset, msgContents, 0, msgContents.Length);
            bufferManager.ReturnBuffer(buffer.Array);

            var doc = new XmlDocument();
            doc.LoadXml(Encoding.UTF8.GetString(msgContents));
            ProcessResponse(ref doc);

            var stream = new MemoryStream(Encoding.UTF8.GetBytes(doc.OuterXml));
            return ReadMessage(stream, int.MaxValue, contentType);
        }

        private void ProcessResponse(ref XmlDocument doc)
        {
            var header = doc.SelectSingleNode("/*[local-name(.)='Envelope']/*[local-name(.)='Header']");
            if (header == null)
                return;

            foreach(XmlNode h in header.ChildNodes)
            {
                if (h.Attributes == null)
                    continue;
                if (h.Attributes[mustUnderstand, EnvelopeNS] != null)
                    h.Attributes.RemoveNamedItem(mustUnderstand, EnvelopeNS);
            }
        }

        public override Message ReadMessage(Stream stream, int maxSizeOfHeaders, string contentType)
        {
            XmlReader reader = XmlReader.Create(stream);
            return Message.CreateMessage(reader, maxSizeOfHeaders, this.MessageVersion);
        }

        public override ArraySegment<byte> WriteMessage(Message message, int maxMessageSize, BufferManager bufferManager, int messageOffset)
        {
            MemoryStream stream = new MemoryStream();
            XmlWriter writer = XmlWriter.Create(stream, this.writerSettings);
            message.WriteMessage(writer);
            writer.Close();
            stream.Position = 0;
            var doc = new XmlDocument();
            doc.Load(stream);
            stream.Close();

            ProcessRequest(ref doc);

            var b = Encoding.UTF8.GetBytes(doc.OuterXml);
            int messageLength = b.Length;
            int totalLength = messageLength + messageOffset;

            var buffer = bufferManager.TakeBuffer(totalLength);
            Array.Copy(b, 0, buffer, messageOffset, messageLength);

            var arr = new ArraySegment<byte>(buffer, messageOffset, messageLength);
            return arr;
        }

        public override void WriteMessage(Message message, Stream stream)
        {
            XmlWriter writer = XmlWriter.Create(stream, this.writerSettings);
            message.WriteMessage(writer);
            writer.Close();
        }

        #region Process Request
        void ProcessRequest(ref XmlDocument doc)
        {
            DeleteSignature(doc);
            HandleTimestamp(doc);
            HandleWSAHeaders(doc);
        }

        private void HandleWSAHeaders(XmlDocument doc)
        {
            var header = doc.SelectSingleNode("/*[local-name(.)='Envelope']/*[local-name(.)='Header']");
            if (header == null)
                return;

            var action =
                doc.SelectSingleNode("/*[local-name(.)='Envelope']/*[local-name(.)='Header']/*[local-name(.)='Action']");
            var to = doc.SelectSingleNode("/*[local-name(.)='Envelope']/*[local-name(.)='Header']/*[local-name(.)='To']");
            var messageId = doc.SelectSingleNode("/*[local-name(.)='Envelope']/*[local-name(.)='Header']/*[local-name(.)='MessageID']");
            var activityId = doc.SelectSingleNode("/*[local-name(.)='Envelope']/*[local-name(.)='Header']/*[local-name(.)='ActivityId']");
            var replyTo = doc.SelectSingleNode("/*[local-name(.)='Envelope']/*[local-name(.)='Header']/*[local-name(.)='ReplyTo']");

            if (activityId != null)
                header.RemoveChild(activityId);

            if (action != null)
            {
                var newAction = doc.CreateElement("Action", WSA43NS);
                if (!string.IsNullOrEmpty(action.InnerText))
                    newAction.AppendChild(doc.CreateTextNode(action.InnerText));
                else newAction.AppendChild(doc.CreateTextNode("http://services.cibc.com/SecurityTokenService/#RequestSecurityToken/Request/"));
                newAction.Attributes.Append(getMustUnderstand(doc));
                header.ReplaceChild(newAction, action);
            }

            if (replyTo != null)
            {
                var newReplyto = doc.CreateElement("ReplyTo", WSA43NS);
                var newAddress = doc.CreateElement("Address", WSA43NS);
                newAddress.AppendChild(doc.CreateTextNode("http://schemas.xmlsoap.org/ws/2004/03/addressing/role/anonymous"));
                newReplyto.AppendChild(newAddress);
                newReplyto.Attributes.Append(getMustUnderstand(doc));
                header.ReplaceChild(newReplyto, replyTo);
            }

            if (messageId != null)
            {
                var newMsgId = doc.CreateElement("MessageID", WSA43NS);
                newMsgId.AppendChild(doc.CreateTextNode(messageId.InnerText));
                newMsgId.Attributes.Append(getMustUnderstand(doc));
                header.ReplaceChild(newMsgId, messageId);
            }

            if (to != null)
            {
                var newTo = doc.CreateElement("To", WSA43NS);
                newTo.AppendChild(doc.CreateTextNode("http://services.cibc.com/SecurityTokenService/"));
                newTo.Attributes.Append(getMustUnderstand(doc));
                header.ReplaceChild(newTo, to);
            }

            var faultTo = doc.CreateElement("FaultTo", WSA43NS);
            var address = doc.CreateElement("Address", WSA43NS);
            address.AppendChild(doc.CreateTextNode("http://schemas.xmlsoap.org/ws/2004/03/addressing/role/anonymous"));
            faultTo.Attributes.Append(getMustUnderstand(doc));
            faultTo.AppendChild(address);
            header.AppendChild(faultTo);

            var from = doc.CreateElement("From", WSA43NS);
            var address2 = doc.CreateElement("Address", WSA43NS);
            address2.AppendChild(doc.CreateTextNode("http://emf.cibc.com/Desktop/Adapter/"));
            from.AppendChild(address2);
            from.Attributes.Append(getMustUnderstand(doc));
            header.AppendChild(from);

        }

        private XmlAttribute getMustUnderstand(XmlDocument doc)
        {
            var must = doc.CreateAttribute(mustUnderstand, EnvelopeNS);
            must.Value = "1";
            return must;
        }

        private void HandleTimestamp(XmlDocument doc)
        {
            var header = doc.SelectSingleNode("/*[local-name(.)='Envelope']/*[local-name(.)='Header']");

            var security =
                doc.SelectSingleNode(
                    "/*[local-name(.)='Envelope']/*[local-name(.)='Header']/*[local-name(.)='Security']");
            var timestamp =
                doc.SelectSingleNode(
                    "/*[local-name(.)='Envelope']/*[local-name(.)='Header']/*[local-name(.)='Security']/*[local-name(.)='Timestamp']");

            if (header == null || security == null || timestamp == null)
                return;

            security.RemoveChild(timestamp);
            var newTS = doc.CreateElement("Timestamp", TimestampNS);
            var created = doc.CreateElement("Created", TimestampNS);
            created.AppendChild(doc.CreateTextNode(timestamp.FirstChild.InnerText));
            newTS.AppendChild(created);
            header.AppendChild(newTS);
        }

        private void DeleteSignature(XmlDocument doc)
        {
            var security =
                doc.SelectSingleNode("/*[local-name(.)='Envelope']/*[local-name(.)='Header']/*[local-name(.)='Security']");
            var signature =
                doc.SelectSingleNode(
                    "/*[local-name(.)='Envelope']/*[local-name(.)='Header']/*[local-name(.)='Security']/*[local-name(.)='Signature']");
            if (security != null && signature != null)
                security.RemoveChild(signature);
        }

        #endregion

        #region consts
        const string TimestampNS = "http://schemas.xmlsoap.org/ws/2002/07/utility";

        const string WSA43NS = "http://schemas.xmlsoap.org/ws/2004/03/addressing";

        const string EnvelopeNS = "http://schemas.xmlsoap.org/soap/envelope/";

        const string mustUnderstand = "mustUnderstand";

        #endregion


    }
}
