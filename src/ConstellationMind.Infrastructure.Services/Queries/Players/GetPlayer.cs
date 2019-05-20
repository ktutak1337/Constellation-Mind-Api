using System;
using ConstellationMind.Infrastructure.Services.DTO;
using ConstellationMind.Shared.Types;

namespace ConstellationMind.Infrastructure.Services.Queries.Players
{
    public class GetPlayer : IQuery<PlayerDto>
    {
        public Guid Id { get; set; }
    }
}
