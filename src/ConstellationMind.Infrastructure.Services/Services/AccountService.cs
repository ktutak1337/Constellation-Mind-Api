using System;
using System.Threading.Tasks;
using ConstellationMind.Core.Domain;
using ConstellationMind.Core.Repositories;
using ConstellationMind.Infrastructure.Services.Authentication;
using ConstellationMind.Infrastructure.Services.Authentication.Interfaces;
using ConstellationMind.Infrastructure.Services.Extensions;
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

        public AccountService(IPlayerRepository playerRepository,
                              IScoreboardRepository scoreboardRepository, 
                              IPasswordService passwordService,
                              IJwtProvider jwtProvider)
        {
            _playerRepository = playerRepository;
            _scoreboardRepository= scoreboardRepository;
            _passwordService = passwordService;
            _jwtProvider = jwtProvider;
        }

        public async Task SignUpAsync(Guid identity, string email, string password, string nickname, string firstName, string role = Role.Player)
        {
            if(password.IsEmpty()) 
                throw new ConstellationMindException(ErrorCodes.InvalidPassword, "Password can not be empty.");
            
            var player = await _playerRepository.GetOrFailAsync(email);
            var hashedPassword = _passwordService.HashPassword(password);
            
            player = new Player(identity, email, hashedPassword, nickname, firstName, Role.IsValid(role) ? role : string.Empty);
            
            await _playerRepository.AddAsync(player);
            await _scoreboardRepository.AddAsync(new PlayerScore(identity, nickname, player.Points));
        }

        public async Task<Jwt> SignInAsync(string email, string password)
        {
            var player = await _playerRepository.GetAsync(email);
            
            if (player == null || !_passwordService.Verify(player.Password, password))
                throw new ConstellationMindException(ErrorCodes.InvalidCredentials, "You have entered invalid credentials.");

            return _jwtProvider.CreateToken(player.Identity.ToString("N"), player.Role);
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
    }
}
