using System.Threading.Tasks;
using ConstellationMind.Shared.Types;

namespace ConstellationMind.Shared.Handlers.Interfaces
{
    public interface IQueryHandler<TQuery,TResult> where TQuery : IQuery<TResult>
    {
         Task<TResult> HandleAsync(TQuery query);
    }
}
