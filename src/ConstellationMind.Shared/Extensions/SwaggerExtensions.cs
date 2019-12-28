using ConstellationMind.Shared.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace ConstellationMind.Shared.Extensions
{
    public static class SwaggerExtensions
    {
        private static readonly string _swaggerName = "swagger";
        public static IServiceCollection AddSwaggerDocs(this IServiceCollection services)
        {
            SwaggerSettings settings;
            
            using (var serviceProvider = services.BuildServiceProvider())
            {
                var configuration = serviceProvider.GetService<IConfiguration>();
                services.Configure<SwaggerSettings>(configuration.GetSection(_swaggerName));
                settings = configuration.GetSettings<SwaggerSettings>(_swaggerName);
            }

            if (!settings.Enabled)
                return services;

            return services.AddSwaggerGen(setup => 
                setup.SwaggerDoc(settings.DocumentName, new OpenApiInfo { Title = settings.Title, Version = settings.Version }));
        }

          public static IApplicationBuilder UseSwaggerDocs(this IApplicationBuilder builder)
        {
            var settings = builder.ApplicationServices.GetService<IConfiguration>()
                .GetSettings<SwaggerSettings>(_swaggerName);
            
            if (!settings.Enabled)
                return builder;

            var routePrefix = settings.RoutePrefix.IsEmpty() ? _swaggerName : settings.RoutePrefix;

            builder.UseStaticFiles()
                .UseSwagger(setup => setup.RouteTemplate = routePrefix + "/{documentName}/swagger.json");

            return builder.UseSwaggerUI(setup =>
                {
                    setup.SwaggerEndpoint($"/{routePrefix}/{settings.DocumentName}/{_swaggerName}.json", settings.Title);
                    setup.RoutePrefix = routePrefix;
                });
        }
    }
}
