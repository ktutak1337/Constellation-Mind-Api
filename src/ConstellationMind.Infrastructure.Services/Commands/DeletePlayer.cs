using System;
using ConstellationMind.Shared.Types;

namespace ConstellationMind.Infrastructure.Services.Commands
{
    public class DeletePlayer : ICommand
    {
        public Guid Id { get; set; }
    }
}
