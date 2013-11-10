using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfClientWithInspector
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new ServiceReference1.MyServiceClient();
            var res = client.echoString("Mahmoud");
            Console.WriteLine(res);
            Console.ReadLine();
        }
    }
}
