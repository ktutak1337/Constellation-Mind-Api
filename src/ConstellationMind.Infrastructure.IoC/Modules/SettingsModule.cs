using Autofac;
using ConstellationMind.Shared.Extensions;
using ConstellationMind.Shared.Settings;
using Microsoft.Extensions.Configuration;

namespace ConstellationMind.Infrastructure.IoC.Modules
{
    public class SettingsModule : Autofac.Module
    {
        private readonly IConfiguration _configuration;

        public SettingsModule(IConfiguration configuration) 
            => _configuration = configuration;

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterInstance(_configuration.GetSettings<AppSettings>("app"))
                .SingleInstance();

            builder.RegisterInstance(_configuration.GetSettings<MongoDbSettings>("mongoDb"))
                .SingleInstance();

            builder.RegisterInstance(_configuration.GetSettings<JwtSettings>("jwt"))
                .SingleInstance();    
        }
    }
}
