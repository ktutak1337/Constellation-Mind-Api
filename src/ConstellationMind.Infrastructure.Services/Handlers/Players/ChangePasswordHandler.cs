using System.Threading.Tasks;
using ConstellationMind.Infrastructure.Services.Commands;
using ConstellationMind.Infrastructure.Services.Services.Interfaces;
using ConstellationMind.Shared.Handlers.Interfaces;

namespace ConstellationMind.Infrastructure.Services.Handlers.Players
{
    public class ChangePasswordHandler : ICommandHandler<ChangePassword>
    {
        private readonly IAccountService _accountService;

        public ChangePasswordHandler(IAccountService accountService) 
            => _accountService = accountService;

        public async Task HandleAsync(ChangePassword command)
            => await _accountService.ChangePasswordAsync(command.PlayerId, command.CurrentPassword, command.NewPassword);
    }
}
