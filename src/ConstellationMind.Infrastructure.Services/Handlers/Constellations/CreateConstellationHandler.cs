using System;
using System.Threading.Tasks;
using ConstellationMind.Infrastructure.Services.Commands.Constellations;
using ConstellationMind.Infrastructure.Services.Services.DomainServices.Interfaces;
using ConstellationMind.Shared.Handlers.Interfaces;

namespace ConstellationMind.Infrastructure.Services.Handlers.Constellations
{
    public class CreateConstellationHandler : ICommandHandler<CreateConstellation>
    {
        private readonly IConstellationService _constellationService;

        public CreateConstellationHandler(IConstellationService constellationService) 
            => _constellationService = constellationService;

        public async Task HandleAsync(CreateConstellation command)
            => await _constellationService.CreateAsync(command.Id = Guid.NewGuid(), command.Designation, command.Name);
    }
}
