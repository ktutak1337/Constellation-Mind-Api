using System;
using System.Threading.Tasks;
using ConstellationMind.Core.Domain;
using ConstellationMind.Core.Repositories;

namespace ConstellationMind.Infrastructure.Services.Extensions
{
    public static class RepositoryExtensions
    {
        public static async Task<Player> GetOrFailAsync(this IPlayerRepository repository, Guid playerId)
        {
            var player = await repository.GetAsync(playerId);
            
            if(player == null) throw new Exception($"Player with user id: '{playerId}' was not found.");
            
            return player;            
        }

        public static async Task<Player> GetOrFailAsync(this IPlayerRepository repository, string email)
        {
            var player = await repository.GetAsync(email);
            
            if(player != null) throw new Exception($"Player with email: '{email}' already exists.");
            
            return player;            
        }
    }
}
