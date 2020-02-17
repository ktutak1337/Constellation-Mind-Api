using System;
using System.Threading.Tasks;
using ConstellationMind.Core.Domain;
using ConstellationMind.Core.Repositories;
using ConstellationMind.Infrastructure.Services.Authentication;
using ConstellationMind.Infrastructure.Services.Authentication.Interfaces;
using ConstellationMind.Infrastructure.Services.Extensions;
using ConstellationMind.Infrastructure.Services.Services.Domains.Interfaces;
using ConstellationMind.Infrastructure.Services.Services.Interfaces;
using ConstellationMind.Shared.Exceptions;
using ConstellationMind.Shared.Extensions;

namespace ConstellationMind.Infrastructure.Services.Services
{
    public class AccountService : IAccountService
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly IScoreboardRepository _scoreboardRepository;
        private readonly IPasswordService _passwordService;
        private readonly IJwtProvider _jwtProvider;
        private readonly IRefreshTokenService _refreshTokenService;

        public AccountService(IPlayerRepository playerRepository,
                              IScoreboardRepository scoreboardRepository, 
                              IPasswordService passwordService,
                              IJwtProvider jwtProvider,
                              IRefreshTokenService refreshTokenService)
        {
            _playerRepository = playerRepository;
            _scoreboardRepository= scoreboardRepository;
            _passwordService = passwordService;
            _jwtProvider = jwtProvider;
            _refreshTokenService = refreshTokenService;
        }

        public async Task SignUpAsync(Guid identity, string email, string password, string nickname, string firstName, string role)
        {
            if(password.IsEmpty()) 
                throw new ConstellationMindException(ErrorCodes.InvalidPassword, "Password can not be empty.");
            
            var player = await _playerRepository.GetOrFailAsync(email);
            var hashedPassword = _passwordService.HashPassword(password);
            
            player = new Player(identity, email, hashedPassword, nickname, firstName, Role.IsValid(role) ? role : Role.Player);
            
            await _playerRepository.AddAsync(player);
            
            if(player.Role == Role.Player)
                await _scoreboardRepository.AddAsync(new PlayerScore(identity, nickname, player.Points));
        }

        public async Task<Jwt> SignInAsync(string email, string password)
        {
            var player = await _playerRepository.GetAsync(email);
            
            if (player == null || !_passwordService.Verify(player.Password, password))
                throw new ConstellationMindException(ErrorCodes.InvalidCredentials, "You have entered invalid credentials.");

            var token = _jwtProvider.CreateToken(player.Identity.ToString("N"), player.Role);
            token.RefreshToken = await _refreshTokenService.CreateAsync(player.Identity);

            return token;
        }

        public async Task ChangePasswordAsync(Guid playerId, string currentPassword, string newPassword)
        {
            var player = await _playerRepository.GetOrFailAsync(playerId);
            
            if (!_passwordService.Verify(player.Password, currentPassword))
                throw new ConstellationMindException(ErrorCodes.InvalidCredentials, "You have entered invalid credentials.");
            
            var password = _passwordService.HashPassword(newPassword);
            player.SetPassword(password);
            
            await _playerRepository.UpdateAsync(player);
        }

        public async Task ChangeStatusAsync(Guid playerId, bool isActive)
        {
            var player = await _playerRepository.GetOrFailAsync(playerId);
            player.SetIsActive(isActive);
            
            await _playerRepository.UpdateAsync(player);
        }

        public async Task DeleteAccountAsync(Guid playerId)
        {
            await _playerRepository.RemoveAsync(playerId);
            await _scoreboardRepository.RemoveAsync(playerId);
        }
    }
}
