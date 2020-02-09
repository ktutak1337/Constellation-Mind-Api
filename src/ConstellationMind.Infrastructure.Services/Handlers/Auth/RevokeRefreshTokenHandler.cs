using System.Threading.Tasks;
using ConstellationMind.Infrastructure.Services.Commands.Auth;
using ConstellationMind.Infrastructure.Services.Services.Domains.Interfaces;
using ConstellationMind.Shared.Handlers.Interfaces;

namespace ConstellationMind.Infrastructure.Services.Handlers.Auth
{
    public class RevokeRefreshTokenHandler : ICommandHandler<RevokeRefreshToken>
    {
        private readonly IRefreshTokenService _refreshTokenService;

        public RevokeRefreshTokenHandler(IRefreshTokenService refreshTokenService)
        {
            _refreshTokenService = refreshTokenService;
        }
        public async Task HandleAsync(RevokeRefreshToken command) 
            => await _refreshTokenService.InvalidateAsync(command.RefreshToken);
    }
}
