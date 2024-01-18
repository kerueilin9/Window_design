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
    public class BookItemTests
    {
        BookItem bookItem;
        BookItem bookItem1;
        Book book;

        //Test
        [TestInitialize()]
        public void Initialize()
        {
            book = new Book("", "", "", "", "");
            bookItem = new BookItem();
            bookItem1 = new BookItem(5, book);
        }

        //Test
        [TestMethod()]
        public void BookItemTest()
        {
            Assert.AreEqual(0, bookItem.GetBookCount());
            Assert.AreEqual(null, bookItem.GetBook());
        }

        //Test
        [TestMethod()]
        public void BookItemTest1()
        {
            Assert.AreEqual(5, bookItem1.GetBookCount());
            Assert.AreEqual(book, bookItem1.GetBook());
        }

        //Test
        [TestMethod()]
        public void SetBookCountTest()
        {
            bookItem.SetBookCount(1);
            Assert.AreEqual(1, bookItem.GetBookCount());
        }

        //Test
        [TestMethod()]
        public void SetBookTest()
        {
            bookItem.SetBook(book);
            Assert.AreEqual(book, bookItem.GetBook());
        }

        //Test
        [TestMethod()]
        public void SetPlusBookCountTest()
        {
            bookItem1.SetPlusBookCount(3);
            Assert.AreEqual(8, bookItem1.GetBookCount());
        }

        //Test
        [TestMethod()]
        public void SetMinusBookCountTest()
        {
            bookItem1.SetMinusBookCount(3);
            Assert.AreEqual(2, bookItem1.GetBookCount());
        }
    }
}