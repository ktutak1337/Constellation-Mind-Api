using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ConstellationMind.Core.Domain;
using ConstellationMind.Core.Repositories;
using ConstellationMind.Infrastructure.Services.DomainServices.Interfaces;
using ConstellationMind.Infrastructure.Services.DTO;
using Microsoft.AspNetCore.Identity;

namespace ConstellationMind.Infrastructure.Services.DomainServices
{
    public class PlayerService : IPlayerService
    {
        #region Fields
        private readonly IPlayerRepository _playerRepository;
        private readonly IScoreboardRepository _scoreboardRepository;
        private readonly IPasswordHasher<Player> _passwordHasher;
        private readonly IMapper _mapper;

        #endregion

        #region Constructors
        public PlayerService(IPlayerRepository playerRepository,
                             IScoreboardRepository scoreboardRepository,
                             IPasswordHasher<Player> passwordHasher,
                             IMapper mapper)
        {
            _playerRepository = playerRepository;
            _scoreboardRepository = scoreboardRepository;
            _passwordHasher = passwordHasher;
            _mapper = mapper;            
        }

        #endregion

        #region Methods
        public async Task<PlayerDto> GetAsync(Guid identity)
        {
            var player = await _playerRepository.GetAsync(identity);

            return player == null 
                ? null 
                : _mapper.Map<Player, PlayerDto>(player);
        }
        
        public async Task<IEnumerable<PlayerDto>> GetPlayersAsync()
        {
            var players = await _playerRepository.GetAllAsync();
         
            return players == null 
                ? null 
                : players.Select(player => _mapper.Map<Player, PlayerDto>(player));
        }

        public Task LoginAsync(string email, string password)
        {
            throw new NotImplementedException();
        }

        public async Task RegisterAsync(Guid identity, string email, string password, string nickname, string firstName = "")
        {
            var player = await _playerRepository.GetAsync(email);
            
            if(player != null) throw new Exception($"Player with email: '{email}' already exists.");
           
            player = new Player(identity, email, nickname, firstName);
            player.SetPassword(password, _passwordHasher);

            await _playerRepository.AddAsync(player);
            await _scoreboardRepository.AddAsync(new PlayerScore(identity, nickname, player.Points));
        }

        public async Task UpdatePointsAsync(Guid identity, int addPoints)
        {
            var player = await _playerRepository.GetAsync(identity);
            
            if(player == null) throw new Exception($"Player with id: '{identity}' does not exists.");
           
            player.UpdatePoints(addPoints);

            await _playerRepository.UpdateAsync(player);
            await _scoreboardRepository.UpdateAsync(new PlayerScore(player.Identity, player.Nickname, player.Points));
        }

        public async Task DeleteAsync(Guid identity) 
            => await _playerRepository.RemoveAsync(identity);

        #endregion
    }
}
