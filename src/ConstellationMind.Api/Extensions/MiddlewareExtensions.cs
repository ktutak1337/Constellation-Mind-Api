using ConstellationMind.Api.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace ConstellationMind.Api.Extensions
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseErrorHandler(this IApplicationBuilder builder)
            => builder.UseMiddleware(typeof(ErrorHandlerMiddleware));
    }
}
