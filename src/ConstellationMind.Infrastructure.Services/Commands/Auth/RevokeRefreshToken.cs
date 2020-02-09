using ConstellationMind.Shared.Types;

namespace ConstellationMind.Infrastructure.Services.Commands.Auth
{
    public class RevokeRefreshToken : ICommand
    {
        public string RefreshToken { get; set; }
    }
}
