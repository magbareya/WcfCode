using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace WcfClientWithInspector
{
    public class MyBehaviorExtensionElement : BehaviorExtensionElement
    {
        public override Type BehaviorType
        {
            get { return typeof(EndpointBehavior); }
        }

        protected override object CreateBehavior()
        {
            return new EndpointBehavior();
        }
    }
}
