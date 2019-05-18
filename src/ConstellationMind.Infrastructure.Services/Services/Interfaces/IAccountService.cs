using System;
using System.Threading.Tasks;
using ConstellationMind.Shared.Types;

namespace ConstellationMind.Infrastructure.Services.Services.Interfaces
{
    public interface IAccountService : IService
    {
         Task ChangePasswordAsync(Guid playerId, string currentPassword, string newPassword);
    }
}
