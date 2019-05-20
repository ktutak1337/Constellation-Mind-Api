using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ConstellationMind.Core.Domain;
using ConstellationMind.Core.Repositories;
using ConstellationMind.Infrastructure.Persistance.MongoDb.Interfaces;

namespace ConstellationMind.Infrastructure.Persistance.Repositories
{
    public class ConstellationRepository : IConstellationRepository
    {
        private readonly IMongoDbRepository<Constellation> _repository;

         public ConstellationRepository(IMongoDbRepository<Constellation> repository)
            => _repository = repository;

        public async Task<Constellation> GetAsync(Guid identity)
            => await _repository.GetAsync(identity);

        public async Task<IEnumerable<Constellation>> GetAllAsync()
            => await _repository.FindAsync();

        public async Task AddAsync(Constellation constellation)
            => await _repository.AddAsync(constellation);

        public async Task UpdateAsync(Constellation constellation)
            => await _repository.UpdateAsync(constellation);

        public async Task RemoveAsync(Guid identity)
            => await _repository.DeleteAsync(identity);
    }
}
