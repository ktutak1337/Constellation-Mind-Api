using System;
using System.Threading.Tasks;
using ConstellationMind.Api.Attributes;
using ConstellationMind.Core.Domain;
using ConstellationMind.Infrastructure.Services.Commands.Accounts;
using ConstellationMind.Infrastructure.Services.DTO;
using ConstellationMind.Infrastructure.Services.Queries.Players;
using ConstellationMind.Infrastructure.Services.Services.Interfaces;
using ConstellationMind.Shared.Dispatchers.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConstellationMind.Api.Controllers
{
    public class AccountsController : BaseController
    {
        private readonly IAccountService _accountService;
        public AccountsController(IDispatcher dispatcher, IAccountService accountService)
            : base(dispatcher)
        {
            _accountService = accountService;
        }

        /// <summary>
        /// Returns a unique `ID` for the currently logged player.
        /// </summary>
        /// <response code="200">Returns a unique `ID` for a single specific user. The HTTP `200 [OK]` response code indicates that the request has succeeded.</response>
        /// <response code="401">The HTTP `401 [Unauthorized]` response code indicates that the request has not been applied because it lacks valid authentication credentials for the target resource.</response>
        /// <response code="404">The HTTP `404 [Not Found]` response code indicates that the server can not find the requested resource.</response>
        [HttpGet("me")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Allow(Role.Admin, Role.Player)]
        public IActionResult Get()
            => Content($"Your Idntity: '{PlayerId}'.");

        /// <summary>
        /// Returns specific details for the currently logged player.
        /// </summary>
        /// <response code="200">Returns details information for a single specific user. The HTTP `200 [OK]` response code indicates that the request has succeeded.</response>
        /// <response code="401">The HTTP `401 [Unauthorized]` response code indicates that the request has not been applied because it lacks valid authentication credentials for the target resource.</response>
        /// <response code="404">The HTTP `404 [Not Found]` response code indicates that the server can not find the requested resource.</response>
        [HttpGet("me/details")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Allow(Role.Admin, Role.Player)]
        public async Task<IActionResult> Get(GetPlayer query)
        {
            query.Id = PlayerId;

            return Select<PlayerDto>(await Dispatcher.QueryAsync(query));
        }

        /// <summary>
        /// Creates a new player account.
        /// </summary>
        /// <response code="201">Returns the newly created player. The HTTP `201 [Created]` response code indicates that the request has succeeded.</response>
        /// <response code="400">The HTTP `400 [Bad Request]` response code indicates that the server cannot or will not process the request due to something that is perceived to be a client error.</response>
        /// <response code="404">The HTTP `404 [Not Found]` response code indicates that the server can not find the requested resource.</response>
        [HttpPost("sign-up")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [AllowAnonymous]
        public async Task<IActionResult> Post(SignUp command)
        {
            await Dispatcher.SendAsync(command);
        
            return CreatedAtAction("Get", "Players", new { Id = command.PlayerId }, command.PlayerId);
        }

        /// <summary>
        /// Sign in to the Constellation Mind.
        /// </summary>
        /// <response code="200">The HTTP `200 [OK]` response code indicates that the request has succeeded.</response>
        /// <response code="400">The HTTP `400 [Bad Request]` response code indicates that the server cannot or will not process the request due to something that is perceived to be a client error.</response>
        /// <response code="404">The HTTP `404 [Not Found]` response code indicates that the server can not find the requested resource.</response>
        [HttpPost("sign-in")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [AllowAnonymous]
        public async Task<IActionResult> Post(SignIn command)
            // temp solution
            => Ok(await _accountService.SignInAsync(command.Email, command.Password));
        
        /// <summary>
        /// Changes player password.
        /// </summary>
        /// <response code="204">The HTTP `204 [No Content]` response code indicates that the server successfully processed the request and is not returning any content.</response>
        /// <response code="400">The HTTP `400 [Bad Request]` response code indicates that the server cannot or will not process the request due to something that is perceived to be a client error.</response>
        /// <response code="401">The HTTP `401 [Unauthorized]` response code indicates that the request has not been applied because it lacks valid authentication credentials for the target resource.</response>
        /// <response code="404">The HTTP `404 [Not Found]` response code indicates that the server can not find the requested resource.</response>
        [HttpPut("me/password/change")]
        [Consumes("application/json")] 
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Allow(Role.Admin, Role.Player)]
        public async Task<IActionResult> Put(ChangePassword command)
        {
            command.PlayerId = PlayerId;

            await Dispatcher.SendAsync(command);

            return NoContent();
        }

        /// <summary>
        /// Deactivates or activates a specific player account.
        /// </summary>
        /// <param name="id">The unique player identifier.</param>
        /// <response code="204">The HTTP `204 [No Content]` response code indicates that the server successfully processed the request and is not returning any content.</response>
        /// <response code="400">The HTTP `400 [Bad Request]` response code indicates that the server cannot or will not process the request due to something that is perceived to be a client error.</response>
        /// <response code="401">The HTTP `401 [Unauthorized]` response code indicates that the request has not been applied because it lacks valid authentication credentials for the target resource.</response>
        /// <response code="404">The HTTP `404 [Not Found]` response code indicates that the server can not find the requested resource.</response>
        [HttpPut("{id}/status")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Allow(Role.Admin, Role.Player)]
        public async Task<IActionResult> Put(Guid id, ChangeStatus command)
        {
            command.PlayerId = id;

            await Dispatcher.SendAsync(command);

            return NoContent();
        }

        /// <summary>
        /// Deletes a specific player account.
        /// </summary>
        /// <param name="id">The unique player identifier.</param>
        /// <response code="204">The HTTP `204 [No Content]` response code indicates that the server successfully processed the request and is not returning any content.</response>
        /// <response code="400">The HTTP `400 [Bad Request]` response code indicates that the server cannot or will not process the request due to something that is perceived to be a client error.</response>
        /// <response code="401">The HTTP `401 [Unauthorized]`response code indicates that the request has not been applied because it lacks valid authentication credentials for the target resource.</response>
        /// <response code="403">The HTTP `403 [Forbidden]` response code indicates that the server understood the request but refuses to authorize it.</response>
        /// <response code="404">The HTTP `404 [Not Found]` response code indicates that the server can not find the requested resource.</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Allow(Role.Admin)]
        public async Task<IActionResult> Delete(Guid id, DeleteAccount command)
        {
            command.PlayerId = id;

            await Dispatcher.SendAsync(command);

            return NoContent();
        } 
    }
}
