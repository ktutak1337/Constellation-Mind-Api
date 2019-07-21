using System;
using ConstellationMind.Shared.Exceptions;
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
        public string PasswordHash { get; protected set; }
        public string FirstName { get; protected set; }
        public string Nickname { get; protected set; }
        public string Role { get; protected set; }
        public int Points { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }
        
        #endregion
        
        #region Constructors
        protected Player() {}

        public Player(Guid idnetity, string email, string nickname, string firstName, string role)
        {
            Identity = idnetity;
            Email = email.ToLowerInvariant();
            Nickname = nickname;
            FirstName = firstName ?? string.Empty;
            Role = role ?? string.Empty;
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
            Points = 0;
        }

        #endregion

        #region Methods
        public void UpdatePoints(int addPoints) => Points += addPoints;

        public void SetPassword(string password, IPasswordHasher<Player> passwordHasher)
        {
            if(password.IsEmpty()) throw new ConstellationMindException(ErrorCodes.InvalidPassword, "Password can not be empty.");
            
            PasswordHash = passwordHasher.HashPassword(this, password);

            UpdatedAt = DateTime.UtcNow;
        }

        public bool VerifyPassword(string password, IPasswordHasher<Player> passwordHasher)
            => passwordHasher.VerifyHashedPassword(this, PasswordHash, password) == PasswordVerificationResult.Success;

        #endregion
    }
}
