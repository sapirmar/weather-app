//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Data.Entity;
//using WebApplication5.Services;
//
//namespace WebApplication5.Models.DAOs
//{
//    public class WeatherDBInitializer : DropCreateDatabaseIfModelChanges<WeatherContext>
//    {
//        protected override void Seed(WeatherContext context)
//        {
//            List<WeatherDetails> weatherEntities =
//               CsvReaderService.ReadFromCsv("C:\\Users\\sisso_000\\Desktop\\test\\test.csv");
//            weatherEntities.ForEach(entity => context.WeatherDetails.Add(entity)); 
//            base.Seed(context);
//        }
//    }
//}