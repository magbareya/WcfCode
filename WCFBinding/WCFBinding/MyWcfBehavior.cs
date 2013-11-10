using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Description;
using System.Text;

namespace WCFBinding
{
    public class MyWcfBehavior : ClientViaBehavior
    {
        public MyWcfBehavior(Uri uri): base(uri)
        {
        }
    }
}
