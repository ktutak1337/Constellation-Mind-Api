using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ConstellationMind.Core.Domain;
using ConstellationMind.Core.Repositories;
using ConstellationMind.Infrastructure.Services.DomainServices.Interfaces;
using ConstellationMind.Infrastructure.Services.DTO;
using ConstellationMind.Shared.Extensions;

namespace ConstellationMind.Infrastructure.Services.DomainServices
{
    public class ScoreboardService : IScoreboardService
    {
        private readonly IScoreboardRepository _scoreboardRepository;
        private readonly IMapper _mapper;

        public ScoreboardService(IScoreboardRepository scoreboardRepository, IMapper mapper)
        {
            _scoreboardRepository = scoreboardRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PlayerScoreDto>> GetScoreboardAsync()
            => (await _scoreboardRepository.GetAllAsync())
                .MapCollection<PlayerScore, PlayerScoreDto>(_mapper);
    }
}
