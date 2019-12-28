using ConstellationMind.Shared.Dispatchers.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ConstellationMind.Api.Controllers
{
    [Route("")]
    public class HomeController : BaseController
    {
        public HomeController(IDispatcher dispatcher) : base(dispatcher) { }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Get() => Ok("Constellation Mind API");
    }
}
