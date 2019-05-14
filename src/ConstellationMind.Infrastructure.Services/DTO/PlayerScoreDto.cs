using System;

namespace ConstellationMind.Infrastructure.Services.DTO
{
    public class PlayerScoreDto
    {
        public Guid PlayerId { get; set; }
        public string Nickname { get; set; }
        public int Points { get; set; }
    }
}
