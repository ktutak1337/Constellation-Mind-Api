using System.Reflection;
using Autofac;
using ConstellationMind.Infrastructure.Services.Authentication;
using ConstellationMind.Infrastructure.Services.Authentication.Interfaces;
using ConstellationMind.Infrastructure.Services.Domains;
using ConstellationMind.Infrastructure.Services.Services;
using ConstellationMind.Infrastructure.Services.Services.Interfaces;
using ConstellationMind.Shared.Types;
using Microsoft.AspNetCore.Identity;

namespace ConstellationMind.Infrastructure.IoC.Modules
{
    public class ServicesModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<PasswordService>()
                .As<IPasswordService>()
                .SingleInstance();  

            builder.RegisterType<PasswordHasher<IPasswordService>>()
                .As<IPasswordHasher<IPasswordService>>()
                .SingleInstance();

            builder.RegisterType<JwtProvider>()
                .As<IJwtProvider>()
                .SingleInstance();

           var assembly = typeof(PlayerService)
                .GetTypeInfo()
                .Assembly;

            builder.RegisterAssemblyTypes(assembly)
                   .Where(x => x.IsAssignableTo<IService>())
                   .AsImplementedInterfaces()
                   .InstancePerLifetimeScope();
        }
    }
}
