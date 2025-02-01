using System.Text.Json.Serialization;

namespace AmberCastle.API.OpenWeather.Models
{
    public class WeatherInfo
    {
        [JsonPropertyName("coord")]
        public Coord coord { get; set; }

        [JsonPropertyName("weather")]
        public Weather[] weather { get; set; }

        [JsonPropertyName("_base")]
        public string _base { get; set; }

        [JsonPropertyName("main")]
        public Main main { get; set; }

        [JsonPropertyName("visibility")]
        public int visibility { get; set; }

        [JsonPropertyName("wind")]
        public Wind wind { get; set; }

        [JsonPropertyName("clouds")]
        public Clouds clouds { get; set; }

        [JsonPropertyName("dt")]
        public int dt { get; set; }

        [JsonPropertyName("sys")]
        public Sys sys { get; set; }

        [JsonPropertyName("timezone")]
        public int timezone { get; set; }

        [JsonPropertyName("id")]
        public int id { get; set; }

        [JsonPropertyName("name")]
        public string name { get; set; }

        [JsonPropertyName("cod")]
        public int cod { get; set; }

    }

    public class Weather
    {
        /// <summary>
        ///  Идентификатор погодных условий
        /// </summary>
        [JsonPropertyName("id")]
        public int Id { get; set; }

        /// <summary>
        ///  Группа параметров погоды (Дождь, Снег, Облака и т.д.)
        /// </summary>
        [JsonPropertyName("main")]
        public string Main { get; set; }

        /// <summary>
        /// Погодные условия внутри группы.
        /// </summary>
        [JsonPropertyName("description")]
        public string description { get; set; }

        /// <summary>
        /// ID иконки погоды
        /// </summary>
        [JsonPropertyName("icon")]
        public string IconId { get; set; }
    }


    public class Main
    {
        [JsonPropertyName("temp")]
        public float Temp { get; set; }

        [JsonPropertyName("feels_like")]
        public float FeelsLike { get; set; }

        [JsonPropertyName("temp_min")]
        public float TempMin { get; set; }

        [JsonPropertyName("temp_max")]
        public float TempMax { get; set; }

        /// <summary>
        ///  Атмосферное давление на уровне моря по умолчанию, гПа
        /// </summary>
        [JsonPropertyName("pressure")]
        public int Pressure { get; set; }

        /// <summary>
        ///  Атмосферное давление на уровне моря, гПа
        /// </summary>
        [JsonPropertyName("sea_level")]
        public int SeaLevel { get; set; }

        /// <summary>
        ///  Атмосферное давление на уровне земли, гПа
        /// </summary>
        [JsonPropertyName("grnd_level")]
        public int GrndLevel { get; set; }

        [JsonPropertyName("humidity")]
        public int Humidity { get; set; }

        public float temp_kf { get; set; }
    }

    public class Wind
    {
        [JsonPropertyName("speed")]
        public float Speed { get; set; }

        /// <summary>
        ///  Направление ветра, градусы (метеорологическое)
        /// </summary>
        [JsonPropertyName("deg")]
        public int Deg { get; set; }

        /// <summary>
        ///  Порыв ветра. 
        /// </summary>
        [JsonPropertyName("gust")]
        public float Gust { get; set; }
    }

    public class Clouds
    {
        /// <summary>
        ///  Облачность, %
        /// </summary>
        [JsonPropertyName("all")]
        public int all { get; set; }
    }

    public class Sys
    {
        [JsonPropertyName("type")]
        public int type { get; set; }

        [JsonPropertyName("id")]
        public int id { get; set; }

        [JsonPropertyName("country")]
        public string country { get; set; }

        [JsonPropertyName("sunrise")]
        public int sunrise { get; set; }

        [JsonPropertyName("sunset")]
        public int sunset { get; set; }

        /// <summary>
        ///  Часть суток (n - ночь, d - день)
        /// </summary>
        [JsonPropertyName("pod")]
        public string Pod { get; set; }
    }

}