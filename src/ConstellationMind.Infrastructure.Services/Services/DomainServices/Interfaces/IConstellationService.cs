using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ConstellationMind.Infrastructure.Services.DTO;
using ConstellationMind.Shared.Types;

namespace ConstellationMind.Infrastructure.Services.Services.DomainServices.Interfaces
{
    public interface IConstellationService : IService
    {
         Task<ConstellationDto> GetAsync(Guid identity);
         Task<IEnumerable<ConstellationDto>> GetConstellationsAsync();
         Task CreateAsync(Guid identity, string name);
         Task AddStarAsync(Guid constellationId, string name, string constellation, double Ra, double Dec, double brightness);
         Task DeleteAsync(Guid identity);
    }
}
