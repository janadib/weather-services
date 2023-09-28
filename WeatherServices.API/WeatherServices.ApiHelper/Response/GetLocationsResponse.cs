using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherServices.ApiHelper.Models;

namespace WeatherServices.ApiHelper.Response
{
    public class GetLocationsResponse
    {
        public List<Location> Locations { get; set; }

        public ErrorModel Error { get; set; }

    }
}
