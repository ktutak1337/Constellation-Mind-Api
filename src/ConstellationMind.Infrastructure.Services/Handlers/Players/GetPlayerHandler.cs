using System.Threading.Tasks;
using ConstellationMind.Infrastructure.Services.DomainServices.Interfaces;
using ConstellationMind.Infrastructure.Services.DTO;
using ConstellationMind.Infrastructure.Services.Queries;
using ConstellationMind.Shared.Handlers.Interfaces;

namespace ConstellationMind.Infrastructure.Services.Handlers.Players
{
    public class GetPlayerHandler : IQueryHandler<GetPlayer, PlayerDto>
    {
        private readonly IPlayerService _playerService;

        public GetPlayerHandler(IPlayerService playerService) => _playerService = playerService;

        public async Task<PlayerDto> HandleAsync(GetPlayer query) 
            => await _playerService.GetAsync(query.Id);
    }
}
