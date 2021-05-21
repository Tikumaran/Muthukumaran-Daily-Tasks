using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherWebAPIProject.Models
{
    public class Weather
    {
        [Key]
        public int Weather_ID { get; set; }
        public DateTime Weather_Date { get; set; }
        public string City { get; set; }
        public float HighTemp { get; set; }
        public float LowTemp { get; set; }
        public string forcast { get; set; }
    }
}
//date,City, highTemp, lowTemp, forcast