using System.Threading.Tasks;
using ConstellationMind.Shared.Types;

namespace ConstellationMind.Shared.Dispatchers.Interfaces
{
    public interface ICommandDispatcher
    {
        Task SendAsync<TCommand>(TCommand command) where TCommand : ICommand;    
    }
}
