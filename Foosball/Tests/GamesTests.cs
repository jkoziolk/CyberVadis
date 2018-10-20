using NUnit.Framework;
using Moq;
using System;
using Foosball.DataManagers;
using Foosball.DataModels;
using System.Collections.Generic;
using Foosball.Controllers;

namespace Tests
{
    [TestFixture]
    public class GamesTests
    {
        private List<Game> games = new List<Game>()
                {
                    new Game(){ GameId = "abc-ab9-345", StartTime = new DateTime(2018, 10, 12, 13, 55, 00), TeamA = "team A", TeamB = "team B", Winner = "team A" },
                    new Game(){ GameId = "cde-456-cde", StartTime = new DateTime(2018, 10, 12, 13, 57, 00), TeamA = "team C", TeamB = "team B", Winner = "team B" },
                };

        private List<Goal> goals = new List<Goal>()
                {
                    new Goal() {GoalTime = DateTime.Now, Team = "team A"},
                    new Goal() {GoalTime = DateTime.Now, Team = "team B"},
                    new Goal() {GoalTime = DateTime.Now, Team = "team A"}
                };

        private List<Set> sets = new List<Set>()
                {
                    new Set() {Team = "team A", WinTime = new DateTime(2018, 10, 12, 14, 02, 00)}
                };


        IGamesStorage GetBasicStorageMock()
        {
            var mock = new Mock<IGamesStorage>();

            mock.Setup(x => x.CreateGame(It.IsAny<string>(), It.IsAny<string>())).Returns("abc-123-abc");
            mock.Setup(x => x.GetGames()).Returns(games);
            mock.Setup(x => x.GetGoals(It.IsAny<string>())).Returns(goals);
            mock.Setup(x => x.GetGoalsNumber(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>())).Returns(2);
            mock.Setup(x => x.GetSets(It.IsAny<string>())).Returns(sets);
            mock.Setup(x => x.GetSetsNumber(It.IsAny<string>())).Returns(1);
            mock.Setup(x => x.SaveGoal(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>()));

            return mock.Object;
        }

        IGamesStorage GetSetBallStorageMock()
        {
            var mock = new Mock<IGamesStorage>();

            mock.Setup(x => x.GetGoalsNumber(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>())).Returns(10);
            mock.Setup(x => x.GetSetsNumber(It.IsAny<string>())).Returns(1);
            mock.Setup(x => x.SaveGoal(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>()));
            mock.Setup(x => x.SaveSet(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>()));

            return mock.Object;
        }

        IGamesStorage GetGameBallStorageMock()
        {
            var mock = new Mock<IGamesStorage>();

            mock.Setup(x => x.GetGoalsNumber(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>())).Returns(10);
            mock.Setup(x => x.GetSetsNumber(It.IsAny<string>())).Returns(3);
            mock.Setup(x => x.SaveGoal(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>()));
            mock.Setup(x => x.SaveSet(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>()));
            mock.Setup(x => x.GetWinner(It.IsAny<string>())).Returns("team A");
            mock.Setup(x => x.SaveGame(It.IsAny<string>(), It.IsAny<string>()));

            return mock.Object;
        }

        GamesController GetBasicController()
        {
            var storage = GetBasicStorageMock();
            var controller = new GamesController(storage);
            return controller;
        }


        [Test]
        public void TestCreateGame()
        {
            var controller = GetBasicController();

            var res = controller.CreateGame(new NewGame() { TeamA = "team A", TeamB = "team B" });

            Assert.AreEqual("abc-123-abc", res);
        }

        [Test]
        public void TestSingleGoal()
        {
            var controller = GetBasicController();

            var res = controller.Goal(new NewGoal() { GameId = "abc-123-abc", Team = "team A" });

            Assert.AreEqual(GoalResult.Goal, res);
        }

        [Test]
        public void TestSetGoal()
        {
            var storage = GetSetBallStorageMock();
            var controller = new GamesController(storage);

            var res = controller.Goal(new NewGoal() { GameId = "abc-123-abc", Team = "team A" });

            Assert.AreEqual(GoalResult.Set, res);
        }

        [Test]
        public void TestGameGoal()
        {
            var storage = GetGameBallStorageMock();
            var controller = new GamesController(storage);

            var res = controller.Goal(new NewGoal() { GameId = "abc-123-abc", Team = "team A" });

            Assert.AreEqual(GoalResult.Game, res);
        }

        [Test]
        public void TestGetGames()
        {
            var controller = GetBasicController();

            var res = controller.GetGames();

            Assert.AreEqual(games, res);
        }

        [Test]
        public void TestGetGameDetails()
        {
            var controller = GetBasicController();

            var res = controller.GetGameDetails("abc-ab9-345");

            Assert.AreEqual(goals, res.Goals);
            Assert.AreEqual(sets, res.Sets);
            Assert.AreEqual("abc-ab9-345", res.Game.GameId);
            Assert.AreEqual("team A", res.Game.TeamA);
            Assert.AreEqual("team B", res.Game.TeamB);
            Assert.AreEqual("team A", res.Game.Winner);
            Assert.AreEqual(new DateTime(2018, 10, 12, 13, 55, 00), res.Game.StartTime);
        }
    }
}
