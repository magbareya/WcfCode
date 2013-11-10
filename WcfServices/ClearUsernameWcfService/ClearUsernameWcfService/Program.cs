using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace ClearUsernameWcfService
{
    class Program
    {
        static void Main(string[] args)
        {
            using(var host = new ServiceHost(typeof(ClearUsernameService)))
            {
                host.Open();
                Console.WriteLine(host.BaseAddresses[0]);
                Console.ReadLine();
            }
        }
    }
}
