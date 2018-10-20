using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foosball.DataModels
{
    public class Game
    {
        public DateTime StartTime { get; set; }
        public string GameId { get; set; }
        public string TeamA { get; set; }
        public string TeamB { get; set; }
        public string Winner { get; set; }
    }
}
