using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherServices.ApiHelper.Models;

namespace WeatherServices.ApiHelper.Response
{
    public class GetCurrentWeatherDataResponse
    {
        public decimal Lat { get; set; }
        public decimal Lon { get; set; }
        public decimal Temp { get; set; }
        public decimal FeelsLike { get; set; }
        public decimal TempMin { get; set; }
        public decimal TempMax { get; set; }
        public int Pressure { get; set; }
        public int Humidity { get; set; }
        public int SeaLevel { get; set; }
        public int GrndLevel { get; set; }
        public decimal WindSpeed { get; set; }
        public int WindDegree { get; set; }
        public ErrorModel Error { get; set; }

    }
}
