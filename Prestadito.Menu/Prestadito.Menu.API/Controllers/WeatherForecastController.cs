using MediatR;
using Microsoft.AspNetCore.Mvc;
using Prestadito.Menu.API.Features.Queries.GetWeatherForecast;

namespace Prestadito.Menu.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IMediator _mediator;
        
        public WeatherForecastController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        [Produces("application/json")]
        public async Task<IActionResult> Get()
        {
            var query = new GetWeatherForecastQuery();
            var weather = await this._mediator.Send(query);
            return this.Ok(weather);
        }
       
        
        
    }
}