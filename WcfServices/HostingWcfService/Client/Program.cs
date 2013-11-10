using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace Client
{


    class Program
    {
        static void Main(string[] args)
        {
            //var service = ChannelFactory<IHelloWorld>.CreateChannel(new WSHttpBinding(), new EndpointAddress("http://localhost:8000/samples"));
            var service = new WcfServie.HelloWorld();
            var s= service.echoString("Mahmoud");

            Console.WriteLine(s);
            Console.ReadLine();
        }
    }
}
