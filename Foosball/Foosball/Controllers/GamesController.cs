using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Foosball.DataManagers;
using Foosball.DataModels;
using Microsoft.AspNetCore.Mvc;

namespace Foosball.Controllers
{
    [Route("api/[controller]")]
    public class GamesController : Controller
    {
        private readonly IGamesStorage storage;
        public GamesController(IGamesStorage storage)
        {
            this.storage = storage;
        }

        [HttpGet]
        public IEnumerable<Game> GetGames()
        {
            return storage.GetGames().OrderBy(g => g.StartTime);
        }

        [HttpPost]
        public string CreateGame([FromBody]NewGame game)
        {
            var gameId = storage.CreateGame(game.TeamA, game.TeamB);
            return gameId;
        }

        [HttpPost("goal")]
        public GoalResult Goal([FromBody]NewGoal goal)
        {
            var setsNum = storage.GetSetsNumber(goal.GameId);
            
            storage.SaveGoal(goal.Team, goal.GameId, setsNum);
            var goalsNum = storage.GetGoalsNumber(goal.Team, goal.GameId, setsNum);
            if(goalsNum == 10)
            {
                storage.SaveSet(goal.Team, goal.GameId, setsNum);
                if(setsNum == 3)
                {
                    var winner = storage.GetWinner(goal.GameId);
                    storage.SaveGame(winner, goal.GameId);
                    return GoalResult.Game;
                }
                return GoalResult.Set;    
            }
            return GoalResult.Goal;
        }

        [HttpGet("details/{gameId}")]
        public GameDetails GetGameDetails(string gameId)
        {
            var game = storage.GetGames().Where(g => g.GameId == gameId).FirstOrDefault();
            if (game == null)
                throw new InvalidOperationException($"Game {gameId} does not exist.");
            var goals = storage.GetGoals(gameId).OrderBy(g => g.GoalTime);
            var sets = storage.GetSets(gameId).OrderBy(s => s.WinTime);

            var gameDetails = new GameDetails()
            {
                Game = game,
                Goals = goals,
                Sets = sets
            };

            return gameDetails;
        }
    }
}
