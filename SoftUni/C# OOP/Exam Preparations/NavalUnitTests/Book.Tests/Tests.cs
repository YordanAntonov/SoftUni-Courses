namespace Book.Tests
{
    using System;

    using NUnit.Framework;
    using static System.Net.Mime.MediaTypeNames;

    [TestFixture]
    public class Tests
    {
        private Book testBook;

        [SetUp]
        public void SetUp()
        {
            testBook = new Book("Bogat", "Robert");
        }

        [Test]
        public void TestConstructorCorrect()
        {
            string expectedName = "Bogat";
            string expAuthor = "Robert";

            Assert.AreEqual(expectedName, testBook.BookName);
            Assert.AreEqual(expAuthor, testBook.Author);
        }

        [Test]
        public void TestDictionary()
        {
            int expectedCount = 0;
            Book book = new Book("sd", "sadsa");
            Assert.AreEqual(expectedCount, book.FootnoteCount);
        }

        [TestCase(null)]
        [TestCase("")]
        public void NameThrowException(string value)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Book book = new Book(value, "sada");
            });
        }

        [TestCase(null)]
        [TestCase("")]
        public void AuthorThrowException(string value)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Book book = new Book("sdad", value);
            });
        }

        [Test]
        public void FootNoteException()
        {
            testBook.AddFootnote(1, "aide");
            Assert.Throws<InvalidOperationException>(() =>
            {
                testBook.AddFootnote(1, "aide");
            });
        }

        [Test]
        public void AddFootNoteCorrect()
        {
            int expectedCount = 1;
            testBook.AddFootnote(1, "aide");
            Assert.AreEqual(expectedCount, testBook.FootnoteCount);
        }

        [Test]
        public void FindFootNoteException()
        {
            
            Assert.Throws<InvalidOperationException>(() =>
            {
                testBook.FindFootnote(1);
            });
        }

        [Test]
        public void FindNoteCorrect()
        {
            testBook.AddFootnote(1, "aide");
            string expMessage = $"Footnote #1: aide";
            string actualMessage = testBook.FindFootnote(1);
            Assert.AreEqual(expMessage, actualMessage);
        }

        [Test]
        public void AlterExcep()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                testBook.AlterFootnote(1, "aide");
            });
        }

        [Test]
        public void AlterFoodCorrect()
        {
            string newText = "arebe";
            string expectedText = $"Footnote #1: {newText}";
            testBook.AddFootnote(1, "aide");
            testBook.AlterFootnote(1, newText);
            string footNote = testBook.FindFootnote(1);
            Assert.AreEqual(expectedText, footNote);
        }




    }
}