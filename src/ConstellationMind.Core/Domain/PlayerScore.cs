using System;
using ConstellationMind.Shared.Types;

namespace ConstellationMind.Core.Domain
{
    public class PlayerScore : IIdentity
    {
        #region Properties
        public Guid Identity { get; protected set; }
        public string Nickname { get; protected set; }
        public int Points { get; protected set; }

        #endregion

        #region Constructors
        protected PlayerScore() {}
        public PlayerScore(Guid playerId, string nickname, int points)
        {
            Identity = playerId;
            Nickname = nickname;
            Points = points;
        }

        #endregion 
    }
}
