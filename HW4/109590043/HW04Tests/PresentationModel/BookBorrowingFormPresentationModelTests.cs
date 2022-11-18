using Microsoft.VisualStudio.TestTools.UnitTesting;
using Homework.PresentationModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework.PresentationModel.Tests
{
    [TestClass()]
    public class BookBorrowingFormPresentationModelTests
    {
        private Model model;
        BookBorrowingFormPresentationModel presentationModel;
        string book1Name = "微調有差の日系新版面設計 : 一本前所未有、聚焦於「微調細節差很大」的設計參考書";
        string book2Name = "零零落落";
        const string _content = "微調有差の日系新版面設計 : 一本前所未有、聚焦於「微調細節差很大」的設計參考書\n編號：964 8394:2-5 2021\n作者：ingectar-e\n原點出版 : 大雁發行, 2021[民110]";
        readonly string[] array = 
        {
            "",
            "零零落落",
            "1",
            "851.486 8345:2 2022",
            "黃春明",
            "聯合文學, 2022[民111]"
        };

        readonly string[] array1 =
{
            "",
            "微調有差の日系新版面設計 : 一本前所未有、聚焦於「微調細節差很大」的設計參考書",
            "2",
            "964 8394:2-5 2021",
            "ingectar-e",
            "原點出版 : 大雁發行, 2021[民110]"
        };

        //Test
        [TestInitialize()]
        public void Initialize()
        {
            model = new Model("hw4_books_source.txt");
            presentationModel = new BookBorrowingFormPresentationModel(model);
        }

        //Test
        [TestMethod()]
        public void BookBorrowingFormPresentationModelTest()
        {
            model = new Model("hw4_books_source_test.txt");
            presentationModel = new BookBorrowingFormPresentationModel(model);
        }

        //Test
        [TestMethod()]
        public void GetPageTextTest()
        {
            Assert.AreEqual("Page：1/2", presentationModel.GetPageText());
        }

        //Test
        [TestMethod()]
        public void SetPageTextTest()
        {
            presentationModel.SetPageText(1, "6月暢銷書");
            Assert.AreEqual("Page：1/2", presentationModel.GetPageText());
            presentationModel.SetPageText(1, "職場必讀");
            Assert.AreEqual("Page：1/1", presentationModel.GetPageText());
        }

        //Test
        [TestMethod()]
        public void GetCurrentBookContentTest()
        {
            Assert.AreEqual("", presentationModel.GetCurrentBookContent());
        }

        //Test
        [TestMethod()]
        public void SetCurrentBookAndItemTest()
        {
            presentationModel.SetCurrentBookAndItem(model.GetBookByName(book1Name));
            Assert.AreEqual(_content, presentationModel.GetCurrentBookContent());
            Assert.AreEqual(5, presentationModel.GetRestBookCount());
        }

        //Test
        [TestMethod()]
        public void AddCurrentBookToBorrowListTest()
        {
            presentationModel.SetCurrentBookAndItem(model.GetBookByName(book2Name));
            presentationModel.AddCurrentBookToBorrowList();
            Assert.AreEqual(book2Name, model.GetBorrowList().First().GetName());
        }

        //Test
        [TestMethod()]
        public void SetAddCurrentPageTest()
        {
            presentationModel.SetAddCurrentPage("6月暢銷書");
            Assert.AreEqual("Page：2/2", presentationModel.GetPageText());
        }

        //Test
        [TestMethod()]
        public void SetMinusCurrentPageTest()
        {
            presentationModel.SetAddCurrentPage("6月暢銷書");
            presentationModel.SetMinusCurrentPage("6月暢銷書");
            Assert.AreEqual("Page：1/2", presentationModel.GetPageText());
        }

        //Test
        [TestMethod()]
        public void ResetCurrentPageTest()
        {
            presentationModel.ResetCurrentPage("6月暢銷書");
            Assert.AreEqual("Page：1/2", presentationModel.GetPageText());
        }

        //Test
        [TestMethod()]
        public void SetNextEnableTest()
        {
            presentationModel.ResetCurrentPage("6月暢銷書");
            presentationModel.SetAddCurrentPage("6月暢銷書");
            presentationModel.SetNextEnable("6月暢銷書");
            Assert.AreEqual(false, presentationModel.IsNextEnable());
            presentationModel.SetMinusCurrentPage("6月暢銷書");
            presentationModel.SetNextEnable("6月暢銷書");
            Assert.AreEqual(true, presentationModel.IsNextEnable());
            presentationModel.SetNextEnable("職場必讀");
            Assert.AreEqual(false, presentationModel.IsNextEnable());
        }

        //Test
        [TestMethod()]
        public void SetPreviousEnableTest()
        {
            presentationModel.ResetCurrentPage("6月暢銷書");
            presentationModel.SetAddCurrentPage("6月暢銷書");
            presentationModel.SetPreviousEnable();
            Assert.AreEqual(true, presentationModel.IsPreviousEnable());
            presentationModel.SetMinusCurrentPage("6月暢銷書");
            presentationModel.SetPreviousEnable();
            Assert.AreEqual(false, presentationModel.IsPreviousEnable());
        }

        //Test
        [TestMethod()]
        public void IsAddBookEnableTest()
        {
            presentationModel.SetCurrentBookAndItem(model.GetBookByName(book1Name));
            Assert.AreEqual(true, presentationModel.IsAddBookEnable());
            presentationModel.AddCurrentBookToBorrowList();
            Assert.AreEqual(false, presentationModel.IsAddBookEnable());
        }

        //Test
        [TestMethod()]
        public void IsConfirmEnableTest()
        {
            presentationModel.SetCurrentBookAndItem(model.GetBookByName(book1Name));
            presentationModel.AddCurrentBookToBorrowList();
            Assert.AreEqual(true, presentationModel.IsConfirmEnable());
        }

        //Test
        [TestMethod()]
        public void IsOverLimitTest()
        {
            presentationModel.SetCurrentBookAndItem(model.GetBookByName(book1Name));
            presentationModel.AddCurrentBookToBorrowList();
            presentationModel.AddCurrentBookToBorrowList();
            presentationModel.AddCurrentBookToBorrowList();
            presentationModel.AddCurrentBookToBorrowList();
            Assert.AreEqual(false, presentationModel.IsOverLimit());
            presentationModel.AddCurrentBookToBorrowList();
            presentationModel.AddCurrentBookToBorrowList();
            Assert.AreEqual(true, presentationModel.IsOverLimit());
        }

        //Test
        [TestMethod()]
        public void GetMessageTest()
        {
            List<string> names = new List<string>();
            List<string> counts = new List<string>();
            names.Add("1");
            names.Add("2");
            counts.Add("1");
            counts.Add("2");
            Assert.AreEqual("【1】1本丶【2】2本\n\n已成功借出!", presentationModel.GetMessage(names, counts));
        }

        //Test
        [TestMethod()]
        public void SetVisibleListTest()
        {
            presentationModel.SetVisibleList("6月暢銷書");
            List<bool> boolList = new List<bool>();
            boolList.Add(true);
            boolList.Add(true);
            boolList.Add(true);
            boolList.Add(false);
            Assert.AreEqual(true, Enumerable.SequenceEqual(boolList.ToArray(), presentationModel.GetVisibleList("6月暢銷書")));
            presentationModel.ResetCurrentPage("英文學習");
            presentationModel.SetAddCurrentPage("英文學習");
            presentationModel.SetVisibleList("英文學習");
            boolList.Clear();
            boolList.Add(false);
            boolList.Add(false);
            boolList.Add(false);
            boolList.Add(true);
            boolList.Add(true);
            boolList.Add(true);
            boolList.Add(false);
            boolList.Add(false);
            Assert.AreEqual(true, Enumerable.SequenceEqual(boolList.ToArray(), presentationModel.GetVisibleList("英文學習")));
        }

        //Test
        [TestMethod()]
        public void ReturnListTest()
        {
            presentationModel.SetCurrentBookAndItem(model.GetBookByName(book1Name));
            presentationModel.AddCurrentBookToBorrowList();
            presentationModel.AddCurrentBookToBorrowList();
            presentationModel.SetCurrentBookAndItem(model.GetBookByName(book2Name));
            presentationModel.AddCurrentBookToBorrowList();
            List<string[]> temp = new List<string[]>();
            temp.Add(array1);
            temp.Add(array);
            Assert.AreEqual(true, Enumerable.SequenceEqual(temp.First(), presentationModel.ReturnList().First()));
        }
    }
}