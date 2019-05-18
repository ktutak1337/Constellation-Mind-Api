using System;
using ConstellationMind.Shared.Types;

namespace ConstellationMind.Infrastructure.Services.Commands
{
    public class UpdatePlayerPoints : ICommand
    {
        public Guid PlayerId { get; set; }
        public int Points { get; set; }
    }
}
