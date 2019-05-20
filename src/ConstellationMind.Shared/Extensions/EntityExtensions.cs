using AutoMapper;
using ConstellationMind.Shared.Types;

namespace ConstellationMind.Shared.Extensions
{
    public static class EntityExtensions
    {
        public static TEntityDto MapSingle<TEntity, TEntityDto>(this TEntity entity, IMapper mapper) 
            where TEntity: IIdentity
            where TEntityDto: class
                => entity == null 
                    ? null 
                    : mapper.Map<TEntity, TEntityDto>(entity);
    }
}
