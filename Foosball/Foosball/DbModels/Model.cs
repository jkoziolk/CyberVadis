using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Foosball.DbModels
{
    public class FoosballContext : DbContext
    {
        public FoosballContext(DbContextOptions<FoosballContext> options)
            : base(options)
        { }

        public DbSet<Game> Games { get; set; }
        public DbSet<Set> Sets { get; set; }
        public DbSet<Goal> Goals { get; set; }
    }

    public class Game
    {
        public int Id { get; set; }
        public string GameId { get; set; }
        public string TeamA { get; set; }
        public string TeamB { get; set; }
        public string Winner { get; set; }
        public DateTime StartTime { get; set; }

        public ICollection<Set> Sets { get; set; }
    }

    public class Set
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string Winner { get; set; }
        public DateTime WinTime { get; set; }

        public ICollection<Goal> Goals { get; set; }
    }

    public class Goal
    {
        public int Id { get; set; }
        public string Team { get; set; }
        public DateTime GoalTime { get; set; }
    }
}
