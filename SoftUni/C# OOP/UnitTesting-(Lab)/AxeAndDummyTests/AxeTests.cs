using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        private Axe axe;
        private Dummy dummy;
        private int atack;
        private int durability;
        private int dummyHealth;
        private int dummyExp;

        [SetUp]
        public void Setup()
        {
            atack = 10;
            durability = 15;
            axe = new Axe(atack, durability);
            dummyHealth = 100;
            dummyExp = 50;
            dummy = new Dummy(dummyHealth, dummyExp);
        }

        [Test]
        public void Test_Axe_Constructor_Should_Set_Data_Properly()
        {

            Assert.AreEqual(atack, axe.AttackPoints);
            Assert.AreEqual(durability, axe.DurabilityPoints);
        }

        [Test]
        public void Test_WhenAxeAtack_LoosesDurability()
        {
            for (int i = 0; i < 5; i++)
            {
                axe.Attack(dummy);
            }
            Assert.AreEqual(durability - 5, axe.DurabilityPoints);
        }

        [Test]
        public void Test_AxeWillBeBroken_When_DurabilityIsZero()
        {
            Axe axe = new Axe(10, 0);

            Assert.Throws<InvalidOperationException>((() =>
            {
                axe.Attack(dummy);
            }));
        }

        [Test]
        public void Test_AxeWillBeBroken_When_DurabilityIsZeroOrBelow()
        {
            Axe axe = new Axe(10, -5);


            Assert.Throws<InvalidOperationException>(() =>
            {
                axe.Attack(dummy);
            });
        }

    }
}