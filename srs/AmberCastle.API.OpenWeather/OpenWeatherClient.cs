// Ignore Spelling: API

using AmberCastle.API.OpenWeather.Models;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Json;

namespace AmberCastle.API.OpenWeather
{
    public class OpenWeatherClient
    {
        #region Поля

        private readonly HttpClient _Client;
        private readonly string _ApiKey;
        private readonly string _Units;
        private readonly string _lang;

        #endregion // Поля

        #region Методы

        #region Geo 1.0
        public async Task<WeatherLocation[]> GetLocation(string Name, int Limit = 5, IProgress<double> Progress = null, CancellationToken Cancel = default)
        {
            return await _Client
                .GetFromJsonAsync<WeatherLocation[]>(
                $"/geo/1.0/direct" +
                $"?q={Name}" +
                $"&limit={Limit}" +
                $"&appid={_ApiKey}",
                cancellationToken: Cancel)
                .ConfigureAwait(false);
        }

        public async Task<WeatherLocation[]> GetLocation(string Name, string Country, int Limit = 5, string State = "", CancellationToken Cancel = default)
        {
            return await _Client
                .GetFromJsonAsync<WeatherLocation[]>(
                $"/geo/1.0/direct" +
                $"?q={Name}" +
                $",{State}" +
                $",{Country}" +
                $"&limit={Limit}" +
                $"&appid={_ApiKey}",
                cancellationToken: Cancel)
                .ConfigureAwait(false);
        }

        public async Task<WeatherLocation[]> GetLocation(double lat, double lon, int limit = 1, CancellationToken Cancel = default)
        {
            return await _Client
                .GetFromJsonAsync<WeatherLocation[]>($"/geo/1.0/reverse?lat={lat}&lon={lon}&limit={limit}&appid={_ApiKey}", Cancel)
                .ConfigureAwait(false);
        }

        #endregion // Geo 1.0

        #endregion // Методы


        #region Конструктор

        public OpenWeatherClient(HttpClient Client, IConfiguration config)
        {
            _Client = Client;
            _ApiKey = config["OpenWeatherAPI:ApiKey"];
            _Units = config["OpenWeatherAPI:Units"];
            _lang = config["OpenWeatherAPI:lang"];
        }

        #endregion // Конструктор

    }
}
