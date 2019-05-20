using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ConstellationMind.Core.Domain;
using ConstellationMind.Core.Repositories;
using ConstellationMind.Infrastructure.Services.DTO;
using ConstellationMind.Infrastructure.Services.Extensions;
using ConstellationMind.Infrastructure.Services.Services.DomainServices.Interfaces;
using ConstellationMind.Shared.Extensions;

namespace ConstellationMind.Infrastructure.Services.Services.DomainServices
{
    public class ConstellationService : IConstellationService
    {
        private readonly IConstellationRepository _constellationRepository;
        private readonly IMapper _mapper;

        public ConstellationService(IConstellationRepository constellationRepository, IMapper mapper)
        {
            _constellationRepository = constellationRepository;
            _mapper = mapper;
        }

        public async Task<ConstellationDto> GetAsync(Guid identity)
            => (await _constellationRepository.GetAsync(identity))
                .MapSingle<Constellation, ConstellationDto>(_mapper);

        public async Task<IEnumerable<ConstellationDto>> GetConstellationsAsync()
            => (await _constellationRepository.GetAllAsync())
                .MapCollection<Constellation, ConstellationDto>(_mapper);

        public async Task CreateAsync(Guid identity, string name)
        {
            var constellation = await _constellationRepository.GetOrFailAsync(identity);

            constellation = new Constellation(identity, name);

            await _constellationRepository.AddAsync(constellation);
        }

        public Task AddStarAsync(Guid identity, string name, string constellation, double Ra, double Dec, double brightness)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid identity)
        {
            throw new NotImplementedException();
        }
    }
}