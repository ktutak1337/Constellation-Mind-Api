using System;
using System.Threading.Tasks;
using ConstellationMind.Core.Domain;
using ConstellationMind.Core.Repositories;
using ConstellationMind.Infrastructure.Services.Services.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace ConstellationMind.Infrastructure.Services.Services
{
    public class AccountService : IAccountService
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly IPasswordHasher<Player> _passwordHasher;

        public AccountService(IPlayerRepository playerRepository, IPasswordHasher<Player> passwordHasher)
        {
            _playerRepository = playerRepository;
            _passwordHasher = passwordHasher;
        }

        public async Task ChangePasswordAsync(Guid playerId, string currentPassword, string newPassword)
        {
            var player = await _playerRepository.GetAsync(playerId);
            
            if (player == null) throw new Exception($"Player with id: '{playerId}' was not found.");
            
            if (!player.VerifyPassword(currentPassword, _passwordHasher)) throw new Exception("Invalid password.");
            
            player.SetPassword(newPassword, _passwordHasher);
            await _playerRepository.UpdateAsync(player);
        }
    }
}
