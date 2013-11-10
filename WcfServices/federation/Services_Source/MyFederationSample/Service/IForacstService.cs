using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace WeatherChannel
{
    [ServiceContract]
    interface IForacstService
    {
        [OperationContract]
        WeatherResult GetWeather(string city); 
    }

    [DataContract]
    public class WeatherResult
    {
        [DataMember]
        public int Temperature { get; set; }
        [DataMember]
        public String Forcast { get; set; }
    }

}
