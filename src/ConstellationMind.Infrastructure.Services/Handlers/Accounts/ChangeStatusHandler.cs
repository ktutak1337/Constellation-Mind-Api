using System.Threading.Tasks;
using ConstellationMind.Infrastructure.Services.Commands.Accounts;
using ConstellationMind.Infrastructure.Services.Services.Interfaces;
using ConstellationMind.Shared.Handlers.Interfaces;

namespace ConstellationMind.Infrastructure.Services.Handlers.Accounts
{
    public class ChangeStatusHandler : ICommandHandler<ChangeStatus>
    {
        private readonly IAccountService _accountService;

        public ChangeStatusHandler(IAccountService accountService) 
            => _accountService = accountService;

        public Task HandleAsync(ChangeStatus command)
            => _accountService.ChangeStatusAsync(command.PlayerId, command.IsActive);
    }
}
