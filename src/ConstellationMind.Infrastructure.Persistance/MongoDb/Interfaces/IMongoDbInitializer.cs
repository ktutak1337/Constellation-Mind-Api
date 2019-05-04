using System.Threading.Tasks;

namespace ConstellationMind.Infrastructure.Persistance.MongoDb.Interfaces
{
    public interface IMongoDbInitializer
    {
         Task InitializeAsync();
         Task SeedAsync();
    }
}
