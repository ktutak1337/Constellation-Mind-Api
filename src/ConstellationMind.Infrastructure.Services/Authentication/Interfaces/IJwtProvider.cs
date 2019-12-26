using System.Collections.Generic;

namespace ConstellationMind.Infrastructure.Services.Authentication.Interfaces
{
    public interface IJwtProvider
    {
        Jwt CreateToken(string playerId, string role = null);
    }
}
