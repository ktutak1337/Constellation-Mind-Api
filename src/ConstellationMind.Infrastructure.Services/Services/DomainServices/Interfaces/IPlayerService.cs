using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ConstellationMind.Infrastructure.Services.DTO;
using ConstellationMind.Shared.Types;

namespace ConstellationMind.Infrastructure.Services.DomainServices.Interfaces
{
    public interface IPlayerService : IService
    {
        Task<PlayerDto> GetAsync(Guid identity);
        Task<IEnumerable<PlayerDto>> GetPlayersAsync();
        Task UpdatePointsAsync(Guid identity, int addPoints);
        Task DeleteAsync(Guid identity);
    }
}
