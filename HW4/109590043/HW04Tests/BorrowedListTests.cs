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
    public class BorrowedListTests
    {
        BorrowedList borrowedList;
        List<BorrowedItem> _borrowedItems;
        BorrowedItem borrowedItem;
        DateTime _dateTime;
        Book book;

        [TestInitialize()]
        public void Initialize()
        {
            borrowedList = new BorrowedList();
            _borrowedItems = new List<BorrowedItem>();
            _dateTime = new DateTime(2010, 6, 23);
            book = new Book("", "", "", "", "");
            borrowedItem = new BorrowedItem(_dateTime, book);
        }

        [TestMethod()]
        public void BorrowedListTest()
        {
            Assert.AreEqual(true, Enumerable.SequenceEqual(_borrowedItems.ToArray(), borrowedList.BorrowedItems.ToArray()));
        }

        [TestMethod()]
        public void AddBorrowedListTest()
        {
            borrowedList.AddBorrowedList(borrowedItem);
            Assert.AreEqual(borrowedItem, borrowedList.BorrowedItems.First());
        }

        [TestMethod()]
        public void DeleteBorrowedItemTest()
        {
            borrowedList.AddBorrowedList(borrowedItem);
            borrowedList.AddBorrowedList(borrowedItem);
            borrowedList.DeleteBorrowedItem(borrowedItem);
            _borrowedItems.Add(borrowedItem);
            Assert.AreEqual(true, Enumerable.SequenceEqual(_borrowedItems.ToArray(), borrowedList.BorrowedItems.ToArray()));
        }

        [TestMethod()]
        public void DeleteBorrowedItemUseNameTest()
        {
            borrowedList.AddBorrowedList(borrowedItem);
            borrowedList.AddBorrowedList(borrowedItem);
            borrowedList.DeleteBorrowedItemByName(borrowedItem.Book.GetName());
            _borrowedItems.Add(borrowedItem);
            Assert.AreEqual(true, Enumerable.SequenceEqual(_borrowedItems.ToArray(), borrowedList.BorrowedItems.ToArray()));
        }

        [TestMethod()]
        public void SetTest()
        {
            _borrowedItems.Add(borrowedItem);
            borrowedList.BorrowedItems = _borrowedItems;
            Assert.AreEqual(true, Enumerable.SequenceEqual(_borrowedItems.ToArray(), borrowedList.BorrowedItems.ToArray()));
        }
    }
}