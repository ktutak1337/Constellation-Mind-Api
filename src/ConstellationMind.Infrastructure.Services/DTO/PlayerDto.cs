using System;

namespace ConstellationMind.Infrastructure.Services.DTO
{
    public class PlayerDto
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string Nickname { get; set; }
        public int Points { get; set; }
    }
}
