using System.Collections.Generic;
using System.Threading.Tasks;
using ConstellationMind.Infrastructure.Services.Commands;
using ConstellationMind.Infrastructure.Services.DTO;
using ConstellationMind.Infrastructure.Services.Queries;
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

        // POST api/players
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreatePlayer command)
        {
            await Dispatcher.SendAsync(command);
        
            return CreatedAtAction(nameof(Get), new { Id = command.Identity }, command.Identity);
        }

        // DELETE api/players/{id}
        [HttpDelete("{id}")]
        public async Task Delete([FromRoute] DeletePlayer command) => await Dispatcher.SendAsync(command);

    }
}
