using System;
using ConstellationMind.Shared.Types;

namespace ConstellationMind.Core.Domain
{
    public class Player : IIdentity 
    {
        #region Properties
        public Guid Identity { get; protected set; }
        public string Email { get; protected set; }
        public string Password { get; protected set; }
        public string FirstName { get; protected set; }
        public string Nickname { get; protected set; }
        public int Points { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }
        
        #endregion
        
        #region Constructors
        protected Player() {}

        public Player(string email, string password, string nickname, string firstName = "")
        {
            Identity = Guid.NewGuid();
            Email = email.ToLowerInvariant();
            Password = password;
            Nickname = nickname;
            FirstName = firstName;
            CreatedAt = DateTime.UtcNow;
            Points = 0;
        }

        #endregion
    }
}
