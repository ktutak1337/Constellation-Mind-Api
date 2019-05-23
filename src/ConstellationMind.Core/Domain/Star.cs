namespace ConstellationMind.Core.Domain
{
    public class Star
    {
        #region Properties
        public string Name { get; protected set; }
        public string Constellation { get; protected set; }
        public double Ra { get; protected set; }
        public double Dec { get; protected set; }
        public double Brightness { get; protected set; }

        #endregion

        #region Constructors
        protected Star() {}

        public Star(string name, string constellation, double ra, double dec, double brightness)
        {
            Name = name;
            Constellation = constellation;
            Ra = ra;
            Dec = dec;
            Brightness = brightness;
        }

        #endregion

        #region Methods
        public static Star Create(string name, string constellation, double ra, double dec, double brightness)
            => new Star(name, constellation, ra, dec, brightness);

        #endregion    
    }
}
