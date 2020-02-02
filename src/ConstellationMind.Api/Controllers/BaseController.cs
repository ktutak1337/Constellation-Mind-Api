using System;
using System.Collections.Generic;
using ConstellationMind.Shared.Dispatchers.Interfaces;
using ConstellationMind.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace ConstellationMind.Api.Controllers
{
    [Route("api/[controller]")]
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

        protected ActionResult<TData> Single<TData>(TData data)
        {
            if (data == null)
            {
                return NotFound();
            }
            
            return Ok(data);
        }

        protected ActionResult<IEnumerable<TData>> SelectMany<TData>(IEnumerable<TData> data)
        {
            if (data == null)
            {
                return NotFound();
            }

            return Ok(data);
        }
    }
}
