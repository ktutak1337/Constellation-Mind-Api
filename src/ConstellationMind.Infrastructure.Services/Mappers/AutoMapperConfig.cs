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
                config.CreateMap<Player, PlayerDto>();
            })
            .CreateMapper(); 
    }
}
