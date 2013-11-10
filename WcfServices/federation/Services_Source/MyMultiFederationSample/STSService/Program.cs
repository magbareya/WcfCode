using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;

namespace STS
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost host = new ServiceHost(typeof(SecurityTokenService));
            host.Open();

            try
            {
                foreach (ChannelDispatcher cd in host.ChannelDispatchers)
                    foreach (EndpointDispatcher ed in cd.Endpoints)
                        Console.WriteLine("Service listening at {0}", ed.EndpointAddress.Uri);

                Console.WriteLine("\nPress enter to exit...\n");
                Console.ReadLine();
            }
            finally
            {
                host.Close();
            }
        }
    }
}
