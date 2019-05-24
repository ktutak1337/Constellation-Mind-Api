using System.Threading.Tasks;
using ConstellationMind.Infrastructure.Services.Commands.Accounts;
using ConstellationMind.Infrastructure.Services.Services.Interfaces;
using ConstellationMind.Shared.Handlers.Interfaces;

namespace ConstellationMind.Infrastructure.Services.Handlers.Accounts
{
    public class SignInHandler : ICommandHandler<SignIn>
    {
        private readonly IAccountService _accountService;
        public SignInHandler(IAccountService accountService) 
            => _accountService = accountService;

        public async Task HandleAsync(SignIn command)
            => await _accountService.SignInAsync(command.Email, command.Password);
    }
}
