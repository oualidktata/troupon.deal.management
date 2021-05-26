using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;

namespace release_mgt_service.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json", "application/xml")]
    [Consumes("application/json", "application/xml")]
    public class EngineTrackerController : ControllerBase
    {
        private readonly ILogger<EngineTrackerController> _logger;

        public EngineTrackerController(ILogger<EngineTrackerController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Gets enginetracker data
        /// </summary>
        /// <returns>List of enginetracker data items.</returns>
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
        public async Task<ActionResult<IEnumerable<EngineTrackerDTO>>> SearchEngineTrackerData([FromBody] SearchEngineTrackerInput inputModel)
        {
            try
            {
                if (!ModelState.IsValid){ return BadRequest(new ValidationProblemDetails(ModelState)); }  
                return Ok(new List<EngineTrackerDTO> { new EngineTrackerDTO () });
            }
            catch (Exception exception)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status500InternalServerError,exception));
            }
        }
    }
}
