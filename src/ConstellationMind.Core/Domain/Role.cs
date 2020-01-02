using ConstellationMind.Shared.Extensions;

namespace ConstellationMind.Core.Domain
{
    public static class Role
    {
        public const string Player = "PLAYER";
        public const string Admin = "ADMIN";

        public static bool IsValid(string role)
        {
            if (role.IsEmpty()) return false;
            
            role = role.ToUpperInvariant();

            return role == Player || role == Admin;
        }
    }
}
