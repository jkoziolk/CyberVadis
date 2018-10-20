using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foosball.DataModels
{
    public class GameDetails
    {
        public Game Game { get; set; }
        public IEnumerable<Set> Sets { get; set; }
        public IEnumerable<Goal> Goals { get; set; }
    }
}
