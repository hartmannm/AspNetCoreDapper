using ANCD.Application.Commands;
using ANCD.Application.DTOs;
using ANCD.Application.Mediator;
using ANCD.Application.Queries;
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

        /// <summary>
        /// Search by a Patient with the specified Id.
        /// </summary>
        /// <param name="id">Patient's Id</param>
        /// <returns>Patient's data</returns>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET /patient/6522d02c-c12e-413e-ae3f-30dd549aacdd
        ///     
        /// </remarks>
        /// <response code="200">Returns the patient's data</response>
        /// <response code="204">Data not found</response>
        /// <response code="400">Returns a list of erros</response>
        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(PatientDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetPatientById([FromRoute] Guid id)
        {
            var query = new GetPatientByIdQuery(id);
            var result = await _mediator.SendQuery<GetPatientByIdQuery, PatientDTO>(query);
            var statusCode = result.Data is null ? HttpStatusCode.NoContent : HttpStatusCode.OK;

            return DefaultResponse(result, statusCode);
        }
    }
}
