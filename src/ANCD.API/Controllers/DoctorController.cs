using ANCD.Application.Commands;
using ANCD.Application.Mediator;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mime;

namespace ANCD.API.Controllers
{
    [Route("api/v{version:apiVersion}/doctor")]
    [ApiVersion("1.0")]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    public class DoctorController : BaseController
    {
        public DoctorController(IMediator mediator) : base(mediator)
        {
        }

        /// <summary>
        /// Register a Doctor.
        /// </summary>
        /// <param name="command">Doctor's data</param>
        /// <returns>Registered Doctor's data</returns>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST /doctor
        ///     {
        ///         "firstName": "John",
        ///         "lastName: "Doe",
        ///         "email": "johndoe@example.com",
        ///         "crmUf": "rs"
        ///         "crmNumber": 123456
        ///     }
        ///     
        /// </remarks>
        /// <response code="201">Returns the newly created doctor's data</response>
        /// <response code="400">Returns a list of erros</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RegisterDoctor([FromBody] RegisterDoctorCommand command)
        {
            var result = await _mediator.SendCommand(command);

            return DefaultResponse(result, HttpStatusCode.Created);
        }
    }
}
