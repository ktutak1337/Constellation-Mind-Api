using System.Threading.Tasks;
using ConstellationMind.Shared.Types;

namespace ConstellationMind.Shared.Handlers.Interfaces
{
    public interface ICommandHandler<TCommand> where TCommand : ICommand
    {
         Task HandleAsync(TCommand command);
    }
}
