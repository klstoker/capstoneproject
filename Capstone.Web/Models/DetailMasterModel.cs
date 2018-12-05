using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
    public class DetailMasterModel
    {
        public ParkModel MyPark { get; set; } = new ParkModel();
        public List<WeatherModel> FiveDayForecast { get; set; } = new List<WeatherModel>();
        public bool IsCelsius { get; set; }

        
    }
}
