using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Numerics;

namespace FootballTeam.Tests
{
    [TestFixture]
    public class Tests
    {
        private FootballPlayer testPlayer;
        private FootballTeam testTeam;

        [SetUp]
        public void Setup()
        {
            testPlayer = new FootballPlayer("Messi", 10, "Forward");
            testTeam = new FootballTeam("Barca", 16);
        }

        [Test]
        public void TestPlayerConstructorCorrect()
        {
            string expName = "Messi";
            int expNum = 10;
            string expPos = "Forward";
            int goalsScored = 0;

            Assert.AreEqual(expName, testPlayer.Name);
            Assert.AreEqual(expNum, testPlayer.PlayerNumber);
            Assert.AreEqual(expPos, testPlayer.Position);
            Assert.AreEqual(goalsScored, testPlayer.ScoredGoals);
        }

        [TestCase(null)]
        [TestCase("")]
        public void TestPlayerNameException(string value)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                FootballPlayer player = new FootballPlayer(value, 10, "Forward");
            });
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(22)]
        [TestCase(25)]
        public void TestPlayerNumberException(int value)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                FootballPlayer player = new FootballPlayer("Messi", value, "Forward");
            });
        }

        [Test]
        public void TestPlayerPositionException()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                FootballPlayer player = new FootballPlayer("Messi", 10, "Backpack");
            });
        }

        [Test]
        public void GoalsCount()
        {
            Assert.AreEqual(0, testPlayer.ScoredGoals);
        }


        [Test]
        public void GoalsGoalWork()
        {
            testPlayer.Score();
            Assert.AreEqual(1, testPlayer.ScoredGoals);
        }

        [Test]
        public void TestTeamConstructor()
        {
            string expName = "Barca";
            int expCapacity = 16;
            int countOfPlayers = 0;

            Assert.AreEqual(expName, testTeam.Name);
            Assert.AreEqual(expCapacity, testTeam.Capacity);
            Assert.AreEqual(countOfPlayers, testTeam.Players.Count);

        }

        [TestCase(null)]
        [TestCase("")]
        public void TestTNameException(string value)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                FootballTeam fT = new FootballTeam(value, 16);
            });
        }


        [TestCase(14)]
        [TestCase(1)]
        [TestCase(-1)]
        public void TestTeamCapacException(int value)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                FootballTeam fT = new FootballTeam("Barca", value);
            });
        }

        [Test]
        public void TestPlayerCount()
        {
            testTeam.AddNewPlayer(testPlayer);
            int expCount = 1;
            Assert.AreEqual(expCount, testTeam.Players.Count);
        }

        [Test]
        public void TestReruenigListPlayers()
        {
            testTeam.AddNewPlayer(testPlayer);
            FootballPlayer fp = new FootballPlayer("Ronaldo", 7, "Forward");
            testTeam.AddNewPlayer(fp);

            List<FootballPlayer> expPlayers = new List<FootballPlayer>();
            expPlayers.Add(testPlayer);
            expPlayers.Add(fp);
            List<FootballPlayer> actualPlayers = testTeam.Players;

            CollectionAssert.AreEqual(actualPlayers, expPlayers);
        }

        [Test]
        public void TestAddPlayerException()
        {

            FootballPlayer player1 = new FootballPlayer("Massi2", 15, "Forward");
            FootballPlayer player2 = new FootballPlayer("Massi2", 15, "Forward");
            FootballPlayer player3 = new FootballPlayer("Massi3", 15, "Forward");
            FootballPlayer player4 = new FootballPlayer("Massi4", 15, "Forward");
            FootballPlayer player5 = new FootballPlayer("Massi5", 15, "Forward");
            FootballPlayer player6 = new FootballPlayer("Massi6", 15, "Forward");
            FootballPlayer player7 = new FootballPlayer("Massi7", 15, "Forward");
            FootballPlayer player8 = new FootballPlayer("Massi8", 15, "Forward");
            FootballPlayer player9 = new FootballPlayer("Massi9", 15, "Forward");
            FootballPlayer player10 = new FootballPlayer("Massi10", 15, "Forward");
            FootballPlayer player11 = new FootballPlayer("Massi11", 15, "Forward");
            FootballPlayer player12 = new FootballPlayer("Massi12", 15, "Forward");
            FootballPlayer player13 = new FootballPlayer("Massi13", 15, "Forward");
            FootballPlayer player14 = new FootballPlayer("Massi14", 15, "Forward");
            FootballPlayer player15 = new FootballPlayer("Massi15", 15, "Forward");
            FootballPlayer player16 = new FootballPlayer("Massi16", 15, "Forward");

            testTeam.AddNewPlayer(player1);
            testTeam.AddNewPlayer(player2);
            testTeam.AddNewPlayer(player3);
            testTeam.AddNewPlayer(player4);
            testTeam.AddNewPlayer(player5);
            testTeam.AddNewPlayer(player6);
            testTeam.AddNewPlayer(player7);
            testTeam.AddNewPlayer(player8);
            testTeam.AddNewPlayer(player9);
            testTeam.AddNewPlayer(player10);
            testTeam.AddNewPlayer(player11);
            testTeam.AddNewPlayer(player12);
            testTeam.AddNewPlayer(player13);
            testTeam.AddNewPlayer(player14);
            testTeam.AddNewPlayer(player15);
            testTeam.AddNewPlayer(player16);

            string expReturtn = "No more positions available!";
            string actualReturn = testTeam.AddNewPlayer(testPlayer);

            Assert.AreEqual(expReturtn, actualReturn);
        }

        [Test]
        public void AddingPlayerSuccesfully()
        {
            string expOutput = $"Added player Messi in position Forward with number 10";
            string actualOutput = testTeam.AddNewPlayer(testPlayer);

            Assert.AreEqual(expOutput, actualOutput);
        }

        [Test]
        public void TestPickPlayerCorrect()
        {
            FootballPlayer expPlayer = testPlayer;
            testTeam.AddNewPlayer(testPlayer);

            FootballPlayer actual = testTeam.PickPlayer("Messi");

            Assert.AreEqual(expPlayer, actual);
        }

        [Test]
        public void TestPickPlayerCorrectWithNull()
        {
            FootballPlayer expPlayer = null;
            testTeam.AddNewPlayer(testPlayer);

            FootballPlayer actual = testTeam.PickPlayer("sadasd");

            Assert.AreEqual(expPlayer, actual);
        }

        [Test]
        public void TestTeamPlayerScore()
        {
            testTeam.AddNewPlayer(testPlayer);
            string expOutput = $"Messi scored and now has 1 for this season!";

            string actual = testTeam.PlayerScore(10);
            testTeam.PlayerScore(10);

            Assert.AreEqual(expOutput, actual);
        }
    }
}