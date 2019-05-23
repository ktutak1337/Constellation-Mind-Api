using System;
using System.Collections.Generic;
using ConstellationMind.Shared.Types;
using System.Linq;

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

        public void AddStar(Star star)
        {
            var item = _stars.SingleOrDefault(x => x.Name == star.Name);

             if(item != null) throw new Exception($"star with name: {star.Name} already exists");

             _stars.Add(star);
        }
    }
}
