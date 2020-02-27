using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ConstellationMind.Api.Attributes;
using ConstellationMind.Core.Domain;
using ConstellationMind.Infrastructure.Services.Commands.Players;
using ConstellationMind.Infrastructure.Services.DTO;
using ConstellationMind.Infrastructure.Services.Queries.Players;
using ConstellationMind.Shared.Dispatchers.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConstellationMind.Api.Controllers
{
    [Allow(Role.Admin, Role.Player)]
    public class PlayersController : BaseController
    {
        public PlayersController(IDispatcher dispatcher) : base(dispatcher)
        {

        }

        /// <summary>
        /// Returns a single player by `ID`.
        /// </summary>
        /// <param name="id">The unique player identifier.</param>
        /// <response code="200">Returns a unique `ID` for a single specific user. The HTTP `200 [OK]` response code indicates that the request has succeeded.</response>
        /// <response code="401">The HTTP `401 [Unauthorized]` response code indicates that the request has not been applied because it lacks valid authentication credentials for the target resource.</response>
        /// <response code="404">The HTTP `404 [Not Found]` response code indicates that the server can not find the requested resource.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PlayerDto>> Get([FromRoute] GetPlayer query) 
            => Single(await Dispatcher.QueryAsync(query));

        /// <summary>
        /// Returns a list of players.
        /// </summary>
        /// <response code="200">Returns a list of all players. The HTTP `200 [OK]` response code indicates that the request has succeeded.</response>
        /// <response code="401">The HTTP `401 [Unauthorized]` response code indicates that the request has not been applied because it lacks valid authentication credentials for the target resource.</response>
        /// <response code="404">The HTTP `404 [Not Found]` response code indicates that the server can not find the requested resource.</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<PlayerDto>>> Get([FromRoute] GetPlayers query) 
            => SelectMany(await Dispatcher.QueryAsync(query));

        /// <summary>
        /// Updates the number of points for a specific player.
        /// </summary>
        /// <param name="id">The unique player identifier.</param>
        /// <response code="204">The HTTP `204 [No Content]` response code indicates that the server successfully processed the request and is not returning any content.</response>
        /// <response code="400">The HTTP `400 [Bad Request]` response code indicates that the server cannot or will not process the request due to something that is perceived to be a client error.</response>
        /// <response code="401">The HTTP `401 [Unauthorized]`response code indicates that the request has not been applied because it lacks valid authentication credentials for the target resource.</response>
        /// <response code="404">The HTTP `404 [Not Found]` response code indicates that the server can not find the requested resource.</response>
        [HttpPut("{id}/points")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Put(Guid id, UpdatePlayerPoints command)
        {
            command.Id = id;

            await Dispatcher.SendAsync(command);

            return NoContent();
        }

        /// <summary>
        /// Updates the details of a specific player.
        /// </summary>
        /// <param name="id">The unique player identifier.</param>
        /// <response code="204">The HTTP `204 [No Content]` response code indicates that the server successfully processed the request and is not returning any content.</response>
        /// <response code="400">The HTTP `400 [Bad Request]` response code indicates that the server cannot or will not process the request due to something that is perceived to be a client error.</response>
        /// <response code="401">The HTTP `401 [Unauthorized]`response code indicates that the request has not been applied because it lacks valid authentication credentials for the target resource.</response>
        /// <response code="404">The HTTP `404 [Not Found]` response code indicates that the server can not find the requested resource.</response>
        [HttpPut("{id}/details")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Put(Guid id, UpdatePlayer command)
        {
            command.Id = id;

            await Dispatcher.SendAsync(command);

            return NoContent();
        }
    }
}
