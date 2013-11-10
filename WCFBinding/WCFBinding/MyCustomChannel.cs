using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;

namespace WCFBinding
{
    public class MyCustomChannel : BindingElement
    {

        public MyCustomChannel()
        {
        }

        public MyCustomChannel(BindingElement other): base(other)
        {
        }

        public override BindingElement Clone()
        {
            throw new NotImplementedException();
        }

        public override T GetProperty<T>(BindingContext context)
        {
            throw new NotImplementedException();
        }
    }
}
