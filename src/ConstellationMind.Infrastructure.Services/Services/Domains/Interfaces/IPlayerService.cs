using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ConstellationMind.Infrastructure.Services.DTO;
using ConstellationMind.Shared.Types;

namespace ConstellationMind.Infrastructure.Services.Domains.Interfaces
{
    public interface IPlayerService : IService
    {
        Task<PlayerDto> GetAsync(Guid identity);
        Task<IEnumerable<PlayerDto>> GetPlayersAsync();
        Task UpdatePlayerAsync(Guid identity, string email, string firstName, string nickname);
        Task UpdatePointsAsync(Guid identity, int addPoints);
    }
}
