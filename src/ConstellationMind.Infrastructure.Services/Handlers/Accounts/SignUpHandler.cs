using System;
using System.Threading.Tasks;
using ConstellationMind.Infrastructure.Services.Commands.Accounts;
using ConstellationMind.Infrastructure.Services.Services.Interfaces;
using ConstellationMind.Shared.Handlers.Interfaces;

namespace ConstellationMind.Infrastructure.Services.Handlers.Accounts
{
    public class SignUpHandler: ICommandHandler<SignUp>
    {
        private readonly IAccountService _accountService;

        public SignUpHandler(IAccountService accountService) 
            => _accountService = accountService;

        public async Task HandleAsync(SignUp command)
            => await _accountService
                .SignUpAsync(command.PlayerId = Guid.NewGuid(), command.Email, command.Password, command.Nickname, command.FirstName, command.Role);
    }
}
