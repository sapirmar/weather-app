//using System.Data.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
//using System.Data.Entity;
using System.IO;
using System.Linq;
using WebApplication5.Services;
namespace weather_service.Models.DAOs
{
    public class WeatherContext : DbContext,IWeatherDao
    {
        public DbSet<WeatherDetails> WeatherDetails { get; set; }

    
        public WeatherContext(DbContextOptions < WeatherContext > options):base(options) {
            bool res=Database.EnsureCreated();
            //table is new
            if (res)
            {
                //write rows from csv
                initTable();
            }
            
        }
        

        public void Insert(WeatherDetails weatherEntity)
        {

        }
        public List<WeatherDetails> GetDataByLocation(double lat, double lon)
        {
            return null;
        }

        public int Count()
        {
            return this.WeatherDetails.Count();
        }

        private void initTable()
        {
            if (this.WeatherDetails.Count() == 0)
            {
                String[] filePaths = Directory.GetFiles(@"./CSVFiles"); ;
                //List<WeatherDetails> csvRows = new List<WeatherDetails>();
                // Insert all data from csv files(from CSVFiles directory)
                foreach (String path in filePaths)
                {
                    List<List<WeatherDetails>> csvRows = CsvReaderService.ReadFromCsv(path);
                    foreach(List<WeatherDetails> batch in csvRows) {
                        this.WeatherDetails.AddRange(batch);
                        this.SaveChanges();
                    }
                }
             // if (csvRows.Count() > 0)
             // {
             //
             //     foreach (WeatherDetails row in csvRows)
             //     {
             //         this.WeatherDetails.Add(row);
             //        
             //     }
             //
             //
             // }
            }
        }

    }
}