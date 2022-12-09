using NUnit.Framework;
using System;

namespace RepairShop.Tests
{
    public class Tests
    {
        [TestFixture]
        public class RepairsShopTests
        {
            private Car testCar;
            private Garage testGarage;
            [SetUp]
            public void Setup()
            {
                testCar = new Car("Audi", 1);
                testGarage = new Garage("Bono", 2);
            }

            [Test]
            public void TestCarConstructor()
            {
                string expectedName = "Audi";
                int numOfIssues = 1;

                Assert.AreEqual(expectedName, testCar.CarModel);
                Assert.AreEqual(numOfIssues, testCar.NumberOfIssues);
            }

            [Test]
            public void TestGarageConstructor()
            {
                string expName = "Bono";
                int expMechanics = 2;
                testGarage.AddCar(testCar);
                int expectedCount = 1;

                Assert.AreEqual(expName, testGarage.Name);
                Assert.AreEqual(expMechanics, testGarage.MechanicsAvailable);
                Assert.AreEqual(expectedCount, testGarage.CarsInGarage);
            }

            [TestCase(null)]
            [TestCase("")]
            public void GarageNameException(string value)
            {
                Assert.Throws<ArgumentNullException>(() =>
                {
                    Garage gar = new Garage(value, 2);
                });
            }

            [TestCase(0)]
            [TestCase(-1)]
            public void TestInGarageCrsExc(int value)
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    Garage gar = new Garage("Bono", value);
                });
            }

            [Test]
            public void TestCount()
            {
                testGarage.AddCar(testCar);
                int expC = 1;

                Assert.AreEqual(expC, testGarage.CarsInGarage);
            }

            [Test]
            public void TestAddCarExc()
            {
                testGarage.AddCar(testCar);
                Car car = new Car("BMW", 1);
                Car car2 = new Car("BMW2", 1);
                testGarage.AddCar(car2);
                Assert.Throws<InvalidOperationException>(() =>
                {
                    testGarage.AddCar(car);
                });

            }

            [Test]
            public void TestAdingCar()
            {
                testGarage.AddCar(testCar);
                int expCount = 1;

                Assert.AreEqual(expCount, testGarage.CarsInGarage);
            }

            [Test]
            public void FixCarError()
            {

                Assert.Throws<InvalidOperationException>(() =>
                {
                    testGarage.FixCar(null);
                });
            }

            [Test]
            public void FixCarWorks()
            {
                testGarage.AddCar(testCar);
                testGarage.FixCar("Audi");
                bool carIsFixed = true;
                Assert.AreEqual(carIsFixed, testCar.IsFixed);
            }

            [Test]
            public void TestRemovingCarExc()
            {
                Assert.Throws<InvalidOperationException>(() =>
                {
                    testGarage.RemoveFixedCar();
                });
            }

            [Test]
            public void TestRemovingCar()
            {
                testGarage.AddCar(testCar);
                testGarage.FixCar("Audi");
                testGarage.RemoveFixedCar();
                int numFixedCars = 0;

                Assert.AreEqual(numFixedCars, testGarage.CarsInGarage);
            }

            [Test]
            public void TestOutput()
            {
                testGarage.AddCar(testCar);
                string expOut = $"There are 1 which are not fixed: Audi.";
                string actual = testGarage.Report();
                Assert.AreEqual(expOut, actual);
            }


        }
    }
}