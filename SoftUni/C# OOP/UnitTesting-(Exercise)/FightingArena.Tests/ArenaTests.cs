namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [TestFixture]
    public class ArenaTests
    {
        private Arena testArena;
        private Warrior attacker;
        private Warrior defender;

        [SetUp]
        public void SetUp()
        {
            testArena = new Arena();
            attacker = new Warrior("Ivo", 80, 150);
            defender = new Warrior("George", 70, 200);
        }

        [Test]
        public void TestConstructorForCreatingListOfWarriors()
        {
            Arena arena = new Arena();
            arena.Enroll(attacker);
            Warrior expectedWarrior = attacker;
            Warrior actualWarrior = arena.Warriors.FirstOrDefault(n => n.Name == expectedWarrior.Name);
            Assert.AreEqual(expectedWarrior.Name, actualWarrior.Name);
        }

        [Test]
        public void TestTheReadOnlyWarriorsList()
        {
            List<Warrior> warriors = new List<Warrior>() { attacker, defender };
            testArena.Enroll(attacker);
            testArena.Enroll(defender);

            CollectionAssert.AreEqual(warriors, testArena.Warriors);
        }

        [Test]
        public void TestIfCountMethodReturnsCorrectValue()
        {
            testArena.Enroll(attacker);
            testArena.Enroll(defender);

            int expectedCount = 2;

            Assert.AreEqual(expectedCount, testArena.Count);
        }

        [Test]
        public void EnrollMethodShouldThrowExceptionIfWarriorAlreadyIsEnrolled()
        {
            testArena.Enroll(attacker);

            Assert.Throws<InvalidOperationException>(() =>
            {
                testArena.Enroll(attacker);
            });
        }

        [Test]
        public void EnrollShouldWorkCorrectly()
        {
            Warrior expectedWarrior = attacker;
            testArena.Enroll(attacker);
            Warrior actualWarrior = testArena.Warriors.FirstOrDefault(w => w.Name== expectedWarrior.Name);

            Assert.AreEqual(expectedWarrior, actualWarrior);
        }

        [Test]
        public void FightShouldThrowExceptionIfWarriorIsNotEnrolled()
        {
            testArena.Enroll(attacker);
            Assert.Throws<InvalidOperationException>(() =>
            {
                testArena.Fight(attacker.Name, defender.Name);
            });
        }

        [Test]
        public void FightShouldThorwExceptionTwo()
        {
            testArena.Enroll(defender);
            Assert.Throws<InvalidOperationException>(() =>
            {
                testArena.Fight(attacker.Name, defender.Name);
            });
        }

        [Test]
        public void FightShouldWorkProperly()
        {
            testArena.Enroll(attacker);
            testArena.Enroll(defender);

            int expectedDefenderHp = defender.HP - attacker.Damage;

            testArena.Fight(attacker.Name, defender.Name);
            Assert.AreEqual(expectedDefenderHp, defender.HP);
        }
    }
}
