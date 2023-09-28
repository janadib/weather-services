using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherServices.ApiHelper.Models;

namespace WeatherServices.Service.Response
{
    public class GetCurrentWeatherResponse
    {
        public CurrentWeather CurrentWeather { get; set; }
        public ErrorModel Error { get; set; }

    }
}
