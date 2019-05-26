using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ConstellationMind.Core.Domain;
using ConstellationMind.Infrastructure.Services.DTO;
using ConstellationMind.Shared.Types;

namespace ConstellationMind.Infrastructure.Services.Services.DomainServices.Interfaces
{
    public interface IConstellationService : IService
    {
         Task<ConstellationDto> GetAsync(Guid identity);
         Task<IEnumerable<ConstellationDto>> GetConstellationsAsync();
         Task CreateAsync(Guid identity, string abbreviation, string name);
         Task AddStarAsync(Guid constellationId, string designation, string name, string constellation, EquatorialCoordinates coordinates, double magnitude);
         Task DeleteAsync(Guid identity);
    }
}
