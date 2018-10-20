using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foosball.DataModels
{
    public class NewGoal
    {
        public string Team { get; set; }
        public string GameId { get; set; }
    }

    public enum GoalResult { Goal, Set, Game };
}
