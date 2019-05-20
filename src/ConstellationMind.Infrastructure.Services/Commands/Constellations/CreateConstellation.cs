using System;
using ConstellationMind.Shared.Types;

namespace ConstellationMind.Infrastructure.Services.Commands.Constellations
{
    public class CreateConstellation : ICommand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
