using Autofac;
using ConstellationMind.Shared.Dispatchers;
using ConstellationMind.Shared.Dispatchers.Interfaces;

namespace ConstellationMind.Infrastructure.IoC.Modules
{
    public class DispachersModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CommandDispatcher>().As<ICommandDispatcher>();
            builder.RegisterType<Dispatcher>().As<IDispatcher>();
            builder.RegisterType<QueryDispatcher>().As<IQueryDispatcher>();
        }
    }
}
