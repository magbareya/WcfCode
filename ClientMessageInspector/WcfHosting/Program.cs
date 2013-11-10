using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WcfHosting
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var host = new ServiceHost(typeof (WcfService.MyService)))
            {
                //var url = @"http://localhost:8092/MyService";
                host.Open();
                Console.WriteLine("STARTED!!");
                Console.ReadLine();
            }
        }
    }
}
