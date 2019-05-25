using System;
using System.Threading.Tasks;
using ConstellationMind.Core.Domain;
using ConstellationMind.Core.Repositories;
using ConstellationMind.Infrastructure.Services.Extensions;
using ConstellationMind.Infrastructure.Services.Services.Interfaces;
using ConstellationMind.Shared.Exceptions;
using Microsoft.AspNetCore.Identity;

namespace ConstellationMind.Infrastructure.Services.Services
{
    public class AccountService : IAccountService
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly IScoreboardRepository _scoreboardRepository;
        private readonly IPasswordHasher<Player> _passwordHasher;

        public AccountService(IPlayerRepository playerRepository,
                              IScoreboardRepository scoreboardRepository, 
                              IPasswordHasher<Player> passwordHasher)
        {
            _playerRepository = playerRepository;
            _scoreboardRepository= scoreboardRepository;
            _passwordHasher = passwordHasher;
        }

        public async Task SignUpAsync(Guid identity, string email, string password, string nickname, string firstName = "")
        {
            var player = await _playerRepository.GetOrFailAsync(email);
           
            player = new Player(identity, email, nickname, firstName);
            player.SetPassword(password, _passwordHasher);

            await _playerRepository.AddAsync(player);
            await _scoreboardRepository.AddAsync(new PlayerScore(identity, nickname, player.Points));
        }

        public async Task SignInAsync(string email, string password)
        {
            var player = await _playerRepository.GetAsync(email);
            if (player != null && player.VerifyPassword(password, _passwordHasher)) return;

            throw new ConstellationMindException(ErrorCodes.InvalidCredentials, "Invalid credentials.");
        }

        public async Task ChangePasswordAsync(Guid playerId, string currentPassword, string newPassword)
        {
            var player = await _playerRepository.GetOrFailAsync(playerId);
            
            if (!player.VerifyPassword(currentPassword, _passwordHasher)) throw new ConstellationMindException(ErrorCodes.InvalidPassword, "Invalid password.");
            
            player.SetPassword(newPassword, _passwordHasher);
            await _playerRepository.UpdateAsync(player);
        }

    }
}
