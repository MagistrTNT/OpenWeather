// Ignore Spelling: API

using AmberCastle.API.OpenWeather.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Net.Http.Json;

namespace AmberCastle.API.OpenWeather
{
    public class OpenWeatherClient
    {
        #region Поля

        private readonly HttpClient _Client;
        private readonly OpenWeatherConfig _Config;

        #endregion // Поля

        #region Конструктор

        public OpenWeatherClient(HttpClient Client, IOptions<OpenWeatherConfig> options)
        {
            _Client = Client;
            _Config = options.Value;
        }

        #endregion // Конструктор



        #region Методы

        #region data 2.5

        public async Task<WeatherInfo> GetWeather(double lat, Double lon, CancellationToken Cancel = default)
        {
            return await _Client
                .GetFromJsonAsync<WeatherInfo>(
                $"/data/2.5/weather" +
                $"?lat={lat}" +
                $"&lon={lon}" +
                $"&units={_Config.Units}" +
                $"&lang={_Config.Lang}" +
                $"&appid={_Config.ApiKey}"
                , cancellationToken: Cancel)
                .ConfigureAwait(false);
        }

        #endregion // data 2.5

        #region Geo 1.0
        public async Task<WeatherLocation[]> GetLocation(string Name, int Limit = 5, IProgress<double> Progress = null, CancellationToken Cancel = default)
        {
            return await _Client
                .GetFromJsonAsync<WeatherLocation[]>(
                $"/geo/1.0/direct" +
                $"?q={Name}" +
                $"&limit={Limit}" +
                $"&appid={_Config.ApiKey}",
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
                $"&appid={_Config.ApiKey}",
                cancellationToken: Cancel)
                .ConfigureAwait(false);
        }

        public async Task<WeatherLocation[]> GetLocation(double lat, double lon, int limit = 1, CancellationToken Cancel = default)
        {
            var stop = lat;
            return await _Client
                .GetFromJsonAsync<WeatherLocation[]>($"/geo/1.0/reverse?lat={lat}&lon={lon}&limit={limit}&appid={_Config.ApiKey}", Cancel)
                .ConfigureAwait(false);
        }

        #endregion // Geo 1.0

        #endregion // Методы


    }
}
