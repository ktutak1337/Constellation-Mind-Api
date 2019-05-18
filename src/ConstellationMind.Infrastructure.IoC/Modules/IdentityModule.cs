using Autofac;
using ConstellationMind.Core.Domain;
using Microsoft.AspNetCore.Identity;

namespace ConstellationMind.Infrastructure.IoC.Modules
{
    public class IdentityModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<PasswordHasher<Player>>()
                .As<IPasswordHasher<Player>>();
        }
    }
}
