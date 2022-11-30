namespace DatabaseExtended.Tests
{
    using ExtendedDatabase;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        private Person person;
        private Database testDb;

        [SetUp]
        public void SetUp()
        {
            person = new Person(1234567, "Ivan");
            testDb = new Database(person);
        }

        [Test]
        public void TestIfPersonConstructorSetsValuesCorrectly()
        {
            Person person = new Person(12345, "Geroge");

            string expectedName = "Geroge";
            long expectedId = 12345;

            Assert.AreEqual(expectedId, person.Id);
            Assert.AreEqual(expectedName, person.UserName);
        }

        [Test]
        public void TestIfDatabaseConstructorSetsPersonsCorrectly()
        {
            Person person1 = new Person(123, "Ivan");
            Person person2 = new Person(12345, "Gerorge");

            Database databese = new Database(person1, person2);
            int expectedCount = 2;

            Assert.AreEqual(expectedCount, databese.Count);
        }

        [Test]
        public void TestIfConstructorSetsPersonsCorrectly()
        {
            Database db = new Database(person);
            Person expectedPerson = db.FindById(person.Id);
            int expectedPersonId = 1234567;
            string expectedName = "Ivan";

            Assert.AreEqual(expectedPersonId, expectedPerson.Id);
            Assert.AreEqual(expectedName, expectedPerson.UserName);
        }

        [Test]
        public void TestIfConstructsIsCheckingForTheRangeOfTheArray()
        {
            Person person = new Person(1, "awdw");
            Person person2 = new Person(2, "fdf");
            Person person3 = new Person(3, "sadsa");
            Person person4 = new Person(4, "wew");
            Person person5 = new Person(5, "hgh");
            Person person6 = new Person(6, "gh");
            Person person7 = new Person(7, "f");
            Person person8 = new Person(8, "we");
            Person person9 = new Person(9, "sd");
            Person person10 = new Person(10, "b");
            Person person11 = new Person(11, "c");
            Person person12 = new Person(12, "u");
            Person person13 = new Person(13, "ty");
            Person person14 = new Person(14, "t");
            Person person15 = new Person(15, "r");
            Person person16 = new Person(16, "e");
            Person person17 = new Person(17, "w");
            Assert.Throws<ArgumentException>(() =>
            {
                Database db = new Database(person, person2, person3, person4, person5, person6, person7, person8, person9, person10, person11, person12, person13, person14, person15, person16, person17);
            }, "Provided data length should be in range [0..16]!");
        }

        [Test]
        public void TestIfConstructsIsCheckingForTheRangeOfTheArrayWithTheLastNumber()
        {
            Person person = new Person(1, "awdw");
            Person person2 = new Person(2, "fdf");
            Person person3 = new Person(3, "sadsa");
            Person person4 = new Person(4, "wew");
            Person person5 = new Person(5, "hgh");
            Person person6 = new Person(6, "gh");
            Person person7 = new Person(7, "f");
            Person person8 = new Person(8, "we");
            Person person9 = new Person(9, "sd");
            Person person10 = new Person(10, "b");
            Person person11 = new Person(11, "c");
            Person person12 = new Person(12, "u");
            Person person13 = new Person(13, "ty");
            Person person14 = new Person(14, "t");
            Person person15 = new Person(15, "r");
            Person person16 = new Person(16, "e");


            Database db = new Database(person, person2, person3, person4, person5, person6, person7, person8, person9, person10, person11, person12, person13, person14, person15, person16);

            Assert.AreEqual(16, db.Count);

        }

        [Test]
        public void TestingIfAddMethodIsThrowingExceptionIfTheUserNameIsAlreadyExisting()
        {
            Person personDumxdmy = new Person(123, "Bob");
            Person personDumxdmy2 = new Person(1234, "Bob");
            testDb.Add(personDumxdmy);

            Assert.Throws<InvalidOperationException>(() =>
            {
                testDb.Add(personDumxdmy2);
            }, "There is already user with this username!");
        }

        [Test]
        public void TestingIfAddMethodIsThrowingExceptionIfTheUserIdIsAlreadyExisting()
        {
            Person personDumxdmy = new Person(1234, "Boba");
            Person personDumxdmy2 = new Person(1234, "Bob");
            testDb.Add(personDumxdmy);

            Assert.Throws<InvalidOperationException>(() =>
            {
                testDb.Add(personDumxdmy2);
            }, "There is already user with this Id!");
        }

        [Test]
        public void TestIfAddMethodWillThrowExceptionIfWeAddMorePersons()
        {

            Person person = new Person(1, "awdw");
            Person person2 = new Person(2, "fdf");
            Person person3 = new Person(3, "sadsa");
            Person person4 = new Person(4, "wew");
            Person person5 = new Person(5, "hgh");
            Person person6 = new Person(6, "gh");
            Person person7 = new Person(7, "f");
            Person person8 = new Person(8, "we");
            Person person9 = new Person(9, "sd");
            Person person10 = new Person(10, "b");
            Person person11 = new Person(11, "c");
            Person person12 = new Person(12, "u");
            Person person13 = new Person(13, "ty");
            Person person14 = new Person(14, "t");
            Person person15 = new Person(15, "r");
            Person person16 = new Person(16, "e");
            Person person17 = new Person(17, "wewer");

            Database db = new Database(person, person2, person3, person4, person5, person6, person7, person8, person9, person10, person11, person12, person13, person14, person15, person16);

            Assert.Throws<InvalidOperationException>(() =>
            {
                db.Add(person17);
            });
        }

        [Test]
        public void TestIfAddMethodAddsPersonSuccesfully()
        {
            int expectedCount = 2;
            Person person2 = new Person(12313, "Garab");

            testDb.Add(person2);

            Assert.AreEqual(expectedCount, testDb.Count);
        }

        [Test]
        public void TestIfTheAddedPersonIsCorrect()
        {
            Person person1 = new Person(123, "Niki");
            testDb.Add(person1);
            Person expectedPerson = testDb.FindByUsername("Niki");
            Assert.AreEqual(person1.UserName, expectedPerson.UserName);
            Assert.AreEqual(person1.Id, expectedPerson.Id);
        }

        [Test]
        public void TestIfRemoveThrowsExceptionIfTheCollectionIsEmpty()
        {
            Database db = new Database();

            Assert.Throws<InvalidOperationException>(() =>
            {
                db.Remove();
            });
        }

        [Test]
        public void TestIfRemoveMethodIsRemovingPerson()
        {
            int expectedCount = 0;
            testDb.Remove();

            Assert.AreEqual(expectedCount, testDb.Count);
        }

        [Test]
        public void TestIfFindByIdMethodWorksProperly()
        {
            Person expectedPerson = new Person(1234567, "Ivan");
            Person returnedPerson = testDb.FindById(1234567);

            Assert.AreEqual(expectedPerson.Id, returnedPerson.Id);
        }

        [Test]
        public void TestIfFindByIdWillThrowExceptionIfIdIsNegative()
        {
            int fakeId = -1234;

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                testDb.FindById(fakeId);
            }, "Id should be a positive number!");
        }

        [Test]
        public void TestIfFindByIdWillThrowExceptionIfUserIdDoesNotExist()
        {
            int fakeId = 12345678;

            Assert.Throws<InvalidOperationException>(() =>
            {
                testDb.FindById(fakeId);
            }, "No user is present by this ID!");
        }

        [Test]
        public void TestIfFindByUserNameWorksProperly()
        {
            Person expectedPerson = new Person(1234567, "Ivan");
            Person returnedPerson = testDb.FindByUsername("Ivan");

            Assert.AreEqual(expectedPerson.UserName, returnedPerson.UserName);
        }

        [TestCase("")]
        public void TestIfFindByUserNameThrowsExceptionIfItIsNull(string userName)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                testDb.FindByUsername(userName);
            }, "Username parameter is null!");
        }

        [Test]
        public void TestIfFindByUserNameThrowsExceptionIfTheUserNameDoesNotExist()
        {
            string fakeUserName = "   ";

            Assert.Throws<InvalidOperationException>(() =>
            {
                testDb.FindByUsername(fakeUserName);
            }, "No user is present by this username!");
        }
    }
}