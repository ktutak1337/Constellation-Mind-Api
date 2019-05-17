using System;
using ConstellationMind.Shared.Extensions;
using ConstellationMind.Shared.Types;
using Microsoft.AspNetCore.Identity;

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

        public Player(Guid idnetity, string email, string password, string nickname, string firstName = "")
        {
            Identity = idnetity;
            Email = email.ToLowerInvariant();
            Password = password;
            Nickname = nickname;
            FirstName = firstName;
            CreatedAt = DateTime.UtcNow;
            Points = 0;
        }

        #endregion

        #region Methods
        public void UpdatePoints(int addPoints) => Points += addPoints;

        public void SetPassword(string password, IPasswordHasher<Player> passwordHasher)
        {
            if(password.IsEmpty()) throw new Exception("Invalid password. Password can not be empty.");
            
            Password = passwordHasher.HashPassword(this, password);
        }

        #endregion
    }
}
