using System.Threading.Tasks;
using ConstellationMind.Infrastructure.Persistance.MongoDb.Interfaces;
using ConstellationMind.Shared.Settings;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;

namespace ConstellationMind.Infrastructure.Persistance.MongoDb
{
    public class MongoDbInitializer : IMongoDbInitializer
    {
        #region Fields
        private static bool _initialized;
        private readonly bool _IsSeeded;
        private readonly IMongoDatabase _database;
        
        #endregion

        #region Constructors
        protected MongoDbInitializer() { }
        public MongoDbInitializer(IMongoDatabase database, MongoDbSettings settings)
        {
            _database = database;
            _IsSeeded = settings.Seed;
        }

        #endregion

        #region Methods
        public async Task InitializeAsync()
        {
            if (_initialized) return;
            
            RegisterConventions();

            _initialized = true;

            if (_IsSeeded) await SeedAsync();
        }

        public async Task SeedAsync()
        {
            var collections = await _database.ListCollectionsAsync();
            if(await collections.AnyAsync()) return;
        }

        private void RegisterConventions() => ConventionRegistry.Register("Conventions", new MongoDbConventions(), filter => true);

        #endregion
    }
}
