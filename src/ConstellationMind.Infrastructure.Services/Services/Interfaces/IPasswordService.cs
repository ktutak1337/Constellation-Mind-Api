namespace ConstellationMind.Infrastructure.Services.Services.Interfaces
{
    public interface IPasswordService
    {
        bool Verify(string hash, string password);
        string HashPassword(string password);
    }
}
