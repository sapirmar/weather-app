using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace weather_service.Models
{
    public class SummeraizedResponse
    {
        public TemperatureDetails Max { get; set; }
        public TemperatureDetails Avg { get; set; }
        public TemperatureDetails Min { get; set; }

        public SummeraizedResponse() { }
        public SummeraizedResponse(TemperatureDetails max, TemperatureDetails min, TemperatureDetails avg) {
            this.Max = max;
            this.Min = min;
            this.Avg = avg;
        }
    }
}
