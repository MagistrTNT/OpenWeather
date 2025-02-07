using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmberCastle.API.OpenWeather.Models
{
    public class OpenWeatherConfig
    {
        public string ApiKey { get; init; } = default!;
        public Uri OpenWeatherUrl { get; init; } = new Uri("http://api.openweathermap.org");
        public string Units { get; init; } = "metric";
        public string Lang { get; init; } = "ru";
    }
}
