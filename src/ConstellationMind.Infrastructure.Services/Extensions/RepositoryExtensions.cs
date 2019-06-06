using System;
using System.Threading.Tasks;
using ConstellationMind.Core.Domain;
using ConstellationMind.Core.Repositories;
using ConstellationMind.Shared.Exceptions;

namespace ConstellationMind.Infrastructure.Services.Extensions
{
    public static class RepositoryExtensions
    {
        public static async Task<Player> GetOrFailAsync(this IPlayerRepository repository, Guid playerId)
        {
            var player = await repository.GetAsync(playerId);
            
            if(player == null) 
                throw new ConstellationMindException(ErrorCodes.PlayerNotFound, $"Player with id: '{playerId}' was not found.");
            
            return player;            
        }

        public static async Task<Player> GetOrFailAsync(this IPlayerRepository repository, string email)
        {
            var player = await repository.GetAsync(email);
            
            if(player != null) 
                throw new ConstellationMindException(ErrorCodes.EmailInUse, $"Player with email: '{email}' already exists.");
            
            return player;            
        }

        public static async Task<Constellation> GetOrFailAsync(this IConstellationRepository repository, Guid constellationId)
        {
            var constellation = await repository.GetAsync(constellationId);
            
            if(constellation != null) 
                throw new ConstellationMindException(ErrorCodes.ConstellationAlreadyExist,
                    $"Constellation: '{constellation.Name}' with id: '{constellationId}' already exists.");
            
            return constellation;            
        }
    }
}
