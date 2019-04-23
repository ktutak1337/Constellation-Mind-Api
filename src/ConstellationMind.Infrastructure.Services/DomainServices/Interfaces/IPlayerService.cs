using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ConstellationMind.Infrastructure.Services.DTO;

namespace ConstellationMind.Infrastructure.Services.DomainServices.Interfaces
{
    public interface IPlayerService
    {
        Task<PlayerDto> GetAsync(Guid identity);
        Task<PlayerDto> GetAsync(string email);
        Task<IEnumerable<PlayerDto>> GetPlayersAsync();
        Task RegisterAsync(string email, string password, string nickname, string firstName = "");
        Task LoginAsync(string email, string password);
    }
}
