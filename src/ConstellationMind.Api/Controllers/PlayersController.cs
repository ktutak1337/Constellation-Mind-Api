using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ConstellationMind.Api.Attributes;
using ConstellationMind.Core.Domain;
using ConstellationMind.Infrastructure.Services.Commands.Players;
using ConstellationMind.Infrastructure.Services.DTO;
using ConstellationMind.Infrastructure.Services.Queries.Players;
using ConstellationMind.Shared.Dispatchers.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ConstellationMind.Api.Controllers
{
    [Allow(Role.Admin)]
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

        // PUT api/players/{id}/points
        [HttpPut("{id}/points")]
        public async Task<IActionResult> Put(Guid id, UpdatePlayerPoints command)
        {
            command.Id = id;

            await Dispatcher.SendAsync(command);

            return NoContent();
        }

        // PUT api/players/{id}/details
        [HttpPut("{id}/details")]
        public async Task<IActionResult> Put(Guid id, UpdatePlayer command)
        {
            command.Id = id;

            await Dispatcher.SendAsync(command);

            return NoContent();
        }
    }
}
