namespace ConstellationMind.Infrastructure.Services.DTO
{
    public class StarDto
    {
        public string Designation { get; set; }
        public string Name { get; set; }
        public string Constellation { get; set; }
        public EquatorialCoordinatesDto Coordinates { get; set; }
        public double Magnitude { get; set; }
    }
}
