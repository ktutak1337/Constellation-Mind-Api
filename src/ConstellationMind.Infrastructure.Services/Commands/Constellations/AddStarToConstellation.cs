using System;
using ConstellationMind.Shared.Types;

namespace ConstellationMind.Infrastructure.Services.Commands.Constellations
{
    public class AddStarToConstellation : ICommand
    {
        public Guid ConstellationId { get; set; }
        public string Name { get; set; }
        public string Constellation { get; set; }
        public double Ra { get; set; }
        public double Dec { get; set; }
        public double Brightness { get; set; }
    }
}
