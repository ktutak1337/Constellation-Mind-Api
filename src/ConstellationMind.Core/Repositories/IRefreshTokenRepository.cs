using System.Threading.Tasks;
using ConstellationMind.Core.Domain;
using ConstellationMind.Shared.Types;

namespace ConstellationMind.Core.Repositories
{
    public interface IRefreshTokenRepository : IRepository
    {
        Task<RefreshToken> GetAsync(string token);
        Task AddAsync(RefreshToken token);
        Task UpdateAsync(RefreshToken token);
    }
}
