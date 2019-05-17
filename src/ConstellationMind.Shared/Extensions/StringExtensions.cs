namespace ConstellationMind.Shared.Extensions
{
    public static class StringExtensions
    {
        public static bool IsEmpty(this string value) 
            => string.IsNullOrWhiteSpace(value);
    }
}
