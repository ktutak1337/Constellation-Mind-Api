using System.Reflection;
using Autofac;
using ConstellationMind.Infrastructure.IoC.Helpers;
using ConstellationMind.Infrastructure.Services.Commands.Players;
using FluentValidation;

namespace ConstellationMind.Infrastructure.IoC.Modules
{
    public class ValidationModule: Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = typeof(CreatePlayer)
                .GetTypeInfo()
                .Assembly;

            builder.RegisterAssemblyTypes(assembly)
                .Where(t => t.Name.EndsWith("Validator"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterType<ValidatorFactory>()
                .As<IValidatorFactory>()
                .SingleInstance();
        }
    }
}
