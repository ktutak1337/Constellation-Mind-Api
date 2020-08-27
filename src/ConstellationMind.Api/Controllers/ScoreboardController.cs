using System.Collections.Generic;
using System.Threading.Tasks;
using ConstellationMind.Api.Attributes;
using ConstellationMind.Core.Domain;
using ConstellationMind.Infrastructure.Services.DTO;
using ConstellationMind.Infrastructure.Services.Queries.Players;
using ConstellationMind.Shared.Dispatchers.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConstellationMind.Api.Controllers
{
    [Allow(Role.Admin, Role.Player)]
    public class ScoreboardController : BaseController
    {
        public ScoreboardController(IDispatcher dispatcher) 
            : base(dispatcher) { }
        
        /// <summary>
        /// Returns scoreboard.
        /// </summary>
        /// <response code="200">Returns a list of results for all players. The HTTP `200 [OK]` response code indicates that the request has succeeded.</response>
        /// <response code="401">The HTTP `401 [Unauthorized]` response code indicates that the request has not been applied because it lacks valid authentication credentials for the target resource.</response>
        /// <response code="404">The HTTP `404 [Not Found]` response code indicates that the server can not find the requested resource.</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get([FromRoute] GetScoreboard query) 
            => Select<IEnumerable<PlayerScoreDto>>(await Dispatcher.QueryAsync(query));
    }
}
