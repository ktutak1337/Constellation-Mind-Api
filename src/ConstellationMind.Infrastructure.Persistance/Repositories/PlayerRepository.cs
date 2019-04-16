using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using ConstellationMind.Core.Domain;
using ConstellationMind.Core.Repositories;

namespace ConstellationMind.Infrastructure.Persistance.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        #region Fields
        //Temporary solution for testing purposes.
        private static readonly ISet<Player> _players = new HashSet<Player>
		{
			new Player("player@email.com", "secret", "player1", "player1"),
			new Player("player2@email.com", "secret", "player2", "player2"),
		};

		#endregion

        #region Methods
        public async Task AddAsync(Player player)
        {
            _players.Add(player);
            await Task.CompletedTask;
        }

        public async Task<IEnumerable<Player>> GetAllAsync() => await Task.FromResult(_players);

        public async Task<Player> GetAsync(Guid identity) 
            => await Task.FromResult(_players.SingleOrDefault(x => x.Identity == identity));

        public async Task<Player> GetAsync(string email) 
            => await Task.FromResult(_players.SingleOrDefault(x => x.Email == email));

        public async Task RemoveAsync(Guid identity)
        {
            var player = await GetAsync(identity);
			_players.Remove(player);
			await Task.CompletedTask;
        }

        public Task UpdateAsync(Player player)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
