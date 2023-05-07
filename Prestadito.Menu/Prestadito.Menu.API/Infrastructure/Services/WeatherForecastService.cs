using Prestadito.Menu.API.Models.DTO;

namespace Prestadito.Menu.API.Infrastructure.Services
{
    public class WeatherForecastService : IWeatherForecastService
    {
        public async Task<List<WeatherForecastDTO>> GetWeatherForecast()
        {
            var weatherForecasts = new List<WeatherForecastDTO>();
            for (var index = 1; index <= 5; index++)
            {
                var forecast = new WeatherForecastDTO()
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = new Random().Next(-20, 55),
                    Summary = Summaries[new Random().Next(Summaries.Length)]
                };
                weatherForecasts.Add(forecast);
            }
            await Task.Delay(100); // Simulate async operation (e.g., API call, database query, etc.)
            return weatherForecasts;
        }
        
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
    }
}

