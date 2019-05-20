using System;
using ConstellationMind.Infrastructure.Services.DTO;
using ConstellationMind.Shared.Types;

namespace ConstellationMind.Infrastructure.Services.Queries.Constellations
{
    public class GetConstellation : IQuery<ConstellationDto>
    {
        public Guid Id { get; set; }
    }
}
