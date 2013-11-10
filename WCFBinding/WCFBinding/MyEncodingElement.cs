using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;

namespace WCFBinding
{
    public class MyEncodingElement : MessageEncodingBindingElement
    {
        private MessageEncodingBindingElement myEncoding;

        #region ctors
        public MyEncodingElement()
        {
            myEncoding = new TextMessageEncodingBindingElement();
        }

        public MyEncodingElement(MessageEncodingBindingElement other): base(other)
        {
            myEncoding = new TextMessageEncodingBindingElement();
        }

        public MyEncodingElement(MessageVersion version, Encoding encoding)
        {
            myEncoding = new TextMessageEncodingBindingElement(version, encoding);
        }
        #endregion
        
        public override MessageEncoderFactory CreateMessageEncoderFactory()
        {
            return this.myEncoding.CreateMessageEncoderFactory();
        }

        public override MessageVersion MessageVersion
        {
            get { return this.myEncoding.MessageVersion; }
            set { this.myEncoding.MessageVersion = value; }
        }

        public override BindingElement Clone()
        {
            return this.myEncoding.Clone();
        }
    }
}
