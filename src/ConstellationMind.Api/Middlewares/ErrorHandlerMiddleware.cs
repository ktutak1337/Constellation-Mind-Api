using System;
using System.Net;
using System.Threading.Tasks;
using ConstellationMind.Shared.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace ConstellationMind.Api.Middlewares
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlerMiddleware> _logger;

        public ErrorHandlerMiddleware(RequestDelegate next, ILoggerFactory loggerFactory) 
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
             _logger = loggerFactory?.CreateLogger<ErrorHandlerMiddleware>() ?? throw new ArgumentNullException(nameof(loggerFactory));
        }
            
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message);
                await HandleErrorAsync(context, exception);
            }
        }

        private static Task HandleErrorAsync(HttpContext context, Exception exception)
        {
            var errorCode = "Error";
            var message = exception.Message;
            var statusCode = HttpStatusCode.BadRequest;
            
            switch(exception)
            {
                case ConstellationMindException ex:
                    errorCode = ex.Code;
                    message = ex.Message;
                    break;
            }

            var response = new { code = errorCode, message = message };
            var result = JsonConvert.SerializeObject(response);
            
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;
            return context.Response.WriteAsync(result);
        }
    }
}
