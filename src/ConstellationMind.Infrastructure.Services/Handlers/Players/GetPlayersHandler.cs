using System.Collections.Generic;
using System.Threading.Tasks;
using ConstellationMind.Infrastructure.Services.DomainServices.Interfaces;
using ConstellationMind.Infrastructure.Services.DTO;
using ConstellationMind.Infrastructure.Services.Queries.Players;
using ConstellationMind.Shared.Handlers.Interfaces;

namespace ConstellationMind.Infrastructure.Services.Handlers.Players
{

    public class GetPlayersHandler : IQueryHandler<GetPlayers, IEnumerable<PlayerDto>>
    {
        private readonly IPlayerService _playerService;

        public GetPlayersHandler(IPlayerService playerService) 
            => _playerService = playerService;

        public Task<IEnumerable<PlayerDto>> HandleAsync(GetPlayers query)
            => _playerService.GetPlayersAsync();
    }
}
