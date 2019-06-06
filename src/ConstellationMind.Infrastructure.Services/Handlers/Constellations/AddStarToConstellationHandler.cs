using System;
using System.Threading.Tasks;
using ConstellationMind.Infrastructure.Services.Commands.Constellations;
using ConstellationMind.Infrastructure.Services.Services.DomainServices.Interfaces;
using ConstellationMind.Shared.Handlers.Interfaces;

namespace ConstellationMind.Infrastructure.Services.Handlers.Constellations
{
    public class AddStarToConstellationHandler : ICommandHandler<AddStarToConstellation>
    {
        private readonly IConstellationService _constellationService;

        public AddStarToConstellationHandler(IConstellationService constellationService) 
            => _constellationService = constellationService;

        public async Task HandleAsync(AddStarToConstellation command)
            => await _constellationService
                .AddStarAsync(command.ConstellationId, command.Designation, command.Name, command.Constellation, command.Coordinates, command.Magnitude);
    }
}
