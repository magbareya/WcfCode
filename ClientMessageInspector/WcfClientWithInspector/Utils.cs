using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace WcfClientWithInspector
{
    class Utils
    {
        public static String GetMessageString(ref Message msg)
        {
            if (msg == null)
                return string.Empty;
            var buffer = msg.CreateBufferedCopy(Int32.MaxValue);
            var sb = GetMessageFromBuffer(buffer);
            msg = buffer.CreateMessage();
            buffer.Close();
            return sb.ToString();
        }

        private static StringBuilder GetMessageFromBuffer(MessageBuffer buffer)
        {
            Message temp = buffer.CreateMessage();
            var sb = new StringBuilder();
            var writer = XmlWriter.Create(sb);
            temp.WriteMessage(writer);
            writer.Close();
            return sb;
        }
    }
}
