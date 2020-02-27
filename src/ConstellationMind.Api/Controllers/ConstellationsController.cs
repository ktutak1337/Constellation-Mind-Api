using System.Collections.Generic;
using System.Threading.Tasks;
using ConstellationMind.Api.Attributes;
using ConstellationMind.Core.Domain;
using ConstellationMind.Infrastructure.Services.Commands.Constellations;
using ConstellationMind.Infrastructure.Services.DTO;
using ConstellationMind.Infrastructure.Services.Queries.Constellations;
using ConstellationMind.Shared.Dispatchers.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConstellationMind.Api.Controllers
{
    [Allow(Role.Admin)]
    public class ConstellationsController : BaseController
    {
        public ConstellationsController(IDispatcher dispatcher) : base(dispatcher)
        {
            
        }

        /// <summary>
        /// Returns a single constellation by `ID`.
        /// </summary>
        /// <param name="id">The unique constellation identifier.</param>
        /// <response code="200">Returns a single specific constellation. The HTTP `200 [OK]` response code indicates that the request has succeeded.</response>
        /// <response code="400">The HTTP `400 [Bad Request]` response code indicates that the server cannot or will not process the request due to something that is perceived to be a client error.</response>
        /// <response code="401">The HTTP `401 [Unauthorized]`response code indicates that the request has not been applied because it lacks valid authentication credentials for the target resource.</response>
        /// <response code="403">The HTTP `403 [Forbidden]` response code indicates that the server understood the request but refuses to authorize it.</response>
        /// <response code="404">The HTTP `404 [Not Found]` response code indicates that the server can not find the requested resource.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ConstellationDto>> Get([FromRoute] GetConstellation query) 
            => Single(await Dispatcher.QueryAsync(query));

        /// <summary>
        /// Returns a list of constellation.
        /// </summary>
        /// <response code="200">Returns a list containing all constellations. The HTTP `200 [OK]` response code indicates that the request has succeeded.</response>
        /// <response code="400">The HTTP `400 [Bad Request]` response code indicates that the server cannot or will not process the request due to something that is perceived to be a client error.</response>
        /// <response code="401">The HTTP `401 [Unauthorized]`response code indicates that the request has not been applied because it lacks valid authentication credentials for the target resource.</response>
        /// <response code="403">The HTTP `403 [Forbidden]` response code indicates that the server understood the request but refuses to authorize it.</response>
        /// <response code="404">The HTTP `404 [Not Found]` response code indicates that the server can not find the requested resource.</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<ConstellationDto>>> Get([FromRoute] GetConstellations query) 
            => SelectMany(await Dispatcher.QueryAsync(query));

        /// <summary>
        /// Creates a new constellation.
        /// </summary>
        /// <response code="201">Returns the newly created constellation. The HTTP `201 [Created]` response code indicates that the request has succeeded.</response>
        /// <response code="400">The HTTP `400 [Bad Request]` response code indicates that the server cannot or will not process the request due to something that is perceived to be a client error.</response>
        /// <response code="401">The HTTP `401 [Unauthorized]`response code indicates that the request has not been applied because it lacks valid authentication credentials for the target resource.</response>
        /// <response code="403">The HTTP `403 [Forbidden]` response code indicates that the server understood the request but refuses to authorize it.</response>
        /// <response code="404">The HTTP `404 [Not Found]` response code indicates that the server can not find the requested resource.</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Post([FromBody] CreateConstellation command)
        {
            await Dispatcher.SendAsync(command);
            
            return CreatedAtAction(nameof(Get), new { Id = command.Id }, command.Id);
        }

        /// <summary>
        /// Adds a star to the constellation.
        /// </summary>
        /// <response code="204">The HTTP `204 [No Content]` response code indicates that the server successfully processed the request and is not returning any content.</response>
        /// <response code="400">The HTTP `400 [Bad Request]` response code indicates that the server cannot or will not process the request due to something that is perceived to be a client error.</response>
        /// <response code="401">The HTTP `401 [Unauthorized]`response code indicates that the request has not been applied because it lacks valid authentication credentials for the target resource.</response>
        /// <response code="403">The HTTP `403 [Forbidden]` response code indicates that the server understood the request but refuses to authorize it.</response>
        /// <response code="404">The HTTP `404 [Not Found]` response code indicates that the server can not find the requested resource.</response>
        [HttpPut]
        [Consumes("application/json")] 
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Put([FromBody] AddStarToConstellation command)
        {
            await Dispatcher.SendAsync(command);

            return NoContent();
        }

        /// <summary>
        /// Deletes a specific constellation.
        /// </summary>
        /// <param name="id">The unique constellation identifier.</param>
        /// <response code="204">The HTTP `204 [No Content]` response code indicates that the server successfully processed the request and is not returning any content.</response>
        /// <response code="400">The HTTP `400 [Bad Request]` response code indicates that the server cannot or will not process the request due to something that is perceived to be a client error.</response>
        /// <response code="401">The HTTP `401 [Unauthorized]`response code indicates that the request has not been applied because it lacks valid authentication credentials for the target resource.</response>
        /// <response code="403">The HTTP `403 [Forbidden]` response code indicates that the server understood the request but refuses to authorize it.</response>
        /// <response code="404">The HTTP `404 [Not Found]` response code indicates that the server can not find the requested resource.</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete([FromRoute] DeleteConstellation command)
        {
            await Dispatcher.SendAsync(command);

            return NoContent();
        }         
    }
}
