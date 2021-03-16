using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace weather_service.Models
{
    public class TemperatureDetails
    {
        public double? Temperature { get; set; }
        public double? Precipitation { get; set; }

        public TemperatureDetails()
        {

        }
        public TemperatureDetails(double temperature,double precipitaion)
        {
            this.Temperature = temperature;
            this.Precipitation = Precipitation;
        }
    }
}
