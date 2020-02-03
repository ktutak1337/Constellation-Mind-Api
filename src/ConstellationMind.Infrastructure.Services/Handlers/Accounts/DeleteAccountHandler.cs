using System.Threading.Tasks;
using ConstellationMind.Infrastructure.Services.Commands.Accounts;
using ConstellationMind.Infrastructure.Services.Services.Interfaces;
using ConstellationMind.Shared.Handlers.Interfaces;

namespace ConstellationMind.Infrastructure.Services.Handlers.Accounts
{
    public class DeleteAccountHandler: ICommandHandler<DeleteAccount>
    {
        private readonly IAccountService _accountService;

        public DeleteAccountHandler(IAccountService accountService) 
            => _accountService = accountService;
        public Task HandleAsync(DeleteAccount command)
            => _accountService.DeleteAccountAsync(command.PlayerId);
    }
}
