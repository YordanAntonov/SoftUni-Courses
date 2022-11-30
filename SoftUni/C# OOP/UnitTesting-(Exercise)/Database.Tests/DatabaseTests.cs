namespace Database.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class DatabaseTests
    {
        //Array capacity must be max 16
        //Add() should add element on the last free cell else throw exception

        //Delete removes the last element, if the array is empty throw exception
        //Check the constructor functionality

        Database testDb;

        [SetUp]
        public void SetUp()
        {
            testDb = new Database();
        }

        //******************************************************************************************************************************************************************************

        [TestCase(new int[] { })]
        [TestCase(new int[] { 1 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void ConstructorShouldBeAbleToEnterCorrectlyTheValuesGiven(int[] values)
        {
            Database db = new Database(values);

            int actualCount = db.Count;
            int expectedCount = values.Length;
            Assert.AreEqual(expectedCount, actualCount);
        }


        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 })]
        public void ConstructorShouldNotEnterValuesItShouldThrowException(int[] values)
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                Database db = new Database(values);
            }, "Array's capacity must be exactly 16 integers!");
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 })]
        public void TestIfValuesAreCorrectAfterEnteringThemInTheDatabase(int[] values)
        {
            Database db = new Database(values);

            int[] expectedValues = values;
            int[] enteredValues = db.Fetch();

            CollectionAssert.AreEqual(expectedValues, enteredValues);
        }

        //******************************************************************************************************************************************************************************

        [TestCase(new int[] { })]
        [TestCase(new int[] { 1, 2, 3, 4 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 })]
        public void TestingAddMethodIsAddingElementsCorrectly(int[] values)
        {
            Database db = new Database(values);
            db.Add(1);

            int expectedCount = values.Length + 1;
            int currentCount = db.Count;

            Assert.AreEqual(expectedCount, currentCount);
        }
        //******************************************************************************************************************************************************************************

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void TestingIfAddMethodWillThrowExceptionWhenWeTryToAddMoreElementsThenTheMax(int[] values)
        {
            Database db = new Database(values);
            Assert.Throws<InvalidOperationException>(() =>
            {
                db.Add(1);
            }, "Array's capacity must be exactly 16 integers!");
        }

        //******************************************************************************************************************************************************************************
        [Test]
        public void TestingAddingElementToEmptyDb()
        {
            testDb.Add(1);
            int expectedCount = 1;

            Assert.AreEqual(expectedCount, testDb.Count);
        }

        //******************************************************************************************************************************************************************************

        [Test]
        public void RemoveShouldDeleteTheLastElementInTheArrayCollection()
        {
            for (int i = 0; i < 10; i++)
            {
                testDb.Add(i);
            }
            testDb.Remove();

            int expectedCount = 9;

            Assert.AreEqual(expectedCount, testDb.Count);
        }

        [Test]
        public void RemoveShouldRemoveExaclyTheLastElementInTheCollection()
        {
            for (int i = 1; i <= 10; i++)
            {
                testDb.Add(i);
            }

            testDb.Remove();
            int[] expectedArray = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int[] test = testDb.Fetch();

            CollectionAssert.AreEqual(expectedArray, test);
        }

        [Test]
        public void DeleteShouldNotBeAbleToRemoveElementFromEmptyArray()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                testDb.Remove();
            }, "The collection is empty!");
        }

        //******************************************************************************************************************************************************************************

        [Test]
        public void TestingIfFetchMethodIsReturningTheCorrectArray()
        {
            Database db = new Database(new int[] { 1, 2, 3, 4, 5, 6 });

            int[] copyArray = new int[db.Count];
            int[] fetchArray = db.Fetch();
            for (int i = 0; i < fetchArray.Length; i++)
            {
                copyArray[i] =  fetchArray[i];
            }

            CollectionAssert.AreEqual(copyArray, fetchArray);
        }

        //******************************************************************************************************************************************************************************

        [TestCase(new int[] {1, 2, 3})]
        [TestCase(new int[] {})]
        [TestCase(new int[] {1, 2, 3, 4, 5, 6, 7})]
        public void CountShouldReturnTheCorrectCount(int[] values)
        {
            Database db = new Database(values);

            int ExpectedCount = values.Length;
            int actualCount = db.Count;

            Assert.AreEqual(ExpectedCount, actualCount);
        }
    }

}
