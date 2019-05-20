using System.Threading.Tasks;
using ConstellationMind.Infrastructure.Services.Commands.Constellations;
using ConstellationMind.Infrastructure.Services.DTO;
using ConstellationMind.Shared.Dispatchers.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ConstellationMind.Api.Controllers
{
    public class ConstellationsController : BaseController
    {
        public ConstellationsController(IDispatcher dispatcher) : base(dispatcher)
        {
            
        }

        // POST api/constellations
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateConstellation command)
        {
            await Dispatcher.SendAsync(command);
            
            return CreatedAtAction(nameof(Get), new { Id = command.Id }, command.Id);
        }        
    }
}
