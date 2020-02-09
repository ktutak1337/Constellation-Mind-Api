using System.Collections.Generic;
using System.Threading.Tasks;
using ConstellationMind.Infrastructure.Services.Domains.Interfaces;
using ConstellationMind.Infrastructure.Services.DTO;
using ConstellationMind.Infrastructure.Services.Queries.Players;
using ConstellationMind.Shared.Handlers.Interfaces;

namespace ConstellationMind.Infrastructure.Services.Handlers.Scoreboard
{
    public class GetScoreboardHandler : IQueryHandler<GetScoreboard, IEnumerable<PlayerScoreDto>>
    {
        private readonly IScoreboardService _scoreboardService;

        public GetScoreboardHandler(IScoreboardService scoreboardService) 
            => _scoreboardService = scoreboardService;

        public async Task<IEnumerable<PlayerScoreDto>> HandleAsync(GetScoreboard query)
            => await _scoreboardService.GetScoreboardAsync();
    }
}
