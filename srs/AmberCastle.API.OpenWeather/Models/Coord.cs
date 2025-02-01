using System.Text.Json.Serialization;

namespace AmberCastle.API.OpenWeather.Models
{
    public class Coord
    {

        /// <summary>
        /// Географические координаты местоположения (широта)
        /// </summary>
        [JsonPropertyName("lat")]
        public double Latitude { get; set; }

        /// <summary>
        /// Географические координаты местоположения (долгота)
        /// </summary>
        [JsonPropertyName("lon")]
        public double Longitude { get; set; }
    }
}