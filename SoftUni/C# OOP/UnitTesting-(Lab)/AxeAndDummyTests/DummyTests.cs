using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        private Axe axe;
        private Dummy dummy;
        private int axeAtack;
        private int axeDurability;
        private int dummyHealth;
        private int dummyExp;
        private Dummy deadDummy;

        [SetUp]
        public void Setup()
        {
            axeAtack = 10;
            axeDurability = 15;
            axe = new Axe(axeAtack, axeDurability);

            dummyHealth = 15;
            dummyExp = 50;
            dummy = new Dummy(dummyHealth, dummyExp);

            deadDummy = new Dummy(dummyHealth, dummyExp);
            deadDummy.TakeAttack(dummyHealth + 10);
        }

        [Test]
        public void Test_DummyConstructor_SetsValues_Correctly()
        {
            Assert.AreEqual(dummyHealth, dummy.Health);
        }

        [Test]
        public void Test_DummyLoosesHealth()
        {
            dummy.TakeAttack(axe.AttackPoints);

            Assert.AreEqual(dummyHealth - axe.AttackPoints, dummy.Health);
        }

        [Test]
        public void Test_DummyDieing_IfHealthIsZero()
        {
            dummy.TakeAttack(dummyHealth);

            Assert.Throws<InvalidOperationException>(() =>
            {
                dummy.TakeAttack(1);
            });
        }

        [Test]
        public void Test_DummyDieing_IfHealthIsZeroOrBelow()
        {           
            Assert.Throws<InvalidOperationException>(() =>
            {
                deadDummy.TakeAttack(1);
            });
        }

        [Test]
        public void Dummy_Should_Give_Experience_When_Dead()//Dummy should give EXP when it is dead
        {
            int givenExperience = deadDummy.GiveExperience();
            Assert.AreEqual(dummyExp, givenExperience);
        }

        [Test]
        public void Dummy_ShouldNot_Give_EXP_WhenAlive()//Dummy should not give EXP when it is Alive
        {                       
                Assert.Throws<InvalidOperationException>(() =>
                {
                    dummy.GiveExperience();
                });          
        }
    }
}
