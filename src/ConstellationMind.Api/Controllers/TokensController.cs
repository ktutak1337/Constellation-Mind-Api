using System.Threading.Tasks;
using ConstellationMind.Api.Attributes;
using ConstellationMind.Core.Domain;
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

        // POST api/tokens/refresh-tokens/revoke
        [HttpPost("refresh-tokens/revoke")]
        [Consumes("application/x-www-form-urlencoded")]
        [Allow(Role.Admin)]
        public async Task<IActionResult> Post([FromForm] RevokeRefreshToken command)
        {
            await Dispatcher.SendAsync(command);

            return NoContent();
        }
    }
}
