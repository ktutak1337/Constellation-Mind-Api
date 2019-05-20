using AutoMapper;
using ConstellationMind.Core.Domain;
using ConstellationMind.Infrastructure.Services.DTO;

namespace ConstellationMind.Infrastructure.Services.Mappers
{
    public static class AutoMapperConfig
    {
         public static IMapper Initialize() => new MapperConfiguration(
            config => 
            {
                config.CreateMap<Player, PlayerDto>()
                    .ForMember(dto => dto.Id, x => x.MapFrom(player => player.Identity));
                
                config.CreateMap<PlayerScore, PlayerScoreDto>()
                    .ForMember(dto => dto.PlayerId, x => x.MapFrom(playerScore => playerScore.Identity));

                config.CreateMap<Constellation, ConstellationDto>()
                    .ForMember(dto => dto.Id, x => x.MapFrom(constellation => constellation.Identity));

                config.CreateMap<Star, StarDto>();    
            })
            .CreateMapper(); 
    }
}
