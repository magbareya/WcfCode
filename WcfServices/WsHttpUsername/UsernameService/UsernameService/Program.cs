using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Reflection;

namespace UsernameService
{
    class Program
    {
        static void Main(string[] args)
        {
            //var t = typeof(UsernameValidator);
            //Console.WriteLine(t.);
            //Console.WriteLine(Assembly.GetAssembly(typeof(Program)));
            //Console.ReadLine();
            using (var host = new ServiceHost(typeof(UsernamePasswordService)))
            {
                host.Open();
                Console.WriteLine(host.BaseAddresses[0]);
                Console.ReadLine();
                host.Close();
            }
        }
    }
}
