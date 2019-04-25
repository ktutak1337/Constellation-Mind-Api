using System.Threading.Tasks;
using ConstellationMind.Shared.Types;

namespace ConstellationMind.Shared.Dispatchers.Interfaces
{
    public interface IDispatcher
    {
        Task SendAsync<TCommand>(TCommand command) where TCommand : ICommand;
        Task<TResult> QueryAsync<TResult>(IQuery<TResult> query);
    }
}
