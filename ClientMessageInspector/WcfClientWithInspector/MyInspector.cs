using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Threading.Tasks;

namespace WcfClientWithInspector
{
    public class MyInspector : IClientMessageInspector
    {
        public void AfterReceiveReply(ref Message reply, object correlationState)
        {
            File.WriteAllText(@"../../Reply.xml", Utils.GetMessageString(ref reply));
        }

        public object BeforeSendRequest(ref Message request, IClientChannel channel)
        {
            File.WriteAllText(@"../../Request.xml", Utils.GetMessageString(ref request));
            return null;
        }
    }
}
