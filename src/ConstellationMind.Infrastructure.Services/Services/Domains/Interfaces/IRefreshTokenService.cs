using System;
using System.Threading.Tasks;
using ConstellationMind.Infrastructure.Services.Authentication;
using ConstellationMind.Shared.Types;

namespace ConstellationMind.Infrastructure.Services.Services.Domains.Interfaces
{
    public interface IRefreshTokenService : IService
    {
        Task<string> CreateAsync(Guid playerId);
        Task<Jwt> RefreshAccessTokenAsync(string refreshToken);
        Task InvalidateAsync(string refreshToken);
    }
}
