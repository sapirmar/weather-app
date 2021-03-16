using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using weather_service.Models;

namespace weather_service.Models.DAOs
{
    public interface IWeatherDBContext
    {
        DbSet<WeatherDetails> WeatherDetails { get; set; }
    }
}
