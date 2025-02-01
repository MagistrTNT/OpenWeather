using System.Text.Json.Serialization;

namespace AmberCastle.API.OpenWeather.Models
{
    public class WeatherLocation : Coord
    {
        /// <summary>
        /// Название найденного места
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Название найденного местоположения на разных языках. Тем Список имен может быть разным для разных локаций.
        /// </summary>
        [JsonPropertyName("local_names")]
        public Dictionary<string, string> LocalNames { get; set; }

        /// <summary>
        /// Страна найденного местонахождения
        /// </summary>
        [JsonPropertyName("country")]
        public string Country { get; set; }

        /// <summary>
        ///  Состояние найденного местоположения
        /// </summary>
        [JsonPropertyName("state")]
        public string State { get; set; }
    }
}
