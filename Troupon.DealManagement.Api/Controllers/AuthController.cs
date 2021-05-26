using System;
using System.Threading.Tasks;
using Infra.oAuthService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Troupon.DealManagement.Api.Controllers
{
  [Route("api/[controller]")]
  [Produces(
    "application/json",
    "application/xml",
    "text/plain")]
  [Consumes(
    "application/json",
    "application/xml",
    "text/plain")]
  [ApiController]
  public class AuthController : ControllerBase
  {
    private IAuthService _tokenService { get; set; }

    public AuthController(
      IAuthService tokenService)
    {
      _tokenService = tokenService;
    }

    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType]
    [SwaggerOperation(
      Description = "Authenticate the API",
      OperationId = "GetAccessToken",
      Tags = new[] {"*GetToken 1st*"})]
    [HttpPost("token")]
    [AllowAnonymous]
    public async Task<IActionResult> Token()
    {
      try
      {
        var token = await _tokenService.GetToken();

        if (token == null)
        {
          return await Task.FromResult(
            StatusCode(
              StatusCodes.Status500InternalServerError,
              "Token is empty"));
        }

        return Ok(token);
      }
      catch (Exception ex)
      {
        return await Task.FromResult(
          StatusCode(
            StatusCodes.Status500InternalServerError,
            ex.Message));
      }
    }

    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType]
    [SwaggerOperation(
      Description = "Call back",
      OperationId = "callback",
      Tags = new[] {"Authorize app"})]
    [HttpPost("callback")]
    [AllowAnonymous]
    public async Task<IActionResult> Authorize()
    {
      try
      {
        var token = await _tokenService.GetToken();

        if (token == null)
        {
          return await Task.FromResult(
            StatusCode(
              StatusCodes.Status500InternalServerError,
              "Token is empty"));
        }

        return Ok(token);
      }
      catch (Exception ex)
      {
        return await Task.FromResult(
          StatusCode(
            StatusCodes.Status500InternalServerError,
            ex.Message));
      }
    }
  }
}
