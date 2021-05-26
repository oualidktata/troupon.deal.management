using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using CRM.Integration.Contracts.InputModels;
using CRM.Integration.Contracts.DTOs;

namespace release_mgt_service.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json", "application/xml")]
    [Consumes("application/json", "application/xml")]
    public class IncidentController : ControllerBase
    {
        private readonly ILogger<IncidentController> _logger;

        public IncidentController(ILogger<IncidentController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Gets incidents modified from a given modified date
        /// </summary>
        /// <returns>List of incidents.</returns>
        [ProducesResponseType(typeof(IEnumerable<IncidentDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status406NotAcceptable)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status409Conflict)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status202Accepted)]

        [ProducesDefaultResponseType]
        [SwaggerOperation(
            Description = "Returns all incidents modified from a given date",
            OperationId = "GetIncidentsFromLastDate",
            Tags = new[] { "Incident" }
        )]
        [HttpPost]

        public async Task<ActionResult<IEnumerable<IncidentDto>>> SearchIncidents([FromBody] IncidentSearchInput inputModel)
        {
            try
            {
                if (!ModelState.IsValid){ return BadRequest(new ValidationProblemDetails(ModelState)); }  
                return Ok(new List<IncidentDto> { new IncidentDto { Date = "124444", MyProperty = "1254" } });
            }
            catch (Exception exception)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status500InternalServerError,exception));
            }
        }
    }
}
