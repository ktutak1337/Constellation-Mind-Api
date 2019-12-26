using System.Reflection;
using Autofac;
using ConstellationMind.Infrastructure.Services.Authentication;
using ConstellationMind.Infrastructure.Services.Authentication.Interfaces;
using ConstellationMind.Infrastructure.Services.DomainServices;
using ConstellationMind.Shared.Types;

namespace ConstellationMind.Infrastructure.IoC.Modules
{
    public class ServicesModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
           var assembly = typeof(PlayerService)
                .GetTypeInfo()
                .Assembly;

            builder.RegisterAssemblyTypes(assembly)
                   .Where(x => x.IsAssignableTo<IService>())
                   .AsImplementedInterfaces()
                   .InstancePerLifetimeScope();

            builder.RegisterType<JwtProvider>()
                .As<IJwtProvider>()
                .SingleInstance();       
        }
    }
}
