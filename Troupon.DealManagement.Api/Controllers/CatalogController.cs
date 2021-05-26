using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Troupon.DealManagement.Core.Application.Commands;
using Troupon.DealManagement.Core.Application.Queries.Deals;
using Troupon.DealManagement.Core.Domain;
using Troupon.DealManagement.Core.Domain.Dtos;
using Troupon.DealManagement.Core.Domain.InputModels;

namespace Troupon.DealManagement.Api.Controllers
{
  [ApiController]
  [Route("api")]
  [Produces(
    "application/json",
    "application/xml")]
  [Consumes(
    "application/json",
    "application/xml")]
  public class CatalogController : BaseController
  {
    public CatalogController(
      IMapper mapper,
      IMediator mediator) : base(
      mediator,
      mapper)
    {
    }

    /// <summary>
    /// Gets all active Deals
    /// </summary>
    /// <returns>List of Deal Dtos</returns>
    [ProducesResponseType(
      typeof(IEnumerable<DealDto>),
      StatusCodes.Status200OK)]

    // [ProducesResponseType(StatusCodes.Status202Accepted)]
    [ProducesResponseType(
      typeof(ValidationProblemDetails),
      StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status406NotAcceptable)]
    [ProducesResponseType(
      typeof(ProblemDetails),
      StatusCodes.Status409Conflict)]
    [ProducesResponseType(
      typeof(ProblemDetails),
      StatusCodes.Status500InternalServerError)]
    [ProducesDefaultResponseType]
    [SwaggerOperation(
      Description = "Returns all active Deals",
      OperationId = "SearchDeals",
      Tags = new[] {"Search"}
    )]
    [HttpPost]
    [Route("search")]
    /*[Authorize(Roles = "crm-api-backend")]*/
    public async Task<ActionResult<IEnumerable<DealDto>>> Search(
      [FromBody] SearchDealsFilter filter,
      CancellationToken cancellationToken)
    {
      try
      {
        if (!ModelState.IsValid)
        {
          return BadRequest(new ValidationProblemDetails());
        }

        var result = await Mediator.Send<IEnumerable<DealDto>>(
          new GetDealsQuery(filter),
          cancellationToken);

        return Ok(result);
      }
      catch (Exception exception)
      {
        return await Task.FromResult(
          StatusCode(
            StatusCodes.Status500InternalServerError,
            exception));
      }
    }

    /// <summary>
    /// Gets a specific Deal
    /// </summary>
    /// <returns>Returns a Deal Dto</returns>
    [ProducesResponseType(
      typeof(DealDto),
      StatusCodes.Status200OK)]
    [ProducesResponseType(
      typeof(ValidationProblemDetails),
      StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status406NotAcceptable)]
    [ProducesResponseType(
      typeof(ProblemDetails),
      StatusCodes.Status409Conflict)]
    [ProducesResponseType(
      typeof(ProblemDetails),
      StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status202Accepted)]
    [ProducesDefaultResponseType]
    [SwaggerOperation(
      Description = "Returns the Deal specified by Id",
      OperationId = "GetOneDeal",
      Tags = new[] {"One Deal"}
    )]
    [HttpGet]
    [Route("Deals/{id}")]
    public async Task<ActionResult<IEnumerable<DealDto>>> Get(
      Guid id,
      CancellationToken cancellationToken)
    {
      try
      {
        var result = await Mediator.Send<DealDto>(
          new GetOneDealQuery() {Id = id},
          cancellationToken);

        return Ok(result);
      }
      catch (Exception exception)
      {
        return await Task.FromResult(
          StatusCode(
            StatusCodes.Status500InternalServerError,
            exception));
      }
    }

    /// <summary>
    /// Create a new Deal
    /// </summary>
    /// <returns>Returns the Deal created</returns>
    /// <response code="201">Returned if the Deal was Created</response>
    /// <response code="400">Returned if the model couldn't be parsed or the customer couldn't be found</response>
    /// <response code="406">Returned if no response found with an acceptable format</response>
    /// <response code="422">Returned when the validation failed</response>
    [ProducesResponseType(
      typeof(DealDto),
      StatusCodes.Status201Created)]
    [ProducesResponseType(
      typeof(ValidationProblemDetails),
      StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status406NotAcceptable)]
    [ProducesResponseType(
      typeof(ProblemDetails),
      StatusCodes.Status409Conflict)]
    [ProducesResponseType(
      typeof(ProblemDetails),
      StatusCodes.Status500InternalServerError)]
    [ProducesDefaultResponseType]
    [SwaggerOperation(
      Description = "Returns the Deal specified by Id",
      OperationId = "CreateDeal",
      Tags = new[] {"Deals"}
    )]
    [HttpPost]
    [Route("Deals")]
    public async Task<ActionResult<DealDto>> Post(
      [FromBody] CreateDealCommand model,
      CancellationToken cancellationToken)
    {
      try
      {
        var result = await Mediator.Send<DealDto>(
          model,
          cancellationToken);

        // await Mediator.Publish<DealCreatedEvent>(new DealCreatedEvent());
        //await DomainEvents.Raise(new DealCreatedEvent());
        return CreatedAtAction(
          nameof(Get),
          new {id = result.Id},
          result);
      }
      catch (Exception exception)
      {
        return await Task.FromResult(
          StatusCode(
            StatusCodes.Status500InternalServerError,
            exception));
      }
    }

    [HttpPost]
    [Route("Deals/Publish")]
    public async Task<ActionResult<DealDto>> Publish(
      [FromBody] PublishDealCommand model,
      CancellationToken cancellationToken)
    {
      try
      {
        var result = await Mediator.Send(
          model,
          cancellationToken);

        return Ok();
      }
      catch (Exception exception)
      {
        return await Task.FromResult(
          StatusCode(
            StatusCodes.Status500InternalServerError,
            exception));
      }
    }
  }
}
