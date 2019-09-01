using System.Text;
using ConstellationMind.Shared.Extensions;
using ConstellationMind.Shared.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace ConstellationMind.Api.Extensions
{
    public static class AuthExtensions
    {
        public static void AddJwt(this IServiceCollection services)
        {
            IConfiguration configuration;

            using (var serviceProvider = services.BuildServiceProvider())
            {
                configuration = serviceProvider.GetService<IConfiguration>();
            }
            
            var _settings = configuration.GetSettings<JwtSettings>("jwt");

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(cfg =>
                {
                    cfg.TokenValidationParameters = new TokenValidationParameters
                    {
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.SecretKey)),
                        ValidIssuer = _settings.Issuer,
                        ValidAudience = _settings.ValidAudience,
                        ValidateAudience = _settings.ValidateAudience,
                        ValidateLifetime = _settings.ValidateLifetime
                    };
                });
        }
    }
}
