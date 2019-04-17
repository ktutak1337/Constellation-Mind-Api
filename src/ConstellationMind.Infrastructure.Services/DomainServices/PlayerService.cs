using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ConstellationMind.Infrastructure.Services.DomainServices.Interfaces;
using ConstellationMind.Infrastructure.Services.DTO;

namespace ConstellationMind.Infrastructure.Services.DomainServices
{
    public class PlayerService : IPlayerService
    {
        public Task<PlayerDto> GetAsync(Guid identity)
        {
            throw new NotImplementedException();
        }

        public Task<PlayerDto> GetAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PlayerDto>> GetPlayersAsync()
        {
            throw new NotImplementedException();
        }

        public Task LoginAsync(string email, string password)
        {
            throw new NotImplementedException();
        }

        public Task RegisterAsync(Guid identity, string email, string password, string nickname, string firstName = "")
        {
            throw new NotImplementedException();
        }
    }
}
