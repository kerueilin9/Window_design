using Microsoft.VisualStudio.TestTools.UnitTesting;
using Homework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework.Tests
{
    [TestClass()]
    public class BookCategoryTests
    {
        BookCategory category;
        BookCategory category1;
        string name = "123";
        Book book = new Book("1", "2", "3", "4", "5");
        private List<Book> books = new List<Book>();

        [TestInitialize()]
        public void Initialize()
        {
            books.Add(book);
            category = new BookCategory(name);
            category1 = new BookCategory(name, books);
        }

        [TestMethod()]
        public void BookCategoryTest()
        {
            Assert.AreEqual(name, category.GetCategoryName());
            Assert.AreEqual(name, category1.GetCategoryName());
            Assert.AreEqual(true, Enumerable.SequenceEqual(books.ToArray(), category1.GetBooks().ToArray()));
        }

        [TestMethod()]
        public void AddBookTest()
        {
            category.AddBook(book);
            Assert.AreEqual(true, Enumerable.SequenceEqual(books.ToArray(), category1.GetBooks().ToArray()));
        }

        [TestMethod()]
        public void DeleteBookTest()
        {
            Book book1 = new Book("123", "123", "123", "123", "123");
            category1.AddBook(book1);
            category1.DeleteBook(book1);
            Assert.AreEqual(true, Enumerable.SequenceEqual(books.ToArray(), category1.GetBooks().ToArray()));
        }

        [TestMethod()]
        public void SetCategoryNameTest()
        {
            category.SetCategoryName("12345");
            Assert.AreEqual("12345", category.GetCategoryName());
        }

        [TestMethod()]
        public void GetBookCountTest()
        {
            Assert.AreEqual(1, category1.GetBookCount());
        }
    }
}