using System.Threading.Tasks;
using ConstellationMind.Infrastructure.Services.Commands.Auth;
using ConstellationMind.Infrastructure.Services.Services.Domains.Interfaces;
using ConstellationMind.Shared.Dispatchers.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ConstellationMind.Api.Controllers
{
    public class TokensController : BaseController
    {
        private readonly IRefreshTokenService _refreshTokenService;

        public TokensController(IDispatcher dispatcher, IRefreshTokenService refreshTokenService) : base(dispatcher)
        {
            _refreshTokenService = refreshTokenService;
        }

        // POST api/tokens/access-tokens/refresh
        [HttpPost("access-tokens/refresh")]
        [Consumes("application/x-www-form-urlencoded")]
        [AllowAnonymous]
        public async Task<IActionResult> Post([FromForm] RefreshAccessToken command)
            => Ok(await _refreshTokenService.RefreshAccessTokenAsync(command.RefreshToken));
    }
}
