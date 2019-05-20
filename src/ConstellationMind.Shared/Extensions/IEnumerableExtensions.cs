using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using ConstellationMind.Shared.Types;

namespace ConstellationMind.Shared.Extensions
{
    public static class IEnumerableExtensions
    {
        public static IEnumerable<TEntityDto> MapCollection<TEntity, TEntityDto>(this IEnumerable<TEntity> collection, IMapper mapper) 
            where TEntity: IIdentity
            where TEntityDto: class
                => collection == null 
                    ? null 
                    : collection.Select(item => mapper.Map<TEntity, TEntityDto>(item));
    }
}
