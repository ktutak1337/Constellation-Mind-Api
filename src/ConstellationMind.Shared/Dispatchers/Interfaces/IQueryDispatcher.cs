using System.Threading.Tasks;
using ConstellationMind.Shared.Types;

namespace ConstellationMind.Shared.Dispatchers.Interfaces
{
    public interface IQueryDispatcher
    {
        Task<TResult> QueryAsync<TResult>(IQuery<TResult> query);
    }
}
