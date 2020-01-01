using System.Collections.Generic;
using System.Threading.Tasks;
using ConstellationMind.Api.Attributes;
using ConstellationMind.Core.Domain;
using ConstellationMind.Infrastructure.Services.Commands.Constellations;
using ConstellationMind.Infrastructure.Services.DTO;
using ConstellationMind.Infrastructure.Services.Queries.Constellations;
using ConstellationMind.Shared.Dispatchers.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ConstellationMind.Api.Controllers
{
    [Allow(Role.Admin)]
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

        // PUT api/constellations
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] AddStarToConstellation command)
        {
            await Dispatcher.SendAsync(command);

            return NoContent();
        }

        // DELETE api/constellations/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteConstellation command)
        {
            await Dispatcher.SendAsync(command);

            return NoContent();
        }         
    }
}
