using MediatR;
using Prestadito.Menu.API.Infrastructure.Services;
using Prestadito.Menu.API.Models.DTO;

namespace Prestadito.Menu.API.Features.Queries.GetWeatherForecast
{
    public class GetWeatherForecastHandler : IRequestHandler<GetWeatherForecastQuery,List<WeatherForecastDTO>>
    {
        private readonly IWeatherForecastService _weatherService;

        public GetWeatherForecastHandler(IWeatherForecastService weatherService)
        {
            _weatherService = weatherService;
        }
        
        public async Task<List<WeatherForecastDTO>> Handle(GetWeatherForecastQuery request, CancellationToken cancellationToken)
        {
            var weather = await  this._weatherService.GetWeatherForecast();
            return weather;
            
        }
    }
}

