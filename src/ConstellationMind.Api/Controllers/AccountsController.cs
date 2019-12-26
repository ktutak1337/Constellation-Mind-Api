using System.Threading.Tasks;
using ConstellationMind.Infrastructure.Services.Commands.Accounts;
using ConstellationMind.Infrastructure.Services.Services.Interfaces;
using ConstellationMind.Shared.Dispatchers.Interfaces;
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

        // POST api/accounts/sign-up
        [HttpPost("sign-up")]
        public async Task<IActionResult> Post([FromBody] SignUp command)
        {
            await Dispatcher.SendAsync(command);
        
            return CreatedAtAction("Get", "Players", new { Id = command.PlayerId }, command.PlayerId);
        }

        // POST api/accounts/sign-in
        [HttpPost("sign-in")]
        public async Task<IActionResult> Post([FromBody] SignIn command)
            // temp solution
            => Ok(await _accountService.SignInAsync(command.Email, command.Password));
        
        // PUT api/accounts/me/password
        [HttpPut]
        [Route("me/password")]
        public async Task<IActionResult> Put([FromBody] ChangePassword command)
        {
            await Dispatcher.SendAsync(command);

            return NoContent();
        }
    }
}
