using System;
using ConstellationMind.Shared.Types;

namespace ConstellationMind.Infrastructure.Services.Commands.Constellations
{
    public class DeleteConstellation : ICommand
    {
        public Guid Id { get; set; }
    }
}
