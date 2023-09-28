using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherServices.ApiHelper.Response;
using WeatherServices.Service.Request;
using WeatherServices.Service.Response;

namespace WeatherServices.Service.WeatherDetail
{
    public interface IWeatherDetailService
    {
        Task<GetCurrentWeatherDataResponse> GetCurrentWeather(GetCurrentWeatherRequest request);
        Task<GetLocationsResponse> GetLocations();


    }
}
