// Ignore Spelling: API

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Polly;
using Polly.Extensions.Http;

namespace AmberCastle.API.OpenWeather.TestConsole
{
    class Program
    {
        private static IHost __Hosting;

        public static IHost Hosting => __Hosting ??= CreateHostBuilder(Environment.GetCommandLineArgs()).Build();

        public static IServiceProvider Services => Hosting.Services;

        public static IHostBuilder CreateHostBuilder(string[] args) => Host
            .CreateDefaultBuilder(args)
            .ConfigureServices(ConfigureServices);

        private static void ConfigureServices(HostBuilderContext context, IServiceCollection collection)
        {
            collection.AddHttpClient<OpenWeatherClient>(client =>
            {
                var config = context.Configuration.GetSection("OpenWeatherAPI");
                client.BaseAddress = new Uri(
                    $"{config["Schema"]}://" +
                    $"{config["Address"]}" +
                    $"/");
            })
                .SetHandlerLifetime(TimeSpan.FromMinutes(5)) // время жизни клиента
                .AddPolicyHandler(GetRetryPolicy());
        }

        private static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
        {
            var jitter = new Random();
            return HttpPolicyExtensions
                .HandleTransientHttpError()
                .WaitAndRetryAsync(6, retry_attempt =>
                    TimeSpan.FromSeconds(Math.Pow(2, retry_attempt)) +
                    TimeSpan.FromMilliseconds(jitter.Next(0, 1000)));
        }

        static async Task Main(string[] args)
        {
            using var host = Hosting;
            await host.StartAsync();

            var weather = Services.GetRequiredService<OpenWeatherClient>();

            var location = await weather.GetLocation("Moscow", "ru");
            var location2 = await weather.GetLocation(51.5098, -0.1180);

            //var wez = await weather.GetWeather(55.7522, 37.6156);

            Console.WriteLine("Завершение!");
            Console.ReadLine();
            await host.StopAsync();
        }
    }
}
