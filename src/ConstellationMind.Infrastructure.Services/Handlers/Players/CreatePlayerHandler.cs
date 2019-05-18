using System;
using System.Threading.Tasks;
using ConstellationMind.Infrastructure.Services.Commands;
using ConstellationMind.Infrastructure.Services.DomainServices.Interfaces;
using ConstellationMind.Shared.Handlers.Interfaces;

namespace ConstellationMind.Infrastructure.Services.Handlers.Players
{
    public class CreatePlayerHandler : ICommandHandler<CreatePlayer>
    {
        private readonly IPlayerService _playerService;

        public CreatePlayerHandler(IPlayerService playerService) 
            => _playerService = playerService;

        public async Task HandleAsync(CreatePlayer command)
            => await _playerService
                .RegisterAsync(command.PlayerId = Guid.NewGuid(), command.Email, command.Password, command.Nickname, command.FirstName);
    }
}
