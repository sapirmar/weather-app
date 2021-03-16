using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using weather_service.Models;
using weather_service.Models.DAOs;

namespace weather_service.Controllers
{
    [ApiController]
    [Route("weather")]
    public class WeatherController : ControllerBase
    {
        private readonly WeatherContext weatherContext;
        private readonly ILogger<WeatherController> _logger;
        public WeatherController(WeatherContext weatherContext, ILogger<WeatherController> logger)
        {
            this.weatherContext = weatherContext;
            this._logger = logger;

        }

        [HttpGet]
        [Route("HealthCheck")]
        public string Get()
        {


          int res = weatherContext.Count();
            //WeatherDetails details= weatherContext.WeatherDetails.First(entity => entity.ID == 1);
            return "Alive, number of columns:" + res;
        }

        [HttpGet]
        [Route("data")]
        public IEnumerable<WeatherDetails> GetData(double lat, double lon)
        {
            IEnumerable<WeatherDetails> result = weatherContext.WeatherDetails.Where(entity => entity.Latitude == lat && entity.Longitude == lon);
            return result;
        }

        [HttpGet]
        [Route("summarize")]
        public SummeraizedResponse GetSummarize(double lat, double lon)
        {
            
            TemperatureDetails max = new TemperatureDetails();
            TemperatureDetails min = new TemperatureDetails();
            TemperatureDetails avg = new TemperatureDetails();

            SummeraizedResponse summeraizedResponse =new SummeraizedResponse(max, min, avg);
            int result=weatherContext.WeatherDetails.Where(entity => entity.Latitude == lat && entity.Longitude == lon)
                .Count();
            if (result > 0)
            {
                var temperatureValues = weatherContext.WeatherDetails.Where(entity => entity.Latitude == lat && entity.Longitude == lon)
                        .GroupBy(entity => new { Latitude = entity.Latitude, Longitude = entity.Longitude })
                        .Select(entity => new
                        {
                            max = entity.Max(e => e.Temperature),
                            min = entity.Min(e => e.Temperature),
                            avg = entity.Average(e => e.Temperature)
                        });
                var precipitationValues = weatherContext.WeatherDetails.Where(entity => entity.Latitude == lat && entity.Longitude == lon)
                       .GroupBy(entity => entity.Precipitation)
                        .Select(entity => new
                        {
                            max = entity.Max(e => e.Precipitation),
                            min = entity.Min(e => e.Precipitation),
                            avg = entity.Average(e => e.Precipitation)
                        });

                if (temperatureValues != null)
                {
                    avg.Temperature = temperatureValues.Select(val => val.avg).FirstOrDefault();
                    max.Temperature = temperatureValues.Select(val => val.max).FirstOrDefault();
                    min.Temperature = temperatureValues.Select(val => val.min).FirstOrDefault();
                }

                if (precipitationValues != null)
                {
                    avg.Precipitation = precipitationValues.Select(val => val.avg).FirstOrDefault();
                    max.Precipitation = precipitationValues.Select(val => val.max).FirstOrDefault();
                    min.Precipitation = precipitationValues.Select(val => val.min).FirstOrDefault();
                }
                //todo handle null events

            }
            return summeraizedResponse;

        }


    }
}
