using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using weather_service.Models;
using System.IO;

namespace WebApplication5.Services
{
    public class CsvReaderService
    {
        public static List<List<WeatherDetails>> ReadFromCsv(String filePath)
        {
            List<WeatherDetails> list= File.ReadAllLines(filePath)
                .Skip(1)
                .Select(line => FromCsv(line))
                .ToList();

            return Split<WeatherDetails>(list, 1000);
           
        }


        private static List<List<T>> Split<T>(List<T> collection, int size)
        {
            var chunks = new List<List<T>>();
            var chunkCount = collection.Count() / size;

            if (collection.Count % size > 0)
                chunkCount++;

            for (var i = 0; i < chunkCount; i++)
                chunks.Add(collection.Skip(i * size).Take(size).ToList());

            return chunks;
        }


        private static WeatherDetails FromCsv(String line)
        {
            String[] values = line.Split(',');
            WeatherDetails weatherEntity = new WeatherDetails();

            /*
             * Longitude,Latitude,forecast_time,Temperature Celsius,Precipitation Rate mm/hr
             */
            if (values == null || values.Length != 5)
            {
                //invalid number of arguments
                return null;
            }
            weatherEntity.Longitude = Convert.ToDouble(values[0]);
            weatherEntity.Latitude = Convert.ToDouble(values[1]);
            weatherEntity.ForecastTime = Convert.ToDateTime(values[2]);
            weatherEntity.Temperature = Convert.ToDouble(values[3]);
            weatherEntity.Precipitation = Convert.ToDouble(values[4]);
            return weatherEntity;
        }
    }
}