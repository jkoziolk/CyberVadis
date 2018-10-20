using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Foosball.DataModels;

namespace Foosball.DataManagers
{
    public class GamesStorage : IGamesStorage
    {
        public string CreateGame(string teamA, string teamB)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Game> GetGames()
        {
            throw new NotImplementedException();
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
