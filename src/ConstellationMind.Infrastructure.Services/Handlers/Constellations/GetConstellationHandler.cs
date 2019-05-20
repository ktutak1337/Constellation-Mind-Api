using System.Threading.Tasks;
using ConstellationMind.Infrastructure.Services.DTO;
using ConstellationMind.Infrastructure.Services.Queries.Constellations;
using ConstellationMind.Infrastructure.Services.Services.DomainServices.Interfaces;
using ConstellationMind.Shared.Handlers.Interfaces;

namespace ConstellationMind.Infrastructure.Services.Handlers.Constellations
{
    public class GetConstellationHandler : IQueryHandler<GetConstellation, ConstellationDto>
    {
        private readonly IConstellationService _constellationService;

        public GetConstellationHandler(IConstellationService constellationService) 
            => _constellationService = constellationService;

        public async Task<ConstellationDto> HandleAsync(GetConstellation query) 
            => await _constellationService.GetAsync(query.Id);
    }
}
