using System;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ConstellationMind.Core.Domain;
using ConstellationMind.Core.Repositories;
using ConstellationMind.Infrastructure.Services.Services.Domains.Interfaces;

namespace ConstellationMind.Infrastructure.Services.Services.Domains
{
    public class RefreshTokenService : IRefreshTokenService
    {
        private readonly IRefreshTokenRepository _refreshTokenRepository;

        public RefreshTokenService(IRefreshTokenRepository refreshTokenRepository)
        {
            _refreshTokenRepository = refreshTokenRepository;
        }
        public async Task<string> CreateAsync(Guid playerId)
        {
            var token = GenerateRefreshToken();
            var refreshToken = new RefreshToken(playerId, token);
            await _refreshTokenRepository.AddAsync(refreshToken);
            return token;
        }

        public async Task InvalidateAsync(string refreshToken)
        {
            // TODO
            await Task.CompletedTask;
        }

        private string GenerateRefreshToken()
		{
			var randomNumber = new byte[32];
            
            using var randomNumberGenerator = RandomNumberGenerator.Create();			
            randomNumberGenerator.GetBytes(randomNumber);
            var result = Convert.ToBase64String(randomNumber);
            
            return Regex.Replace(result, @"[^0-9a-zA-Z]+", string.Empty);
		}
    }
}
