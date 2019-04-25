using System.Reflection;
using Autofac;
using ConstellationMind.Infrastructure.Persistance.Repositories;
using ConstellationMind.Shared.Types;

namespace ConstellationMind.Infrastructure.IoC.Modules
{
    public class RepositoriesModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
           var assembly = typeof(PlayerRepository)
                .GetTypeInfo()
                .Assembly;

            builder.RegisterAssemblyTypes(assembly)
                   .Where(x => x.IsAssignableTo<IRepository>())
                   .AsImplementedInterfaces()
                   .InstancePerLifetimeScope();
        }
    }
}
