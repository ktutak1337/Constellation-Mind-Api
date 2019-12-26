using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using ConstellationMind.Infrastructure.Services.Authentication.Interfaces;
using ConstellationMind.Shared.Exceptions;
using ConstellationMind.Shared.Extensions;
using ConstellationMind.Shared.Settings;
using Microsoft.IdentityModel.Tokens;

namespace ConstellationMind.Infrastructure.Services.Authentication
{
    public class JwtProvider : IJwtProvider
    {
        private readonly JwtSettings _settings;

        public JwtProvider(JwtSettings settings) 
            => _settings = settings;

        public Jwt CreateToken(string playerId, string role = null)
        {
            if(playerId.IsEmpty()) throw new ConstellationMindException(ErrorCodes.PlayerIdIsNullOrEmpty, "Player Id cannot be empty.");

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.SecretKey));
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        
            var now = DateTime.UtcNow;
            var expires = now.AddMinutes(_settings.ExpiryMinutes);

            var jwtClaims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, playerId),
                new Claim(JwtRegisteredClaimNames.UniqueName, playerId),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, expires.ToString()),
            };

            if (!role.IsEmpty()) jwtClaims.Add(new Claim(ClaimTypes.Role, role));
            
            var claims = jwtClaims.ToDictionary(key => key.Type, value => value.Value);

            var jwt = new JwtSecurityToken(
                issuer: _settings.Issuer,
                claims: jwtClaims,
                notBefore: now,
                expires: expires,
                signingCredentials: signingCredentials
            );

            var token = new JwtSecurityTokenHandler().WriteToken(jwt);

            return new Jwt
            {
                AccessToken = token,
                RefreshToken = string.Empty,
                Expires = expires.ToTimestamp(),
                Id = playerId,
                Role = role,
                Claims = claims
            };
        }
    }
}
