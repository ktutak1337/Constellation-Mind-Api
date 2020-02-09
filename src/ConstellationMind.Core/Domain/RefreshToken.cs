using System;
using ConstellationMind.Shared.Exceptions;
using ConstellationMind.Shared.Types;

namespace ConstellationMind.Core.Domain
{
    public class RefreshToken : IIdentity
    {
        public Guid Identity { get; protected set; }
        public Guid PlayerId { get; protected set; }
        public string Token { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime? InvalidatedAt { get; protected set; }
        public bool IsInvalidate => InvalidatedAt.HasValue;

        protected RefreshToken() {}

        public RefreshToken(Guid playerId, string token)
        {
            Identity = Guid.NewGuid();
            PlayerId = playerId;
            Token = token;
            CreatedAt = DateTime.UtcNow;
            InvalidatedAt = null;
        }
    }
}
