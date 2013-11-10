using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Description;
using System.Text;

namespace WCFBinding
{
    public class MyClientCredentials : ClientCredentials
    {
        public MyClientCredentials()
        {
        }

        public MyClientCredentials(ClientCredentials other)
            : base(other)
        {
        }
    }
}
