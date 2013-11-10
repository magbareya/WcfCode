using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;

namespace WCFBinding
{
    public class MyTrasnportBindingElement : HttpTransportBindingElement
    {
        public MyTrasnportBindingElement()
        {
        }

        public MyTrasnportBindingElement(HttpTransportBindingElement other) : base(other)
        {
        }
    }
}
