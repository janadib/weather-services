using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherServices.ApiHelper.Models;
using WeatherServices.Service.Request;
using WeatherServices.Service.Response;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using WeatherServices.ApiHelper.Response;
using GoogleMaps.LocationServices;

namespace WeatherServices.ApiHelper
{
    public class WeatherApiCaller : IWeatherApiCaller
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public WeatherApiCaller(HttpClient client, IConfiguration configuration)
        {
            _httpClient = client;   
            _configuration = configuration; 
        }

        public async Task<GetCurrentWeatherResponse> GetCurrentWeather(GetCurrentWeatherRequest request)
        {
            var apiKey = this._configuration["weatherApiKey"];
            StringBuilder filter = new StringBuilder();
                if (request != null)
                {
                    filter.Append("?");
                    if (request.Latitude != null)
                    {
                        filter.Append("lat=");
                        filter.Append(request.Latitude);
                        filter.Append("&");
                    }
                    if (request.Longitude != null)
                    {
                        filter.Append("lon=");
                        filter.Append(request.Longitude);
                        filter.Append("&");
                    }
                if (request.Latitude != null)
                {
                    filter.Append("appid=");
                    filter.Append(apiKey);
                }
            }

                HttpResponseMessage response = await _httpClient.GetAsync("weather" + filter.ToString());
                GetCurrentWeatherResponse weatherResponse = new();
                string data = response.Content.ReadAsStringAsync().Result;

                if (response.IsSuccessStatusCode)
                {
                     weatherResponse.CurrentWeather = JsonConvert.DeserializeObject<CurrentWeather>(data);
                }
                else
                {
                    weatherResponse.Error = JsonConvert.DeserializeObject<ErrorModel>(data);
                }

            return weatherResponse;
        }

        public async Task<GetLocationsResponse> GetLocations()
        {

            GetLocationsResponse response = new();
            response.Locations = new List<Location>();     

            response.Locations.Add(new Location() { LocationName = "Kandy", Latitude = 7.332556459846664, Longitude = 80.65292537187234 });
            response.Locations.Add(new Location() { LocationName = "Colombo", Latitude = 6.92728663127729,  Longitude = 79.86169553171815 });
            response.Locations.Add(new Location() { LocationName = "Dehiwala", Latitude = 6.831130599942518 , Longitude = 79.88186331145236 });
            response.Locations.Add(new Location() { LocationName = "Negombo", Latitude = 7.200014050183392, Longitude =  79.86146035254312 });
            response.Locations.Add(new Location() { LocationName = "Galle", Latitude = 6.084569507192347, Longitude = 80.23405334966738 });
            response.Locations.Add(new Location() { LocationName = "NuwaraEliya", Latitude = 6.951248171728731,  Longitude = 80.79042530447137 });

            if (response.Locations.Count <= 0)
            {
                response.Error = new ErrorModel()
                {
                    Error = "No Locations Found",
                    ErrorCode = "A001"
                };
            }

            return response;
        }
    }
}
  

