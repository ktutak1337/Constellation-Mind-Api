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
        Task RegisterAsync(Guid identity, string email, string password, string nickname, string firstName = "");
        Task UpdatePointsAsync(Guid identity, int addPoints);
        Task LoginAsync(string email, string password);
        Task DeleteAsync(Guid identity);
    }
}
