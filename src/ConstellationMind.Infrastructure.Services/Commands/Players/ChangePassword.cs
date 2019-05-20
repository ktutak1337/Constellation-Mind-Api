using System;
using ConstellationMind.Shared.Types;

namespace ConstellationMind.Infrastructure.Services.Commands.Players
{
    public class ChangePassword : ICommand
    {
        public Guid PlayerId { get; set; }
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }    
    }
}
