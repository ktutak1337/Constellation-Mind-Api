using System.Collections.Generic;
using System.Threading.Tasks;
using ConstellationMind.Infrastructure.Services.Commands.Constellations;
using ConstellationMind.Infrastructure.Services.DTO;
using ConstellationMind.Infrastructure.Services.Queries.Constellations;
using ConstellationMind.Shared.Dispatchers.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ConstellationMind.Api.Controllers
{
    public class ConstellationsController : BaseController
    {
        public ConstellationsController(IDispatcher dispatcher) : base(dispatcher)
        {
            
        }

        // // GET api/constellations/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ConstellationDto>> Get([FromRoute] GetConstellation query) 
            => Single(await Dispatcher.QueryAsync(query));

        // GET api/constellations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ConstellationDto>>> Get([FromRoute] GetConstellations query) 
            => SelectMany(await Dispatcher.QueryAsync(query));

        // POST api/constellations
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateConstellation command)
        {
            await Dispatcher.SendAsync(command);
            
            return CreatedAtAction(nameof(Get), new { Id = command.Id }, command.Id);
        }        
    }
}