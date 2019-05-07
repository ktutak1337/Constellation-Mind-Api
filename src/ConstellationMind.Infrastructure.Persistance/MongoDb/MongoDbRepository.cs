using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ConstellationMind.Infrastructure.Persistance.MongoDb.Interfaces;
using ConstellationMind.Shared.Types;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace ConstellationMind.Infrastructure.Persistance.MongoDb
{
    public class MongoDbRepository<TDocument> : IMongoDbRepository<TDocument> where TDocument: IIdentity
    {
        protected IMongoCollection<TDocument> Collection { get; }

        public MongoDbRepository(IMongoDatabase database, string collectionName) 
            => Collection = database.GetCollection<TDocument>(collectionName);

        public async Task<TDocument> GetAsync(Guid id) 
            => await GetAsync(document => document.Identity == id);

        public async Task<TDocument> GetAsync(Expression<Func<TDocument, bool>> predicate)
            => await Collection.Find(predicate).SingleOrDefaultAsync();

        public async Task<IEnumerable<TDocument>> FindAsync(Expression<Func<TDocument, bool>> predicate)
            => await Collection.Find(predicate).ToListAsync();

        public async Task<IEnumerable<TDocument>> FindAsync() => await Collection.AsQueryable().ToListAsync();
        
        public async Task AddAsync(TDocument document) => await Collection.InsertOneAsync(document);       

        public async Task UpdateAsync(TDocument document) 
            => await Collection.ReplaceOneAsync(doc => doc.Identity == document.Identity, document);

        public async Task DeleteAsync(Guid id) => await Collection.DeleteOneAsync(document => document.Identity == id);
    }
}
