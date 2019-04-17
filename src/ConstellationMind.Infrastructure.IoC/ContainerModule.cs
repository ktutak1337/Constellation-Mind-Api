using Autofac;
using Microsoft.Extensions.Configuration;
using ConstellationMind.Infrastructure.Services.Mappers;

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
        }          
    }
}
