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
            return new WeatherResult() { Forcast = "Cloudy", Temperature = 25 };
        }
    }
}
