using System.Threading.Tasks;
using ConstellationMind.Infrastructure.Services.Commands;
using ConstellationMind.Infrastructure.Services.DomainServices.Interfaces;
using ConstellationMind.Shared.Handlers.Interfaces;

namespace ConstellationMind.Infrastructure.Services.Handlers.Players
{
    public class DeletePlayerHandler: ICommandHandler<DeletePlayer>
    {
        private readonly IPlayerService _playerService;

        public DeletePlayerHandler(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        public async Task HandleAsync(DeletePlayer command)
            => await _playerService.DeleteAsync(command.Id);
    }
}
