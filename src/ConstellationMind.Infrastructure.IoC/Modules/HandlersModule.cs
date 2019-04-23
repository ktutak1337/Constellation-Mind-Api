using System.Reflection;
using Autofac;
using ConstellationMind.Infrastructure.Services.DomainServices;
using ConstellationMind.Shared.Handlers.Interfaces;

namespace ConstellationMind.Infrastructure.IoC.Modules
{
    public class HandlersModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = typeof(PlayerService)
                .GetTypeInfo()
                .Assembly;

            builder.RegisterAssemblyTypes(assembly)
                   .AsClosedTypesOf(typeof(ICommandHandler<>))
                   .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(assembly)
                   .AsClosedTypesOf(typeof(IQueryHandler<,>))
                   .InstancePerLifetimeScope();
        }
    }
}
