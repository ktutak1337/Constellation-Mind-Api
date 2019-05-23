using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ConstellationMind.Core.Domain;
using ConstellationMind.Core.Repositories;
using ConstellationMind.Infrastructure.Services.DomainServices.Interfaces;
using ConstellationMind.Infrastructure.Services.DTO;
using ConstellationMind.Infrastructure.Services.Extensions;
using ConstellationMind.Shared.Extensions;
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
            => (await _playerRepository.GetAsync(identity))
                .MapSingle<Player, PlayerDto>(_mapper);
 
        public async Task<IEnumerable<PlayerDto>> GetPlayersAsync()
            => (await _playerRepository.GetAllAsync())
                .MapCollection<Player, PlayerDto>(_mapper);

        public async Task UpdatePointsAsync(Guid identity, int addPoints)
        {
            var player = await _playerRepository.GetOrFailAsync(identity);
        
            player.UpdatePoints(addPoints);

            await _playerRepository.UpdateAsync(player);
            await _scoreboardRepository.UpdateAsync(new PlayerScore(player.Identity, player.Nickname, player.Points));
        }

        public async Task DeleteAsync(Guid identity)
        {
            await _playerRepository.RemoveAsync(identity);
            await _scoreboardRepository.RemoveAsync(identity);
        } 

        #endregion
    }
}
