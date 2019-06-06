namespace ConstellationMind.Core.Domain
{
    public class EquatorialCoordinates
    {
        public double Ra { get; protected set; }
        public double Dec { get; protected set; }

        public EquatorialCoordinates(double ra, double dec)
        {
            Ra = ra;
            Dec = dec;
        }

        public static EquatorialCoordinates Create(double ra, double dec)
            => new EquatorialCoordinates(ra, dec);
    }
}
