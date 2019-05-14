using Autofac;
using ConstellationMind.Core.Domain;
using ConstellationMind.Infrastructure.Persistance.MongoDb;
using ConstellationMind.Infrastructure.Persistance.MongoDb.Interfaces;
using ConstellationMind.Shared.Settings;
using MongoDB.Driver;

namespace ConstellationMind.Infrastructure.IoC.Modules
{
    public class MongoDbModule: Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(context => 
                new MongoClient(connectionString: context.Resolve<MongoDbSettings>().ConnectionString))
                    .SingleInstance();

            builder.Register(context =>
            {
                var client = context.Resolve<MongoClient>();
                return client.GetDatabase(name: context.Resolve<MongoDbSettings>().Database);
            }).As<IMongoDatabase>();

            builder.RegisterType<MongoDbInitializer>()
                .As<IMongoDbInitializer>()
                .InstancePerLifetimeScope();

            builder.Register(context => 
                new MongoDbRepository<Player>(database: context.Resolve<IMongoDatabase>(), collectionName: "Players"))
                    .As<IMongoDbRepository<Player>>()
                    .InstancePerLifetimeScope();

            builder.Register(context => 
                new MongoDbRepository<PlayerScore>(database: context.Resolve<IMongoDatabase>(), collectionName: "Scoreboard"))
                    .As<IMongoDbRepository<PlayerScore>>()
                    .InstancePerLifetimeScope();            
        }
    }
}
