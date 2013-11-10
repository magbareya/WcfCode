using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using WcfServie;

namespace Host
{
    class Program
    {
        static void Main(string[] args)
        {
            using(var host = new ServiceHost(typeof(HelloWorld)))
            {
                //host.AddServiceEndpoint(typeof(IHelloWorld), new WSHttpBinding(), "http://localhost:8000/samples");
                host.Open();
                Console.ReadLine();
            }
        }
    }
}
