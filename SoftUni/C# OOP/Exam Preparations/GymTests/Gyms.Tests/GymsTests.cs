using NUnit.Framework;
using System;
using System.Net;

namespace Gyms.Tests
{
    [TestFixture]
    public class GymsTests
    {
        private Gym testGym;
        private Athlete testAthlete;

        [SetUp]
        public void SetUp()
        {
            testAthlete = new Athlete("Ivan");
            testGym = new Gym("Imperius", 20);
        }

        [Test]
        public void TestAthleteConstructorWorksCorrect()
        {
            string epxectedName = "Ivan";
            bool exoBool = false;

            Assert.AreEqual(epxectedName, testAthlete.FullName);
            Assert.AreEqual(exoBool, testAthlete.IsInjured);
        }

        [Test]
        public void TestingGymConstructor()
        {
            Gym gym = new Gym("Ikarus", 1);
            int expectedSize = 1;
            string expectedName = "Ikarus";
            int listCount = 0;

            Assert.AreEqual(expectedName, gym.Name);
            Assert.AreEqual(expectedSize, gym.Capacity);
            Assert.AreEqual(listCount, gym.Count);
        }

        [Test]
        public void TestGymCount()
        {
            Athlete atl1 = new Athlete("Georg");
            Athlete atl2 = new Athlete("Georg2");
            Athlete atl3 = new Athlete("Georg3");
            testGym.AddAthlete(atl1);
            testGym.AddAthlete(atl2);
            testGym.AddAthlete(atl3);
            int expCount = 3;
            Assert.AreEqual(expCount, testGym.Count);
        }

        [TestCase(null)]
        [TestCase("")]
        public void TestNameException(string value)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                Gym atl = new Gym(value, 20);
            });
        }

        [TestCase(-1)]
        [TestCase(-10)]
        public void TestingCapacityException(int value)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Gym ng = new Gym("Imper", value);
            });
        }

        [Test]
        public void TestAddingAthlete()
        {
            int expectedCount = 1;
            testGym.AddAthlete(testAthlete);

            Assert.AreEqual(expectedCount, testGym.Count);
        }

        [Test]
        public void AddAthleteException()
        {
            Gym gm = new Gym("Ivan", 1);
            gm.AddAthlete(testAthlete);
            Athlete atl = new Athlete("Georg");

            Assert.Throws<InvalidOperationException>(() =>
            {
                gm.AddAthlete(atl);
            });
        }

        [Test]
        public void TestRemoveAtlete()
        {
            int expCount = 0;
            testGym.AddAthlete(testAthlete);
            testGym.RemoveAthlete(testAthlete.FullName);

            Assert.AreEqual(expCount, testGym.Count);
        }

        [TestCase(null)]
        [TestCase("Ivanian")]
        public void TestRemoveAthleteException(string name)
        {
            testGym.AddAthlete(testAthlete);
            Assert.Throws<InvalidOperationException>(() =>
            {
                testGym.RemoveAthlete(name);
            });
        }

        [TestCase(null)]
        [TestCase("asdada")]
        public void TestInjuredAthleteException(string name)
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                testGym.InjureAthlete(name);
            });
        }

        [Test]
        public void TestInfuringAthlete()
        {
            bool expectedValue = true;
            testGym.AddAthlete(testAthlete);
            testGym.InjureAthlete(testAthlete.FullName);

            Assert.AreEqual(expectedValue, testAthlete.IsInjured);
        }

        [Test]
        public void TestingReport()
        {
            string expectedSentance = $"Active athletes at {testGym.Name}: {testAthlete.FullName}";
            testGym.AddAthlete(testAthlete);
            string actualMessage = testGym.Report();

            Assert.AreEqual(expectedSentance, actualMessage);
        }

        [Test]
        public void TestingReport2()
        {
            string expectedSentance = $"Active athletes at {testGym.Name}: {testAthlete.FullName}";
            Athlete atl2 = new Athlete("Ges");
            testGym.AddAthlete(testAthlete);
            testGym.AddAthlete(atl2);
            testGym.InjureAthlete(atl2.FullName);
            string actualMessage = testGym.Report();

            Assert.AreEqual(expectedSentance, actualMessage);
        }

        [Test]
        public void IsInjuredReturnsCorrectPerson()
        {
            Athlete expAthlete = testAthlete;
            testGym.AddAthlete(testAthlete);
            Assert.AreEqual(expAthlete, testGym.InjureAthlete(testAthlete.FullName));
        }
    }
}
