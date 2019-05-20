using System.Threading.Tasks;
using ConstellationMind.Infrastructure.Services.Commands.Players;
using ConstellationMind.Infrastructure.Services.DomainServices.Interfaces;
using ConstellationMind.Shared.Handlers.Interfaces;

namespace ConstellationMind.Infrastructure.Services.Handlers.Players
{
    public class UpdatePlayerPointsHandler : ICommandHandler<UpdatePlayerPoints>
    {
        private readonly IPlayerService _playerService;

        public UpdatePlayerPointsHandler(IPlayerService playerService) 
            => _playerService = playerService;

        public async Task HandleAsync(UpdatePlayerPoints command)
            => await _playerService.UpdatePointsAsync(command.PlayerId, command.Points);
                
    }
}
