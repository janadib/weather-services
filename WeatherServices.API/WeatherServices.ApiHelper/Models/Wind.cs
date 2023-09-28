using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherServices.ApiHelper.Models
{
    public class Wind
    {
        public decimal Speed { get; set; }

        public int Deg { get; set; }

        public decimal Gust { get; set; }
    }
}
