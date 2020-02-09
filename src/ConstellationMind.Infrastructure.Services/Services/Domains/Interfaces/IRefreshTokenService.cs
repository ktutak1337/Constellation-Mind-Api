using System;
using System.Threading.Tasks;
using ConstellationMind.Shared.Types;

namespace ConstellationMind.Infrastructure.Services.Services.Domains.Interfaces
{
    public interface IRefreshTokenService : IService
    {
        Task<string> CreateAsync(Guid playerId);
        Task InvalidateAsync(string refreshToken);
    }
}
