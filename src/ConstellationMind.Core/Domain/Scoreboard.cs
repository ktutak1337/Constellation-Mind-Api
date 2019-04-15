using System;
using System.Collections.Generic;

namespace ConstellationMind.Core.Domain
{
    public class Scoreboard
    {
        #region Fields
        private ISet<PlayerScore> _scores = new HashSet<PlayerScore>();

        #endregion

        #region Properties
        public IEnumerable<PlayerScore> Scores
        {
            get { return _scores; }
            set { _scores = new HashSet<PlayerScore>(value); }
        }
        public string Name { get; private set; }
        public DateTime UpdatedAt { get; private set; }
        
        #endregion

        #region Constructors
        protected Scoreboard() {}
        public Scoreboard(string name) 
        {
            Name = name;
        }

        #endregion
    }
}
