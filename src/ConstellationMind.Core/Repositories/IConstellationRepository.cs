using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ConstellationMind.Core.Domain;
using ConstellationMind.Shared.Types;

namespace ConstellationMind.Core.Repositories
{
    public interface IConstellationRepository : IRepository
    {
        Task<Constellation> GetAsync(Guid identity); 
        Task<IEnumerable<Constellation>> GetAllAsync();
        Task AddAsync(Constellation constellation);
        Task UpdateAsync(Constellation constellation);
        Task RemoveAsync(Guid identity);
    }
}
