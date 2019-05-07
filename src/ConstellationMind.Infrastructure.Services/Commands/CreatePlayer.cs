using System;
using ConstellationMind.Shared.Types;

namespace ConstellationMind.Infrastructure.Services.Commands
{
    public class CreatePlayer : ICommand
    {
        public Guid Identity { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string Nickname { get; set; }        
    }
}
