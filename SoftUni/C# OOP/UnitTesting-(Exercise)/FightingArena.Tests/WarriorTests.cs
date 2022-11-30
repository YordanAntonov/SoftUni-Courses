namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;
    using System.Diagnostics.Contracts;

    [TestFixture]
    public class WarriorTests
    {
        private Warrior testWarriorOne;
        private Warrior testWarriorTwo;
        private const int minimumAtackHp = 30;

        [SetUp]
        public void SetUp()
        {
            testWarriorOne = new Warrior("Ivan", 50, 100);
            testWarriorTwo = new Warrior("Gosho", 100, 100);
        }

        [Test]
        public void ConstructorShouldBeWorkingProperly()
        {
            Warrior warrior = new Warrior("Ivo", 50, 100);
            string expectedName = "Ivo";
            int expectedHp = 100;
            int expectedDamage = 50;

            Assert.AreEqual(expectedName, warrior.Name);
            Assert.AreEqual(expectedHp, warrior.HP);
            Assert.AreEqual(expectedDamage, warrior.Damage);
        }

        [TestCase("")]
        [TestCase("  ")]
        [TestCase(null)]
        public void ConstructorShouldThrowInvalidNameException(string value)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warr = new Warrior(value, 50, 100);
            });
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-25)]
        public void ConstructorShouldThrowInvalidDamageException(int damage)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warr = new Warrior("Ivo", damage, 100);
            });
        }

        [TestCase(-1)]
        [TestCase(-25)]
        public void ConstructorShouldThrowInvalidHPException(int health)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warr = new Warrior("Ivo", 50, health);
            });
        }

        //**********************************AtackMethod************************************

        [TestCase(30)]
        [TestCase(29)]
        [TestCase(1)]
        public void AtackerShouldNotBeAbleToAtackIfHPIsEqualOrLowerThenMinAtackHP(int hp)
        {
            Warrior warr = new Warrior("Ivo", 30, hp);

            Assert.Throws<InvalidOperationException>(() =>
            {
                warr.Attack(testWarriorOne);
            });
        }

        [TestCase(30)]
        [TestCase(29)]
        [TestCase(1)]
        public void TheAtackedShouldNotBeAbleToBeAtackedIfHPIsEqualOrLowerThenMinAtackHP(int hp)
        {
            Warrior enemy = new Warrior("Ivo", 50, hp);

            Assert.Throws<InvalidOperationException>(() =>
            {
                testWarriorOne.Attack(enemy);
            });
        }

        [Test]
        public void AtackerShouldNotAtackStrongerEnemies()
        {
            Warrior warrior = new Warrior("Ivo", 50, 49);

            Assert.Throws<InvalidOperationException>(() =>
            {
                warrior.Attack(testWarriorOne);
            });
        }

        [Test]
        public void TestIfWarriorHealthDropsAfterAtack()
        {
            int epxectedHp = testWarriorTwo.HP - testWarriorOne.Damage;
            int expHp = testWarriorOne.HP - testWarriorTwo.Damage;
            testWarriorTwo.Attack(testWarriorOne);
            Assert.AreEqual(epxectedHp, testWarriorTwo.HP);
            Assert.AreEqual(expHp, testWarriorOne.HP);
        }

        [Test]
        public void TestIfHpIsSetToZeroAfterFatalAtack()
        {
            Warrior strongWarr = new Warrior("Garo", 200, 200);
            int expectedHp = 0;
            strongWarr.Attack(testWarriorTwo);

            Assert.AreEqual(expectedHp, testWarriorTwo.HP);
        }

        [Test]
        public void TestIfEnemyHealthDropsIfNotDead()
        {
            Warrior enemy = new Warrior("Ivds", 50, 51);
            int expectedHp = 1;
            testWarriorOne.Attack(enemy);

            Assert.AreEqual(expectedHp,enemy.HP);
        }
    }
}