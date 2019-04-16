using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ConstellationMind.Core.Domain;

namespace ConstellationMind.Core.Repositories
{
    public interface IPlayerRepository
    {
        Task<Player> GetAsync(Guid identity); 
        Task<Player> GetAsync(string email);
        Task<IEnumerable<Player>> GetAllAsync();
        Task AddAsync(Player player);
        Task UpdateAsync(Player player);
        Task RemoveAsync(Guid identity);
    }
}
