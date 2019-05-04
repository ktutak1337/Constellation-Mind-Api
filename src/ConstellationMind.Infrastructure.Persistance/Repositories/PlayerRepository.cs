using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ConstellationMind.Core.Domain;
using ConstellationMind.Core.Repositories;
using ConstellationMind.Infrastructure.Persistance.MongoDb.Interfaces;

namespace ConstellationMind.Infrastructure.Persistance.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        #region Fields
        private readonly IMongoDbRepository<Player> _repository;
        #endregion

        #region Constructors
        public PlayerRepository(IMongoDbRepository<Player> repository) => _repository = repository;
        
        #endregion

        #region Methods
        public async Task AddAsync(Player player) => await _repository.AddAsync(player);

        public async Task<IEnumerable<Player>> GetAllAsync() => await _repository.FindAsync();
    
        public async Task<Player> GetAsync(Guid identity) => await _repository.GetAsync(identity);

        public async Task<Player> GetAsync(string email) => await _repository.GetAsync(document => document.Email == email); 

        public async Task RemoveAsync(Guid identity) => await _repository.DeleteAsync(identity);

        public async Task UpdateAsync(Player player) => await _repository.UpdateAsync(player);

        #endregion
    }
}
