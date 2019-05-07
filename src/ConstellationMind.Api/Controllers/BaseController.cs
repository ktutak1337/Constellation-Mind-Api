using System.Collections.Generic;
using ConstellationMind.Shared.Dispatchers.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ConstellationMind.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        protected readonly IDispatcher Dispatcher;

        protected BaseController(IDispatcher dispatcher)
        {
            Dispatcher = dispatcher;
        }

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
