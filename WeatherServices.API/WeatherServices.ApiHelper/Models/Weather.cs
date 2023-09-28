using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherServices.ApiHelper.Models
{
    public class Weather
    {
        public int Id { get; set; } 
        public string Main { get; set; }
        public string Description { get; set; }
        public string icon { get; set; }
    }
}
