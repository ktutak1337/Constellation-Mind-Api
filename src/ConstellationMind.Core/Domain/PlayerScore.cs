using System;

namespace ConstellationMind.Core.Domain
{
    public class PlayerScore
    {
        #region Properties
        public Guid PlayerId { get; protected set; }
        public string Nickname { get; protected set; }
        public int Points { get; protected set; }

        #endregion

        #region Constructors
        protected PlayerScore() {}
        public PlayerScore(Player player)
        {
            PlayerId = player.Identity;
            Nickname = player.Nickname;
            Points = player.Points;
        }

        #endregion

        #region Methods
        public static PlayerScore Create(Player player) => new PlayerScore(player);

        #endregion    
    }
}
