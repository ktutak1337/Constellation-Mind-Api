using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ConstellationMind.Core.Domain;
using ConstellationMind.Core.Repositories;
using ConstellationMind.Infrastructure.Persistance.MongoDb.Interfaces;

namespace ConstellationMind.Infrastructure.Persistance.Repositories
{
    public class ScoreboardRepository : IScoreboardRepository
    {
        private readonly IMongoDbRepository<PlayerScore> _repository;

        public ScoreboardRepository(IMongoDbRepository<PlayerScore> repository)
            => _repository = repository;

        public async Task AddAsync(PlayerScore playerScore)
            => await _repository.AddAsync(playerScore);

        public async Task<IEnumerable<PlayerScore>> GetAllAsync()
            => await _repository.FindAsync();

        public async Task UpdateAsync(PlayerScore playerScore)
            => await _repository.UpdateAsync(playerScore);

        public Task RemoveAsync(Guid identity)
            => _repository.DeleteAsync(identity);  
    }
}
