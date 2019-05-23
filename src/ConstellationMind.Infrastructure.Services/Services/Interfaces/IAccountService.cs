using System;
using System.Threading.Tasks;
using ConstellationMind.Shared.Types;

namespace ConstellationMind.Infrastructure.Services.Services.Interfaces
{
    public interface IAccountService : IService
    {
         Task SignUpAsync(Guid identity, string email, string password, string nickname, string firstName = "");
         Task SignInAsync(string email, string password);
         Task ChangePasswordAsync(Guid playerId, string currentPassword, string newPassword);
    }
}
