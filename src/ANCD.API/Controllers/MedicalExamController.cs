﻿using ANCD.Application.Commands;
using ANCD.Application.Mediator;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mime;

namespace ANCD.API.Controllers
{
    [Route("api/v{version:apiVersion}/medical-exam")]
    [ApiVersion("1.0")]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    public class MedicalExamController : BaseController
    {
        public MedicalExamController(IMediator mediator) : base(mediator)
        {
        }

        /// <summary>
        /// Schedule a medical exam.
        /// </summary>
        /// <param name="command">Medical exam data</param>
        /// <returns>Scheduled medical exam data</returns>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST /medical-exam
        ///     {
        ///         "doctorId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        ///         "patientId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        ///         "date": "2022-04-10T09:00:00.000Z"
        ///     }
        ///     
        /// </remarks>
        /// <response code="201">Returns the newly scheduled medical exam data</response>
        /// <response code="400">Returns a list of erros</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ScheduleMedicalExam([FromBody] ScheduleMedicalExamCommand command)
        {
            var result = await _mediator.SendCommand(command);

            return DefaultResponse(result, HttpStatusCode.Created);
        }
    }
}
