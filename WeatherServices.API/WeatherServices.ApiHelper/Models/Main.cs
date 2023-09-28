using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherServices.ApiHelper.Models
{
    public class Main
    {
        public decimal Temp { get; set; }
        public decimal Feels_Like { get; set; }
        public decimal Temp_Min { get; set; }
        public decimal Temp_Max { get; set; }
        public int Pressure { get; set; }
        public int Humidity { get; set; }
        public int Sea_Level { get; set; }
        public int Grnd_Level { get; set; }
    }
}
