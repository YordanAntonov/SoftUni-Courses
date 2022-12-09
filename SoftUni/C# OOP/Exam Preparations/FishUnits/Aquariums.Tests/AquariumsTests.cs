namespace Aquariums.Tests
{
    using System;
    using NUnit;
    using NUnit.Framework;

    [TestFixture]
    public class AquariumsTests
    {
        private Fish testFish;
        private Aquarium testAquarium;

        [SetUp]
        public void SetUp()
        {
            testFish = new Fish("Ivan");
            testAquarium = new Aquarium("Burkan", 1);
        }

        [Test]
        public void TestFishConstructorWorking()
        {
            string expectedName = "Ivan";
            bool expectedAvailability = true;

            Assert.AreEqual(expectedName, testFish.Name);
            Assert.AreEqual(expectedAvailability, testFish.Available);
        }

        [Test]
        public void TestAquariumConstructorWorking()
        {
            string expectedName = "Burkan";
            int expectedCapacity = 1;
            int expectedCount = 0;

            Assert.AreEqual(expectedName, testAquarium.Name);
            Assert.AreEqual(expectedCapacity, testAquarium.Capacity);
            Assert.AreEqual(expectedCount, testAquarium.Count);
        }

        [TestCase(null)]
        [TestCase("")]
        public void SetNameShouldThrowException(string value)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                Aquarium aqua = new Aquarium(value, 2);
            });
        }

        [TestCase(-1)]
        [TestCase(-10)]
        public void SetCapacityShouldThrowException(int value)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Aquarium aqua = new Aquarium("Ivan", value);
            });
        }

        [Test]
        public void CountShouldBeCorrect()
        {
            testAquarium.Add(testFish);
            int expCount = 1;
            Assert.AreEqual(expCount, testAquarium.Count);
        }

        [Test]
        public void AddingFishShouldWork()
        {
            testAquarium.Add(testFish);
            Fish fish = testFish;
            Fish actualFish = testAquarium.SellFish("Ivan");
            int expectedCount = 1;
            Assert.AreEqual(fish, actualFish);
            Assert.AreEqual(expectedCount, testAquarium.Count);
        }

        [Test]
        public void AddFishException()
        {
            testAquarium.Add(testFish);
            Fish fish = new Fish("Georg");

            Assert.Throws<InvalidOperationException>(() =>
            {
                testAquarium.Add(fish);
            });
        }

        [Test]
        public void RemoveFishSuccesfully()
        {
            testAquarium.Add(testFish);
            int expectedCount = 0;
            testAquarium.RemoveFish("Ivan");
            Assert.AreEqual(expectedCount, testAquarium.Count);
        }

        [Test]
        public void RemovingFishException()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                testAquarium.RemoveFish(null);
            });
        }

        [Test]
        public void TestingSellFishSuccesfully()
        {
            testAquarium.Add(testFish);
            Fish expFish = testAquarium.SellFish("Ivan");
            bool expectedAvailabillity = false;


            Assert.AreEqual(expectedAvailabillity, testFish.Available);
            Assert.AreEqual(testFish, expFish);
        }

        [Test]
        public void SellFishThrowsException()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                testAquarium.SellFish(null);
            });
        }

        [Test]
        public void ReportReturnsCorrect()
        {
            testAquarium.Add(testFish);
            string expReturn = $"Fish available at Burkan: Ivan";
            string actualReturn = testAquarium.Report();

            Assert.AreEqual(expReturn, actualReturn);
        }

    }
}
