using System.Threading.Tasks;
using ConstellationMind.Infrastructure.Services.Commands;
using ConstellationMind.Shared.Dispatchers.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ConstellationMind.Api.Controllers
{
    public class PlayersController : BaseController
    {
        public PlayersController(IDispatcher dispatcher) : base(dispatcher)
        {

        }

        // POST api/players
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreatePlayer command)
        {
            await Dispatcher.SendAsync(command);
            return Created($"api/players/{command.Nickname}", value: null);
        }
    }
}
