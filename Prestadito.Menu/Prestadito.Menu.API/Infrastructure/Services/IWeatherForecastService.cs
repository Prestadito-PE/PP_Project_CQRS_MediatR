namespace Prestadito.Menu.API.Infrastructure.Services
{
    using Prestadito.Menu.API.Models.DTO;
    
    public interface IWeatherForecastService
    {
        Task<List<WeatherForecastDTO>> GetWeatherForecast();
    }
}