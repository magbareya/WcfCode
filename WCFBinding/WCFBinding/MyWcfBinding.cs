using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.ServiceModel.Description;

namespace WCFBinding
{

    public class MyWcfBinding : Binding
    {
        public MyWcfBinding()
        {
        }

        public MyWcfBinding(string name, string ns) : base(name, ns)
        {
        }

        public override BindingElementCollection CreateBindingElements()
        {
            BindingElementCollection myCollection = new BindingElementCollection();
            myCollection.Add(new MyEncodingElement(this.MessageVersion, Encoding.UTF8));
            myCollection.Add(new MyTrasnportBindingElement());

            return myCollection;
        }

        public override string Scheme
        {
            get { return "http"; }
        }

        public new MessageVersion MessageVersion
        {
            get { return MessageVersion.CreateVersion(EnvelopeVersion.Soap11, AddressingVersion.None); }
        }
    }

}
