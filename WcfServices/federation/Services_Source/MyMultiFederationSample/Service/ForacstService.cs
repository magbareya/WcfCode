using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeatherChannel 
{
    class ForacstService : IForacstService
    {
        public WeatherResult GetWeather(string city)
        {
            Console.Write(String.Format("getting weather for city {0}", city));
            return new WeatherResult() { Forcast = "Cloudy", Temperature = 25 };
        }
    }
}
