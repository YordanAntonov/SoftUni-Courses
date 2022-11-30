namespace CarManager.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class CarManagerTests
    {
        private string make = "Germany";
        private string model = "Volkswagen";
        private double fuelConsumption = 1;
        private double fuelCapacity = 100;
        private Car testCar;

        [SetUp]
        public void SetUp()
        {
            testCar = new Car(make, model, fuelConsumption, fuelCapacity);
        }

        [Test]
        public void CarConstructorShouldSetValuesCorrectly()
        {
            Car car = new Car(make, model, fuelConsumption, fuelCapacity);
            string expectedMake = make;
            string expectedModel = model;
            double expectedFuelConsumption = fuelConsumption;
            double expectedFuelCapacity = fuelCapacity;

            Assert.AreEqual(expectedMake, car.Make);
            Assert.AreEqual(expectedModel, car.Model);
            Assert.AreEqual(expectedFuelConsumption, car.FuelConsumption);
            Assert.AreEqual(expectedFuelCapacity, car.FuelCapacity);
        }

        [Test]
        public void CarConstructorShouldThrowExceptionIfMakelIsNull()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car(null, model, fuelConsumption, fuelCapacity);

            }, "Make cannot be null or empty!");

        }

        [Test]
        public void CarConstructorShouldThrowExceptionIfEmpty()
        {
            string testMake = "";
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car(testMake, model, fuelConsumption, fuelCapacity);
            }, "Make cannot be null or empty!");
        }

        [TestCase(null)]
        [TestCase("")]
        public void CarConstructorShouldThrowExceptionIfModelIsEmptyOrNull(string testModel)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car(make, testModel, fuelConsumption, fuelCapacity);
            }, "Model cannot be null or empty!");
        }

        [TestCase(-3)]
        [TestCase(0)]
        public void CarConstructorSouldThrowExceptionIfFuelConsumptionIsZeroOrNegarive(double testFuelConsumption)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car(make, model, testFuelConsumption, fuelCapacity);
            }, "Fuel consumption cannot be zero or negative!");
        }

        [TestCase(0)]
        [TestCase(-1)]
        public void CarConstructorShouldThrowExceptionIfFuelCapacityIsZeroOrNegative(double testFuelCapacity)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car(make, model, fuelConsumption, testFuelCapacity);
            }, "Fuel capacity cannot be zero or negative!");
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-10)]
        public void CarRefuelMethodShouldThrowExceptionIfFuelToRefuelIsZeroOrNegative(double fuelToRefuel)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                testCar.Refuel(fuelToRefuel);
            }, "Fuel amount cannot be zero or negative!");
        }

        [TestCase(100)]
        [TestCase(67)]
        [TestCase(1)]
        public void CarRefuelMethodShouldAddFuelCorrectly(double refuel)
        {
            double expectedRefueledFuel = refuel;
            testCar.Refuel(refuel);

            Assert.AreEqual(expectedRefueledFuel, testCar.FuelAmount);
        }

        [TestCase(1)]
        [TestCase(10)]
        [TestCase(100)]
        public void CarDriveMethodShouldThrowExceptionWhenFuelIsMoreThenTheCapacity(double distance)
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                testCar.Drive(distance);
            }, "You don't have enough fuel to drive!");
        }

        [TestCase(1)]
        [TestCase(50)]
        [TestCase(25)]
        [TestCase(100)]
        public void CarDriveMethodShouldDriveSuccesfully(double distance)
        {
            testCar.Refuel(100);
            double fuelNeeded = (distance / 100) * testCar.FuelConsumption;
            double expectedFuelLeft = testCar.FuelAmount - fuelNeeded;

            testCar.Drive(distance);
            Assert.AreEqual(expectedFuelLeft, testCar.FuelAmount);
        }

        [Test]
        public void RefuelMethodShouldBeSetOnTheDefaulthFuelCapacityIfWeWantToRefuelMore()
        {
            int expectedRefueldAmount = 100;
            testCar.Refuel(150);

            Assert.AreEqual(expectedRefueldAmount, testCar.FuelAmount);
        }

    }
}