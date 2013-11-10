using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServie
{
    // NOTE: If you change the interface name "IHelloWorld" here, you must also update the reference to "IHelloWorld" in App.config.
    [ServiceContract(Namespace = "http://localhost:8000/samples")]
    public interface IHelloWorld
    {
        [OperationContract]
        string echoString(string s);
    }

    [DataContract]
    internal class A
    {
        public int I { get; private set; }

    }
}
