namespace ConstellationMind.Core.Domain
{
    public class Star
    {
        #region Properties
        public string Designation { get; protected set; }
        public string Name { get; protected set; }
        public string Constellation { get; protected set; }
        public EquatorialCoordinates Coordinates { get; protected set; }
        public double Magnitude { get; protected set; }

        #endregion

        #region Constructors
        protected Star() {}

        public Star(string designation, string name, string constellation, EquatorialCoordinates coordinates, double magnitude)
        {
            Designation = designation ?? string.Empty;
            Name = name;
            Constellation = constellation;
            Coordinates = coordinates;
            Magnitude = magnitude;
        }

        #endregion

        #region Methods
        public static Star Create(string designation, string name, string constellation, EquatorialCoordinates coordinates, double magnitude)
            => new Star(designation, name, constellation, coordinates, magnitude);

        #endregion    
    }
}
