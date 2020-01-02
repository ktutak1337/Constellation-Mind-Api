using System;
using ConstellationMind.Shared.Exceptions;
using ConstellationMind.Shared.Extensions;
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
        public string Role { get; protected set; }
        public int Points { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }
        
        #endregion
        
        #region Constructors
        protected Player() {}

        public Player(Guid idnetity, string email, string password, string nickname, string firstName, string role)
        {
            Identity = idnetity;
            Email = email.ToLowerInvariant();
            Password = password;
            Nickname = nickname;
            FirstName = firstName ?? string.Empty;
            Role = role.ToUpperInvariant() ?? Domain.Role.Player;
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
            Points = 0;
        }

        #endregion

        #region Methods
        public void UpdatePoints(int addPoints) => Points += addPoints;

        public void SetPassword(string password)
        {
            if(password.IsEmpty()) 
                throw new ConstellationMindException(ErrorCodes.InvalidPassword, "Password can not be empty.");
            
            Password = password;

            UpdatedAt = DateTime.UtcNow;
        }
        
        #endregion
    }
}
