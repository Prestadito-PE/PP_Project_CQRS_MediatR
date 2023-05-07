namespace Prestadito.Menu.API.Features.Queries.GetWeatherForecast
{
    using MediatR;
    using Models.DTO;
    
    public class GetWeatherForecastQuery : IRequest<List<WeatherForecastDTO>>
    {
    }
}
