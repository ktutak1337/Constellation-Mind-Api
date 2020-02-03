using System.Threading.Tasks;
using ConstellationMind.Infrastructure.Services.Commands.Players;
using ConstellationMind.Infrastructure.Services.DomainServices.Interfaces;
using ConstellationMind.Shared.Handlers.Interfaces;

namespace ConstellationMind.Infrastructure.Services.Handlers.Players
{
    public class UpdatePlayerHandler : ICommandHandler<UpdatePlayer>
    {
        private readonly IPlayerService _playerService;

        public UpdatePlayerHandler(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        public Task HandleAsync(UpdatePlayer command)
            => _playerService.UpdatePlayerAsync(command.Id, command.Email, command.FirstName, command.Nickname);
    }
}
