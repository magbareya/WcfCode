using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Channels;

namespace Microsoft.ServiceModel.Samples.CustomToken
{
    class MyBinding : Binding
    {
        private readonly Binding binding;

        public MyBinding()
        {
            var httpTransport = new HttpTransportBindingElement();

            var sec = (AsymmetricSecurityBindingElement)SecurityBindingElement.CreateMutualCertificateBindingElement(MessageSecurityVersion.WSSecurity10WSTrust13WSSecureConversation13WSSecurityPolicy12BasicSecurityProfile10);
            sec.EndpointSupportingTokenParameters.Signed.Add(new UsernameTokenParameters());
            sec.MessageSecurityVersion =
                MessageSecurityVersion.
                    WSSecurity10WSTrust13WSSecureConversation13WSSecurityPolicy12BasicSecurityProfile10;
            sec.IncludeTimestamp = true;
            sec.MessageProtectionOrder = System.ServiceModel.Security.MessageProtectionOrder.EncryptBeforeSign;
            

            var me = new TextMessageEncodingBindingElement(MessageVersion.Soap11WSAddressing10, Encoding.UTF8);

            this.binding = new CustomBinding(sec, me, httpTransport);
        }

        public override BindingElementCollection CreateBindingElements()
        {
            return this.binding.CreateBindingElements();
        }

        public override string Scheme
        {
            get { return this.binding.Scheme; }
        }
    }
}
