﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using ClassLibrary1;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            using(var host = new ServiceHost(typeof(Service1)))
            {
                host.Open();

                Console.ReadLine();
            }
        }
    }
}
