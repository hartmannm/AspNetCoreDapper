using ANCD.Application.Mediator;
using ANCD.Application.Messages.CommandsQueries;
using ANCD.Application.Messages.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ANCD.API.Controllers
{
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        protected IMediator _mediator;

        protected BaseController(IMediator mediator)
        {
            _mediator = mediator;
        }

        protected IActionResult DefaultResponse(CommandResult result, HttpStatusCode statusCode)
        {
            if (result.IsSuccess is false)
                return BadRequest(result.Errors);

            return ApiDefaultResponse<object>(null, statusCode);
        }

        protected IActionResult DefaultResponse<T>(QueryResult<T> result, HttpStatusCode statusCode)
        {
            if (result.IsSuccess is false)
                return BadRequest(result.Errors);

            return ApiDefaultResponse<object>(result.Data, statusCode);
        }

        private IActionResult ApiDefaultResponse<T>(T result, HttpStatusCode statusCode)
        {
            switch (statusCode)
            {
                case HttpStatusCode.OK:
                    return result is null ? Ok() : Ok(result);
                case HttpStatusCode.Created:
                    return new ObjectResult(result) { StatusCode = (int)HttpStatusCode.Created };
                case HttpStatusCode.NoContent:
                    return NoContent();
                default:
                    return result is null ? Ok() : Ok(result);
            }
        }
    }
}
