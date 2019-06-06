using System;
using ConstellationMind.Core.Domain;
using ConstellationMind.Shared.Types;

namespace ConstellationMind.Infrastructure.Services.Commands.Constellations
{
    public class AddStarToConstellation : ICommand
    {
        public Guid ConstellationId { get; set; }
        public string Designation { get; set; }
        public string Name { get; set; }
        public string Constellation { get; set; }
        public EquatorialCoordinates Coordinates { get; set; }
        public double Magnitude { get; set; }
    }
}
