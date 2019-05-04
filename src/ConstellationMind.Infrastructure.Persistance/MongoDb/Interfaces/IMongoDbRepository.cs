using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ConstellationMind.Shared.Types;

namespace ConstellationMind.Infrastructure.Persistance.MongoDb.Interfaces
{
    public interface IMongoDbRepository<TDocument> where TDocument: IIdentity
    {
         Task<TDocument> GetAsync(Guid id);
         Task<TDocument> GetAsync(Expression<Func<TDocument, bool>> predicate);
         Task<IEnumerable<TDocument>> FindAsync(Expression<Func<TDocument, bool>> predicate);
         Task<IEnumerable<TDocument>> FindAsync();
         Task AddAsync(TDocument document);
         Task UpdateAsync(TDocument document);
         Task DeleteAsync(Guid id);
    }
}
