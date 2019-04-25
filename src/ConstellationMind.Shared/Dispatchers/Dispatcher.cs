using System.Threading.Tasks;
using ConstellationMind.Shared.Dispatchers.Interfaces;
using ConstellationMind.Shared.Types;

namespace ConstellationMind.Shared.Dispatchers
{
    public class Dispatcher : IDispatcher
    {
        #region Fields
        private readonly IQueryDispatcher _queryDispatcher;
        private readonly ICommandDispatcher _commandDispatcher;

        #endregion

        #region Constructors
        public Dispatcher(ICommandDispatcher commandDispatcher,IQueryDispatcher queryDispatcher)
        {
            _commandDispatcher = commandDispatcher;
            _queryDispatcher = queryDispatcher;
        }

        #endregion

        #region Methods
        public async Task<TResult> QueryAsync<TResult>(IQuery<TResult> query) 
            => await _queryDispatcher.QueryAsync<TResult>(query);

        public async Task SendAsync<TCommand>(TCommand command) where TCommand : ICommand 
            => await _commandDispatcher.SendAsync(command);

        #endregion    
    }
}
