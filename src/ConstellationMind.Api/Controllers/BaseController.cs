using System;
using ConstellationMind.Shared.Dispatchers.Interfaces;
using ConstellationMind.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace ConstellationMind.Api.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        protected readonly IDispatcher Dispatcher;
        protected Guid PlayerId
            => (User?.Identity?.Name).IsEmpty() 
                ? Guid.Empty 
                : Guid.Parse(User.Identity.Name);

        protected BaseController(IDispatcher dispatcher) 
            => Dispatcher = dispatcher;

        protected IActionResult Select<TData>(TData data)
            where TData: class
                => data is null ? NotFound()
                                : Ok(data) as IActionResult;
    }
}
