using FrontDeskApp;
using NUnit.Framework;
using System;
using System.Security.Cryptography;

namespace BookigApp.Tests
{
    public class Tests
    {
        private Hotel testHotel;
        private Room testRoom;
        private Booking testBooking;

        [SetUp]
        public void Setup()
        {
            testRoom = new Room(2, 20);
            testBooking = new Booking(1, testRoom, 7);
            testHotel = new Hotel("Skala", 5);
        }

        [Test]
        public void TestingRoomConstrCorrect()
        {
            Room room = new Room(5, 75.20);
            int expCapac = 5;

            Assert.AreEqual(expCapac, room.BedCapacity);
        }

        [Test]
        public void TestingRoomConstrCorrect2()
        {
            Room room = new Room(5, 75.20);
            double expPrice = 75.20;

            Assert.AreEqual(expPrice, room.PricePerNight);
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-10)]
        public void TestErrorWhenNegativeCapac(int value)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Room room = new Room(value, 20.23);
            });
        }

        [TestCase(0)]
        [TestCase(-1.19)]
        [TestCase(-10.23)]
        public void TestErrorWhenNegativePrice(double value)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Room room = new Room(10, value);
            });
        }

        [Test]
        public void TestConstForCorrectBookNum()
        {
            Room room = new Room(5, 2.20);
            Booking book = new Booking(1, room, 6);
            Assert.AreEqual(1, book.BookingNumber);
        }

        [Test]
        public void TestConstForCorrectRoom()
        {
            Room room = new Room(5, 2.20);
            Booking book = new Booking(1, room, 6);
            Room expectedRoom = room;
            Assert.AreEqual(room, book.Room);
        }

        [Test]
        public void TestConstForCorrectDuration()
        {
            Room room = new Room(5, 2.20);
            Booking book = new Booking(1, room, 6);
            Assert.AreEqual(6, book.ResidenceDuration);
        }

        [Test]
        public void TestHotelConstrSuccsefullySetFullName()
        {
            string expName = "Skala";
            Assert.AreEqual(expName, testHotel.FullName);
        }

        [Test]
        public void TestHotelConstrSuccsefullySetCategory()
        {
            int expCat = 5;
            Assert.AreEqual(expCat, testHotel.Category);
        }

        [Test]
        public void TestHotelConstrSuccsefullySetRoomList()
        {
            int epxectedRoomListCount = 0;
            Assert.AreEqual(epxectedRoomListCount, testHotel.Rooms.Count);
        }

        [Test]
        public void TestHotelConstrSuccsefullySetBookingList()
        {
            int epxectedBookListCount = 0;
            Assert.AreEqual(epxectedBookListCount, testHotel.Bookings.Count);
        }

        [TestCase(null)]
        [TestCase("  ")]
        [TestCase("")]
        public void NameExceptNullOrWhiteSpace(string value)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {

                Hotel hotel = new Hotel(value, 5);

            });
        }

        [TestCase(0)]
        [TestCase(6)]
        [TestCase(-1)]
        [TestCase(7)]
        public void CategotyExceptLowerOfBigger(int value)
        {
            Assert.Throws<ArgumentException>(() =>
            {

                Hotel hotel = new Hotel("Rom", value);
            });
        }

        [Test]
        public void TestTurnOverCorrect()
        {
            double expTurn = 0;
            Assert.AreEqual(expTurn, testHotel.Turnover);
        }

        [Test]
        public void TestAddRoomCorr()
        {
            int epxRoomCount = 1;
            testHotel.AddRoom(testRoom);
            Assert.AreEqual(epxRoomCount, testHotel.Rooms.Count);
        }

        [TestCase(0)]
        [TestCase(-1)]
        public void TestBookRoomThrowExceptionUnderZeroAdult(int value)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                testHotel.BookRoom(value, 2, 7, 100);
            });
        }

        [TestCase(-1)]
        [TestCase(-10)]
        public void TestBookRoomThrowExceptionUnderZeroChildren(int value)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                testHotel.BookRoom(2, value, 7, 100);
            });
        }

        [TestCase(0)]
        [TestCase(-1)]
        public void TestBookRoomThrowExceptionResidentDuration(int value)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                testHotel.BookRoom(2, 2, value, 100);
            });
        }

        //testRoom = new Room(2, 20.20);
        [TestCase(5)]
        [TestCase(3)]
        [TestCase(2)]
        [TestCase(4)]
        [TestCase(1)]
        public void BookingCorrect(int value)
        {
            testHotel.AddRoom(testRoom);
            testHotel.BookRoom(2, 0, value, 100);
            int expectedCountBooking = 1;
            Assert.AreEqual(expectedCountBooking, testHotel.Bookings.Count);
        }

        [Test]
        public void TurnOverIncrease()
        {
            testHotel.AddRoom(testRoom);
            testHotel.BookRoom(2, 0, 1, 100);
            double expectedTurn = 1 * testRoom.PricePerNight;
            Assert.AreEqual(expectedTurn, testHotel.Turnover);
        }


    }
}