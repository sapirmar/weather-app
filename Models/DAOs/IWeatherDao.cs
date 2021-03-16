using System.Collections.Generic;

namespace weather_service.Models.DAOs
{
    public interface IWeatherDao
    {
        void Insert(WeatherDetails weatherEntity);
        List<WeatherDetails> GetDataByLocation(double lat, double lon);

        int Count();
    }
}
