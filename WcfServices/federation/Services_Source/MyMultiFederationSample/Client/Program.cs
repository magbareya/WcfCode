﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeatherClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Getting weather for NY...");
            //var client = new WeatherServiceReference.ForacstServiceClient("WSHttpBinding_IForacstService");
            var client = new WeatherServiceReference.ForacstServiceClient("certificate");
            var res = client.GetWeather("NY");            
            Console.WriteLine(String.Format("Temperature: {0}\r\nForcast: {1}", res.Temperature, res.Forcast));
            Console.WriteLine("\nPress enter to exit...\n");
            Console.ReadLine();
        }
    }
}
