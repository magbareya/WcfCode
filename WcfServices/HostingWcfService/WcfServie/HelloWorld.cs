using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServie
{
    // NOTE: If you change the class name "HelloWorld" here, you must also update the reference to "HelloWorld" in App.config.
    public class HelloWorld : IHelloWorld
    {
        public string echoString(string s)
        {
            return string.Format("Message recieved at {0}: {1}", DateTime.Now, s);
        }
    }
}
