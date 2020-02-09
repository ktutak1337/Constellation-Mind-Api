using System.Threading.Tasks;
using ConstellationMind.Core.Domain;
using ConstellationMind.Core.Repositories;
using ConstellationMind.Infrastructure.Persistance.MongoDb.Interfaces;

namespace ConstellationMind.Infrastructure.Persistance.Repositories
{
    public class RefreshTokenRepository : IRefreshTokenRepository
    {
        private readonly IMongoDbRepository<RefreshToken> _repository;
        
        public RefreshTokenRepository(IMongoDbRepository<RefreshToken> repository)
            => _repository = repository;

        public async Task AddAsync(RefreshToken token)
            => await _repository.AddAsync(token);

        public async Task<RefreshToken> GetAsync(string token) 
            => await _repository.GetAsync(x => x.Token == token);

        public async Task UpdateAsync(RefreshToken token)
            => await _repository.UpdateAsync(token);
    }
}
