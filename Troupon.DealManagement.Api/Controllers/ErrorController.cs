using System.Net;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Troupon.DealManagement.Api.Controllers
{
  [ApiController]
  public class ErrorController : ControllerBase
  {
    public readonly ILogger<ErrorController> _logger;

    public ErrorController(
      ILogger<ErrorController> logger)
    {
      _logger = logger;
    }

    [Route("/error")]
    [HttpGet]
    public IActionResult Error()
    {
      var exception = HttpContext.Features.Get<IExceptionHandlerFeature>();
      var statusCode = exception.Error.GetType()
          .Name switch
        {
          "SomeBusinessException" => HttpStatusCode.BadRequest,
          _ => HttpStatusCode.ServiceUnavailable
        };
      _logger.LogError(
        exception.Error.GetType()
          .Name,
        exception);

      return Problem(
        detail: exception.Error.Message,
        statusCode: (int) statusCode);
    }
  }
}
