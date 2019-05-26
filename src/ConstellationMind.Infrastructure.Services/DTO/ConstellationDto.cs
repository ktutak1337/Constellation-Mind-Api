using System;
using System.Collections.Generic;

namespace ConstellationMind.Infrastructure.Services.DTO
{
    public class ConstellationDto
    {
        public Guid Id { get; set; }
        public string Designation { get; set; }
        public string Name { get; set; }
        public IEnumerable<StarDto> Stars { get; set; }
    }
}
