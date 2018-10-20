using Foosball.DataModels;
using System.Collections.Generic;

namespace Foosball.DataManagers
{
    public interface IGamesStorage
    {
        string CreateGame(string teamA, string teamB);
        void SaveGoal(string team, string gameId, int set);
        void SaveSet(string team, string gameId, int set);
        void SaveGame(string team, string gameId);
        int GetGoalsNumber(string team, string gameId, int set);
        int GetSetsNumber(string gameId);
        string GetWinner(string gameId);
        IEnumerable<Game> GetGames();
        IEnumerable<Goal> GetGoals(string gameId);
        IEnumerable<Set> GetSets(string gameId);
    }
}