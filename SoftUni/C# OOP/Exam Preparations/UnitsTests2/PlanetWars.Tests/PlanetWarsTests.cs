using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace PlanetWars.Tests
{
    public class Tests
    {
        [TestFixture]
        public class PlanetWarsTests
        {
            private Weapon testWeapon;
            private Planet testPlanet;

            [SetUp]
            public void SetUp()
            {
                testWeapon = new Weapon("Trident", 20, 100);
                testPlanet = new Planet("Neptun", 2000);
            }

            [Test]
            public void ConstrWoking1()
            {
                Weapon wp = new Weapon("Kara", 20, 100);
                string expName = "Kara";
                Assert.AreEqual(expName, wp.Name);
            }

            [Test]
            public void ConstrWoking2()
            {
                Weapon wp = new Weapon("Kara", 20, 100);
                double expPrice = 20;
                Assert.AreEqual(expPrice, wp.Price);
            }

            [Test]
            public void ConstrWoking3()
            {
                int destructionLecvel = 100;
                Assert.AreEqual(destructionLecvel, testWeapon.DestructionLevel);
            }

            [TestCase(-1)]
            public void PriceException(double value)
            {

                Assert.Throws<ArgumentException>(() =>
                {
                    Weapon wp = new Weapon("s", value, 100);
                });
            }

            [TestCase]
            public void IncreaseDestroWork()
            {
                int expectDestro = 101;
                testWeapon.IncreaseDestructionLevel();
                Assert.AreEqual(expectDestro, testWeapon.DestructionLevel);
            }

            [Test]
            public void IsNuclearTru()
            {
                bool expNuclear = true;
                Assert.AreEqual(expNuclear, testWeapon.IsNuclear);
            }

            [Test]
            public void IsNuclearFals()
            {
                Weapon wp = new Weapon("SD", 20, 9);
                bool expNuclear = false;
                Assert.AreEqual(expNuclear, wp.IsNuclear);
            }

            //testPlanet = new Planet("Neptun", 2000);
            [Test]
            public void PlanetConstWork1()
            {
                string expName = "Neptun";
                Assert.AreEqual(expName, testPlanet.Name);
            }

            [Test]
            public void PlanetConstWork2()
            {
                double expBudged = 2000;
                Assert.AreEqual(expBudged, testPlanet.Budget);
            }

            [Test]
            public void PlanetConstWork3()
            {
                int expCount = 0;
                Assert.AreEqual(expCount, testPlanet.Weapons.Count);
            }

            [Test]
            public void PlanetConstWork4()
            {
                Weapon expWeapon = testWeapon;
                List<Weapon> exp = new List<Weapon>();
                exp.Add(expWeapon);
                testPlanet.AddWeapon(testWeapon);
                Assert.AreEqual(exp, testPlanet.Weapons);
            }

            [TestCase("")]
            [TestCase(null)]
            public void TestExp1(string value)
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    Planet pl = new Planet(value, 200);
                });
            }

            [TestCase(-1)]
            [TestCase(-100)]
            public void TestExp2(double value)
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    Planet pl = new Planet("In", value);
                });
            }

            [Test]
            public void PowerCheck()
            {
                testPlanet.AddWeapon(testWeapon);
                double expPower = testWeapon.DestructionLevel;

                Assert.AreEqual(expPower, testPlanet.MilitaryPowerRatio);
            }

            [Test]
            public void CheckBudged()
            {
                double exoBud = 2100;
                testPlanet.Profit(100);
                Assert.AreEqual(exoBud, testPlanet.Budget);
            }

            [Test]
            public void TesuBudgedError()
            {
                Planet planet = new Planet("name", 90);

                Assert.Throws<InvalidOperationException>(() =>
                {
                    planet.SpendFunds(100);
                });
            }

            [Test]
            public void CheckBudged2()
            {
                double exoBud = 1900;
                testPlanet.SpendFunds(100);
                Assert.AreEqual(exoBud, testPlanet.Budget);
            }

            [Test]
            public void AdingWeapon()
            {
                testPlanet.AddWeapon(testWeapon);
                int expCount = 1;
                Assert.AreEqual(expCount, testPlanet.Weapons.Count);
            }
            [Test]
            public void AdingWeapon2()
            {
                testPlanet.AddWeapon(testWeapon);
                int expCount = 1;
                Assert.Throws<InvalidOperationException>(() =>
                {
                    testPlanet.AddWeapon(testWeapon);
                });
            }

            [Test]
            public void RemoveWep()
            {
                testPlanet.AddWeapon(testWeapon);
                int expCount = 0;
                testPlanet.RemoveWeapon(testWeapon.Name);
                Assert.AreEqual(expCount, testPlanet.Weapons.Count);
            }

            [Test]
            public void UpgradeExcep()
            {
                Assert.Throws<InvalidOperationException>(() =>
                {
                    testPlanet.UpgradeWeapon("sadas");
                });
            }

            [Test]
            public void Upgrade()
            {
                double expDesLevel = 101;
                testPlanet.AddWeapon(testWeapon);
                testPlanet.UpgradeWeapon("Trident");
                Weapon wep = testPlanet.Weapons.FirstOrDefault(w => w.Name == "Trident");
                Assert.AreEqual(expDesLevel, wep.DestructionLevel);
            }

            [Test]
            public void DestroOpp()
            {
                Planet enemy = new Planet("Pluto", 2000);
                Weapon enemW = new Weapon("kap", 10, 102);
                enemy.AddWeapon(enemW);
                Weapon wp = new Weapon("s", 20, 90);
                testPlanet.AddWeapon(wp);

                Assert.Throws<InvalidOperationException>(() =>
                {
                    testPlanet.DestructOpponent(enemy);
                });
            }

            [Test]
            public void DestuctionComplete()
            {
                Planet enemy = new Planet("Pluto", 2000);
                Weapon enemW = new Weapon("kap", 10, 90);
                enemy.AddWeapon(enemW);
                string expectedMessage = $"{enemy.Name} is destructed!";
                testPlanet.AddWeapon(testWeapon);

                string actualMessage = testPlanet.DestructOpponent(enemy);
                Assert.AreEqual(expectedMessage, actualMessage);
            }
        }
    }
}
