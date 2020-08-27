using System.Threading.Tasks;
using ConstellationMind.Api.Attributes;
using ConstellationMind.Core.Domain;
using ConstellationMind.Infrastructure.Services.Commands.Auth;
using ConstellationMind.Infrastructure.Services.Services.Domains.Interfaces;
using ConstellationMind.Shared.Dispatchers.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConstellationMind.Api.Controllers
{
    public class TokensController : BaseController
    {
        private readonly IRefreshTokenService _refreshTokenService;

        public TokensController(IDispatcher dispatcher, IRefreshTokenService refreshTokenService)
            : base(dispatcher)
                => _refreshTokenService = refreshTokenService;

        /// <summary>
        /// Exchanges the Refresh Token for a new Access Token.
        /// </summary>
        /// <response code="200">Returns the newly created Access Token. The HTTP `201 [Created]` response code indicates that the request has succeeded.</response>
        /// <response code="400">The HTTP `400 [Bad Request]` response code indicates that the server cannot or will not process the request due to something that is perceived to be a client error.</response>
        /// <response code="401">The HTTP `401 [Unauthorized]` response code indicates that the request has not been applied because it lacks valid authentication credentials for the target resource.</response>
        /// <response code="404">The HTTP `404 [Not Found]` response code indicates that the server can not find the requested resource.</response>
        [HttpPost("access-tokens/refresh")]
        [Consumes("application/x-www-form-urlencoded")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [AllowAnonymous]
        public async Task<IActionResult> Post([FromForm] RefreshAccessToken command)
            => Ok(await _refreshTokenService.RefreshAccessTokenAsync(command.RefreshToken));

        /// <summary>
        /// Deactivetes Refresh Token.
        /// </summary>
        /// <response code="204">The HTTP `204 [No Content]` response code indicates that the server successfully processed the request and is not returning any content.</response>
        /// <response code="400">The HTTP `400 [Bad Request]` response code indicates that the server cannot or will not process the request due to something that is perceived to be a client error.</response>
        /// <response code="401">The HTTP `401 [Unauthorized]` response code indicates that the request has not been applied because it lacks valid authentication credentials for the target resource.</response>
        /// <response code="404">The HTTP `404 [Not Found]` response code indicates that the server can not find the requested resource.</response>
        [HttpPost("refresh-tokens/revoke")]
        [Consumes("application/x-www-form-urlencoded")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Allow(Role.Admin)]
        public async Task<IActionResult> Post([FromForm] RevokeRefreshToken command)
        {
            await Dispatcher.SendAsync(command);

            return NoContent();
        }
    }
}
