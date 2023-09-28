using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherServices.ApiHelper;
using WeatherServices.ApiHelper.Models;
using WeatherServices.ApiHelper.Response;
using WeatherServices.Service.Request;
using WeatherServices.Service.Response;

namespace WeatherServices.Service.WeatherDetail
{
    public class WeatherDetailService : IWeatherDetailService
    {
        private readonly IWeatherApiCaller _weatherApiCaller;

        public WeatherDetailService(IWeatherApiCaller caller)
        {
            _weatherApiCaller = caller;
        }
        public async Task<GetCurrentWeatherDataResponse> GetCurrentWeather(GetCurrentWeatherRequest request)
        {
            try
            {
                var currentWeatherResponse = await _weatherApiCaller.GetCurrentWeather(request);
                GetCurrentWeatherDataResponse currentWeatherDataResponse = new();
                if (currentWeatherResponse != null)
                {
                    currentWeatherDataResponse.Lat = currentWeatherResponse.CurrentWeather.Coord.Lat;
                    currentWeatherDataResponse.Lon = currentWeatherResponse.CurrentWeather.Coord.Lon;
                    currentWeatherDataResponse.Temp = currentWeatherResponse.CurrentWeather.Main.Temp;
                    currentWeatherDataResponse.FeelsLike = currentWeatherResponse.CurrentWeather.Main.Feels_Like;
                    currentWeatherDataResponse.TempMin = currentWeatherResponse.CurrentWeather.Main.Temp_Min;
                    currentWeatherDataResponse.TempMax = currentWeatherResponse.CurrentWeather.Main.Temp_Max;
                    currentWeatherDataResponse.Pressure = currentWeatherResponse.CurrentWeather.Main.Pressure;
                    currentWeatherDataResponse.Humidity = currentWeatherResponse.CurrentWeather.Main.Humidity;
                    currentWeatherDataResponse.SeaLevel = currentWeatherResponse.CurrentWeather.Main.Sea_Level;
                    currentWeatherDataResponse.GrndLevel = currentWeatherResponse.CurrentWeather.Main.Grnd_Level;
                    currentWeatherDataResponse.WindSpeed = currentWeatherResponse.CurrentWeather.Wind.Speed;
                    currentWeatherDataResponse.WindDegree = currentWeatherResponse.CurrentWeather.Wind.Deg;

                }
                else
                {
                    currentWeatherDataResponse.Error = new ErrorModel()
                    {
                        Error = currentWeatherResponse.Error.Error,
                        ErrorCode = currentWeatherResponse.Error.ErrorCode
                    };
                }
                return currentWeatherDataResponse;  
            }
            catch(Exception ex)
            {
                throw new Exception($"Couldn't retrieve Current Weather Information: {ex.Message}");
            }
        }

        public async Task<GetLocationsResponse> GetLocations()
        {
            try
            {
                var locationsResponse = await _weatherApiCaller.GetLocations();
                return locationsResponse;
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve Information of locations: {ex.Message}");
            }
        }
    }
}
