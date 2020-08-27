using System.Threading.Tasks;
using Autofac;
using ConstellationMind.Shared.Dispatchers.Interfaces;
using ConstellationMind.Shared.Handlers.Interfaces;
using ConstellationMind.Shared.Types;

namespace ConstellationMind.Shared.Dispatchers
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly IComponentContext _context;

        public CommandDispatcher(IComponentContext context) 
            => _context = context;

        public async Task SendAsync<TCommand>(TCommand command) where TCommand : ICommand
        {
            var handler = _context.Resolve<ICommandHandler<TCommand>>();
            await handler.HandleAsync(command);
        }
    }
}
