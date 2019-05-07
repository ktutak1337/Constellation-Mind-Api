using Autofac;
using Microsoft.Extensions.Configuration;
using ConstellationMind.Infrastructure.Services.Mappers;
using ConstellationMind.Infrastructure.IoC.Modules;

namespace ConstellationMind.Infrastructure.IoC
{
    public class ContainerModule: Autofac.Module
    {
        private readonly IConfiguration _configuration;

        public ContainerModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterInstance(AutoMapperConfig.Initialize())
                .SingleInstance();

            builder.RegisterModule<DispachersModule>();
            builder.RegisterModule<HandlersModule>();    
            builder.RegisterModule<RepositoriesModule>();    
            builder.RegisterModule<ServicesModule>();    
            builder.RegisterModule(new SettingsModule(_configuration));
            builder.RegisterModule<MongoDbModule>();        
        }          
    }
}
