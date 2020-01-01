using System.Collections.Generic;
using System.Threading.Tasks;
using ConstellationMind.Api.Attributes;
using ConstellationMind.Core.Domain;
using ConstellationMind.Infrastructure.Services.DTO;
using ConstellationMind.Infrastructure.Services.Queries.Players;
using ConstellationMind.Shared.Dispatchers.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ConstellationMind.Api.Controllers
{
    [Allow(Role.Admin, Role.Player)]
    public class ScoreboardController : BaseController
    {
        public ScoreboardController(IDispatcher dispatcher) : base(dispatcher)
        {

        }
        
        // GET api/scoreboard
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlayerScoreDto>>> Get([FromRoute] GetScoreboard query) 
            => SelectMany(await Dispatcher.QueryAsync(query));
    }
}
