using System.Threading.Tasks;
using Autofac;
using ConstellationMind.Shared.Dispatchers.Interfaces;
using ConstellationMind.Shared.Handlers.Interfaces;
using ConstellationMind.Shared.Types;

namespace ConstellationMind.Shared.Dispatchers
{
    public class QueryDispatcher : IQueryDispatcher
    {
        private readonly IComponentContext _context;

        public QueryDispatcher(IComponentContext context) 
            => _context = context;

        public async Task<TResult> QueryAsync<TResult>(IQuery<TResult> query)
        {
            var handlerType = typeof(IQueryHandler<,>).MakeGenericType(query.GetType(), typeof(TResult));

            return await ((dynamic) _context.Resolve(handlerType))
                .HandleAsync((dynamic)query);
        }
    }
}
