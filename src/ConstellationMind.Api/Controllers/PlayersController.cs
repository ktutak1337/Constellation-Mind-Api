using System.Collections.Generic;
using System.Threading.Tasks;
using ConstellationMind.Infrastructure.Services.Commands.Players;
using ConstellationMind.Infrastructure.Services.DTO;
using ConstellationMind.Infrastructure.Services.Queries.Players;
using ConstellationMind.Shared.Dispatchers.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ConstellationMind.Api.Controllers
{
    public class PlayersController : BaseController
    {
        public PlayersController(IDispatcher dispatcher) : base(dispatcher)
        {

        }

        // GET api/players/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<PlayerDto>> Get([FromRoute] GetPlayer query) 
            => Single(await Dispatcher.QueryAsync(query));

        // GET api/players
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlayerDto>>> Get([FromRoute] GetPlayers query) 
            => SelectMany(await Dispatcher.QueryAsync(query));

        // PUT api/players
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdatePlayerPoints command)
        {
            await Dispatcher.SendAsync(command);

            return NoContent();
        }

        // DELETE api/players/{id}
        [HttpDelete("{playerId}")]
        public async Task<IActionResult> Delete([FromRoute] DeletePlayer command)
        {
            await Dispatcher.SendAsync(command);

            return NoContent();
        } 

    }
}
