using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace weather_service.Models
{

    [Table("weather_details")]
    public class WeatherDetails
    {
        //[Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonIgnore]
        public int ID { get; set; }
        [Required]
        public double Precipitation { get; set; }
        [Required]
        public double Temperature { get; set; }
        [Required]
        public double Latitude { get; set; }
        [Required]
        public double Longitude { get; set; }
        [Required]
        public DateTime ForecastTime { get; set; }


    }
}