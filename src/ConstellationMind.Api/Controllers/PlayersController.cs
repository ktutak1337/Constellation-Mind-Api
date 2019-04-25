using System.Threading.Tasks;
using ConstellationMind.Infrastructure.Services.Commands;
using ConstellationMind.Shared.Dispatchers.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ConstellationMind.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly IDispatcher _dispatcher;

        public PlayersController(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        // POST api/players
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreatePlayer command)
        {
            await _dispatcher.SendAsync(command);
            return Created($"players/{command.Nickname}", null);
        }
    }
}
