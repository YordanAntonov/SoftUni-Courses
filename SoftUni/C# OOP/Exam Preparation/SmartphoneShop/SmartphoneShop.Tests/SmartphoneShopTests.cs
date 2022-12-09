using NUnit.Framework;
using System;

namespace SmartphoneShop.Tests
{
    [TestFixture]
    public class SmartphoneShopTests
    {
        private Smartphone phone;
        private Shop shop;

        [SetUp]
        public void SetUp()
        {
            phone = new Smartphone("Samsung", 100);
            shop = new Shop(10);
        }

        [Test]
        public void TestSmarthPhoneConstructorShouldSetValuesCorrect()
        {
            Smartphone smartPhone = new Smartphone("IPhone", 100);
            Assert.AreEqual("IPhone", smartPhone.ModelName);
            Assert.AreEqual(100, smartPhone.MaximumBatteryCharge);
            Assert.AreEqual(100, smartPhone.CurrentBateryCharge);
        }

        [Test]
        public void TestingShopConstructorWorking()
        {
            Shop shop2 = new Shop(100);
            int expectedCapacity = 100;

            Assert.AreEqual(expectedCapacity, shop2.Capacity);
            Assert.AreEqual(0, shop2.Count);
        }

        [TestCase(-1)]
        [TestCase(-50)]
        [TestCase(-100)]
        public void CapacityPropertyShouldThrowException(int value)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Shop shop = new Shop(value);
            });
        }

        [Test]
        public void CountMethodShouldReturnCorrectly()
        {
            Smartphone ph = new Smartphone("sda", 100);
            Smartphone ph2 = new Smartphone("sda1", 100);
            Smartphone ph23 = new Smartphone("sd1a1", 100);
            shop.Add(ph);
            shop.Add(ph2);
            shop.Add(ph23);
            int expectedCount = 3;
            Assert.AreEqual(expectedCount, shop.Count);
        }

        [Test]
        public void ShopCapacityShouldThrowExceptionIfShopIsFull()
        {
            Shop shop2 = new Shop(1);
            Smartphone ph = new Smartphone("sda", 100);
            Smartphone ph2 = new Smartphone("sda1", 100);
            shop2.Add(ph);

            Assert.Throws<InvalidOperationException>(() =>
            {
                shop2.Add(ph2);
            });
            
        }

        [Test]
        public void ShopAddMethodShouldThrowExceptionIfTheSamePhoneExist()
        {
            Smartphone ph = new Smartphone("samsung", 100);
            Smartphone ph2 = new Smartphone("samsung", 100);
            shop.Add(ph);
            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.Add(ph2);
            });
        }

        [Test]
        public void AddMethodShouldAddElementSuccesfully()
        {
            int expectedCount = 1;
            shop.Add(phone);

            Assert.AreEqual(expectedCount, shop.Count);
        }

        [Test]
        public void RemovingNullPhoneWillThrowException()
        {
            shop.Add(phone);
            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.Remove("smart");
            });
        }

        [Test]
        public void RemoveShouldRemovePhoneSuccesfully()
        {
            shop.Add(phone);
            Smartphone smart = new Smartphone("Huyway", 100);
            shop.Add(smart);
            int expectedCount = 1;
            shop.Remove("Huyway");

            Assert.AreEqual(expectedCount, shop.Count);
        }

        [Test]
        public void TestingNullPhoneShouldThrowException()
        {
            shop.Add(phone);

            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.TestPhone("samarasung", 50);
            });
        }

        [TestCase(51)]
        [TestCase(70)]
        public void TestingIfTestPhoneBatteryIsLowShouldThrowException(int usage)
        {
            Smartphone smart = new Smartphone("Nokia", 50);
            shop.Add(smart);

            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.TestPhone("Nokia", usage);
            });
        }

        [Test]
        public void TestingPhoneShouldBeSuccesfull()
        {
            shop.Add(phone);
            int expectedBatteryChargeAfteTest = 50;
            shop.TestPhone("Samsung", 50);

            Assert.AreEqual(expectedBatteryChargeAfteTest, phone.CurrentBateryCharge);
        }

        [Test]
        public void ShouldNotChargeNullPhoneThrowException()
        {
            shop.Add(phone);

            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.ChargePhone("smasung");
            });
        }

        [Test]
        public void ShouldChargePhoneCorrectly()
        {
            shop.Add(phone);
            shop.TestPhone("Samsung", 60);
            int expectedBatteryCharge = 100;

            shop.ChargePhone("Samsung");

            Assert.AreEqual(expectedBatteryCharge, phone.CurrentBateryCharge);
        }
    }
}