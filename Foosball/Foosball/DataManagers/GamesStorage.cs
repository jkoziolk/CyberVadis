using Foosball.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foosball.DataManagers
{
    public class GamesStorage : IGamesStorage
    {
        private readonly Foosball.DbModels.FoosballContext context;
        public GamesStorage(Foosball.DbModels.FoosballContext context)
        {
            this.context = context;
        }

        public string CreateGame(string teamA, string teamB)
        {
            var guid = new Guid();
            var set = new DbModels.Set() { Number = 1 };
            context.Games.Add(new DbModels.Game()
            {
                TeamA = teamA,
                TeamB = teamB,
                StartTime = DateTime.Now,
                GameId = guid.ToString(),
                Sets = new List<DbModels.Set>() { set }
            });
            context.SaveChanges();
            return guid.ToString();
        }

        public IEnumerable<Game> GetGames()
        {
            var games = context.Games.Select(g => new Game()
            {
                GameId = g.GameId.ToString(),
                StartTime = g.StartTime,
                TeamA = g.TeamA,
                TeamB = g.TeamB,
                Winner = g.Winner
            }).ToList();
            return games;
        }

        public IEnumerable<Goal> GetGoals(string gameId)
        {
            throw new NotImplementedException();
        }

        public int GetGoalsNumber(string team, string gameId, int set)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Set> GetSets(string gameId)
        {
            throw new NotImplementedException();
        }

        public int GetSetsNumber(string gameId)
        {
            throw new NotImplementedException();
        }

        public string GetWinner(string gameId)
        {
            throw new NotImplementedException();
        }

        public void SaveGame(string team, string gameId)
        {
            throw new NotImplementedException();
        }

        public void SaveGoal(string team, string gameId, int set)
        {
            throw new NotImplementedException();
        }

        public void SaveSet(string team, string gameId, int set)
        {
            throw new NotImplementedException();
        }
    }
}
