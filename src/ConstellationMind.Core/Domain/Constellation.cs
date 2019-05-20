using System;
using System.Collections.Generic;
using ConstellationMind.Shared.Types;

namespace ConstellationMind.Core.Domain
{
    public class Constellation : IIdentity
    {
        #region Fields
        private ISet<Star> _stars = new HashSet<Star>();

        #endregion

        #region Properties
        public Guid Identity { get; protected set; }
        public string Name { get; protected set; }
        public IEnumerable<Star> Stars
        {
            get { return _stars; }
            set { _stars = new HashSet<Star>(value); }
        }

        #endregion

        #region Constructors
        protected Constellation() {}

        public Constellation(Guid identity, string name)
        {
            Identity = identity;
            Name = name;
        }

        #endregion
    }
}
