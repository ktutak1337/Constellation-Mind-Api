using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ConstellationMind.Core.Domain;
using ConstellationMind.Core.Repositories;
using ConstellationMind.Infrastructure.Services.DomainServices.Interfaces;
using ConstellationMind.Infrastructure.Services.DTO;

namespace ConstellationMind.Infrastructure.Services.DomainServices
{
    public class PlayerService : IPlayerService
    {
        #region Fields
        private readonly IPlayerRepository _playerRepository;
        private readonly IMapper _mapper;

        #endregion

        #region Constructors
        public PlayerService(IPlayerRepository playerRepository, IMapper mapper)
        {
            _playerRepository = playerRepository;
            _mapper = mapper;            
        }
        
        #endregion
        
        #region Methods
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

        public async Task RegisterAsync(string email, string password, string nickname, string firstName = "")
        {
            var player = await _playerRepository.GetAsync(email);
            
            if(player != null) throw new Exception($"Player with email: '{email}' already exists.");
           
            player = new Player(email, password, nickname, firstName);
            await _playerRepository.AddAsync(player);
        }

        #endregion
    }
}
