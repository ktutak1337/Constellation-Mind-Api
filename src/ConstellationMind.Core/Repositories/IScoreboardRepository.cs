using System.Collections.Generic;
using System.Threading.Tasks;
using ConstellationMind.Core.Domain;
using ConstellationMind.Shared.Types;

namespace ConstellationMind.Core.Repositories
{
    public interface IScoreboardRepository : IRepository
    {
        Task<IEnumerable<PlayerScore>> GetAllAsync();
        Task AddAsync(PlayerScore playerScore);
        Task UpdateAsync(PlayerScore playerScore);
    }
}
