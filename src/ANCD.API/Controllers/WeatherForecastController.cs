using ANCD.Application.Commands;
using ANCD.Application.Mediator;
using Microsoft.AspNetCore.Mvc;

namespace ANCD.API.Controllers
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

        [HttpPost]
        public async Task<IActionResult> Teste([FromBody] RegisterDoctorCommand command)
        {
            var result = await _mediator.SendCommand(command);

            return Ok(result);  
        }
    }
}