using System;
using System.Collections.Generic;
using ConstellationMind.Shared.Types;
using System.Linq;
using ConstellationMind.Shared.Exceptions;

namespace ConstellationMind.Core.Domain
{
    public class Constellation : IIdentity
    {
        #region Fields
        private ISet<Star> _stars = new HashSet<Star>();
        private ISet<ConstellationLines> _lines = new HashSet<ConstellationLines>();
        private ISet<EquatorialCoordinates> _bounds = new HashSet<EquatorialCoordinates>();

        #endregion

        #region Properties
        public Guid Identity { get; protected set; }
        public string Designation { get; protected set; }
        public string Name { get; protected set; }
        public IEnumerable<Star> Stars
        {
            get { return _stars; }
            set { _stars = new HashSet<Star>(value); }
        }
        public IEnumerable<ConstellationLines> Lines
        {
            get { return _lines; }
            set { _lines = new HashSet<ConstellationLines>(value); }
        }
        public IEnumerable<EquatorialCoordinates> Bounds
        {
            get { return _bounds; }
            set { _bounds = new HashSet<EquatorialCoordinates>(value); }
        }

        #endregion

        #region Constructors
        protected Constellation() {}

        public Constellation(Guid identity, string designation, string name)
        {
            Identity = identity;
            Designation = designation;
            Name = name;
        }

        #endregion

        public void AddStar(Star star)
        {
            var item = _stars.SingleOrDefault(x => x.Name == star.Name);

             if(item != null) throw new ConstellationMindException(ErrorCodes.StarAlreadyExist, $"Star with name: '{star.Name}' already exists");

             _stars.Add(star);
        }
    }
}
