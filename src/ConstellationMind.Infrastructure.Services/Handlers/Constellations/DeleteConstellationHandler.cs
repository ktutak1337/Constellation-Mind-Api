using System.Threading.Tasks;
using ConstellationMind.Infrastructure.Services.Commands.Constellations;
using ConstellationMind.Infrastructure.Services.Services.Domains.Interfaces;
using ConstellationMind.Shared.Handlers.Interfaces;

namespace ConstellationMind.Infrastructure.Services.Handlers.Constellations
{
    public class DeleteConstellationHandler : ICommandHandler<DeleteConstellation>
    {
        private readonly IConstellationService _constellationService;

        public DeleteConstellationHandler(IConstellationService constellationService)
            => _constellationService = constellationService;

        public async Task HandleAsync(DeleteConstellation command)
            => await _constellationService.DeleteAsync(command.Id);
    }
}
