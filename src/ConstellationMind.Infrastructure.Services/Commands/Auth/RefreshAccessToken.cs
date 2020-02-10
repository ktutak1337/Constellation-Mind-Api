using ConstellationMind.Shared.Types;

namespace ConstellationMind.Infrastructure.Services.Commands.Auth
{
    public class RefreshAccessToken : ICommand
    {
        public string RefreshToken { get; set; }
    }
}
