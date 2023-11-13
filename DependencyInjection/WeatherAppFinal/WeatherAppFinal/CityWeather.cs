using System;

namespace WeatherAppFinal.Models
{
    public class CityWeather     //model class
    {
        public string CityUniqueCode { get; set; } = "";
        public string CityName { get; set; } = "";
        public DateTime DateAndTime { get; set; }
        public int TemperatureFahrenheit { get; set; }
    }
}
