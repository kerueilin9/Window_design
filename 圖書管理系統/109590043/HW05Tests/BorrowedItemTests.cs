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
    public class BorrowedItemTests
    {
        BorrowedItem borrowedItem;
        DateTime _dateTime;
        Book book;
        private readonly string[] testArray =
        {
            "1",
            "1",
            "",
            "1",
            "2010/06/23",
            "2010/07/23",
            "",
            "",
            ""
        };

        //Test
        [TestInitialize()]
        public void Initialize()
        {
            _dateTime = new DateTime(2010, 6, 23);
            book = new Book("", "", "", "", "");
            borrowedItem = new BorrowedItem(_dateTime, book);
        }

        //Test
        [TestMethod()]
        public void BorrowedItemTest()
        {
            Assert.AreEqual(_dateTime, borrowedItem.DateTime);
            Assert.AreEqual(book, borrowedItem.Book);
        }

        //Test
        [TestMethod()]
        public void GetDateTimeStringTest()
        {
            Assert.AreEqual("2010/06/23", borrowedItem.GetDateTimeString());
        }

        //Test
        [TestMethod()]
        public void GetArrayTest()
        {
            Assert.AreEqual(true, Enumerable.SequenceEqual(testArray, borrowedItem.GetArray()));
        }
    }
}