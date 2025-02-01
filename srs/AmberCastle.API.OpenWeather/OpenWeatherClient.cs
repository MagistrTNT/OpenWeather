// Ignore Spelling: API

using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
