using System;
using ConstellationMind.Shared.Types;

namespace ConstellationMind.Infrastructure.Services.Commands.Players
{
    public class DeletePlayer : ICommand
    {
        public Guid PlayerId { get; set; }
    }
}
