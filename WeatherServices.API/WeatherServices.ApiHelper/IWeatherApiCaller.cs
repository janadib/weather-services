using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherServices.ApiHelper.Response;
using WeatherServices.Service.Request;
using WeatherServices.Service.Response;

namespace WeatherServices.ApiHelper
{
    public interface IWeatherApiCaller
    {
        Task<GetCurrentWeatherResponse> GetCurrentWeather(GetCurrentWeatherRequest request);
        Task<GetLocationsResponse> GetLocations();        
    }
}
