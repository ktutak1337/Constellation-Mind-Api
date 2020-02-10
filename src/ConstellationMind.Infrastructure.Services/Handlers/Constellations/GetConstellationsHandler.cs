using System.Collections.Generic;
using System.Threading.Tasks;
using ConstellationMind.Infrastructure.Services.DTO;
using ConstellationMind.Infrastructure.Services.Queries.Constellations;
using ConstellationMind.Infrastructure.Services.Services.Domains.Interfaces;
using ConstellationMind.Shared.Handlers.Interfaces;

namespace ConstellationMind.Infrastructure.Services.Handlers.Constellations
{
    public class GetConstellationsHandler : IQueryHandler<GetConstellations, IEnumerable<ConstellationDto>>
    {
        private readonly IConstellationService _constellationService;

        public GetConstellationsHandler(IConstellationService constellationService) 
            => _constellationService = constellationService;

        public async Task<IEnumerable<ConstellationDto>> HandleAsync(GetConstellations query) 
            => await _constellationService.GetConstellationsAsync();
        
    }
}
