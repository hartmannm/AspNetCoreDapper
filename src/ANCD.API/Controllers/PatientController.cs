using ANCD.Application.Commands;
using ANCD.Application.Mediator;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mime;

namespace ANCD.API.Controllers
{
    [Route("api/v{version:apiVersion}/patient")]
    [ApiVersion("1.0")]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    public class PatientController : BaseController
    {
        public PatientController(IMediator mediator) : base(mediator)
        {
        }

        /// <summary>
        /// Register a Patient.
        /// </summary>
        /// <param name="command">Patient's data</param>
        /// <returns>Registered Patient's data</returns>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST /patient
        ///     {
        ///         "firstName": "John",
        ///         "lastName: "Doe",
        ///         "email": "johndoe@example.com",
        ///         "birthDate": "1993-01-13T23:00:32.012Z"
        ///     }
        ///     
        /// </remarks>
        /// <response code="201">Returns the newly created datient's data</response>
        /// <response code="400">Returns a list of erros</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType( StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RegisterPatient([FromBody] RegisterPatientCommand command)
        {
            var result = await _mediator.SendCommand(command);

            return DefaultResponse(result, HttpStatusCode.Created);
        }
    }
}
