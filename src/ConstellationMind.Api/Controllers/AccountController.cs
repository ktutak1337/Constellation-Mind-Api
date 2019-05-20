using System.Threading.Tasks;
using ConstellationMind.Infrastructure.Services.Commands.Players;
using ConstellationMind.Shared.Dispatchers.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ConstellationMind.Api.Controllers
{
    public class AccountController : BaseController
    {
        public AccountController(IDispatcher dispatcher) : base(dispatcher)
        {

        }
        
        // PUT api/account/me/password
        [HttpPut]
        [Route("me/password")]
        public async Task<IActionResult> Put([FromBody] ChangePassword command)
        {
            await Dispatcher.SendAsync(command);

            return NoContent();
        }
    }
}
