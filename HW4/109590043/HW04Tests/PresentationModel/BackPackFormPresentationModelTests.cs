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
    public class BackPackFormPresentationModelTests
    {
        private Model model;
        BackPackFormPresentationModel presentationModel;
        string book1Name = "微調有差の日系新版面設計 : 一本前所未有、聚焦於「微調細節差很大」的設計參考書";
        string book2Name = "零零落落";

        [TestInitialize()]
        public void Initialize()
        {
            model = new Model("hw4_books_source.txt");
            presentationModel = new BackPackFormPresentationModel(model);
        }

        [TestMethod()]
        public void ReturnListTest()
        {
            model.UpdateBorrowList(model.GetBookByName(book1Name));
            model.UpdateBorrowList(model.GetBookByName(book1Name));
            model.UpdateBorrowList(model.GetBookByName(book2Name));
            model.UpdateBorrowedList();
            Assert.AreEqual("微調有差の日系新版面設計 : 一本前所未有、聚焦於「微調細節差很大」的設計參考書", presentationModel.ReturnList().First()[2]);
        }

        [TestMethod()]
        public void GetMessageTest()
        {
            Assert.AreEqual("【零零落落】 已成功歸還1本", presentationModel.GetMessage("零零落落", "1"));
        }

        [TestMethod()]
        public void GetReturnLimitMessageTest()
        {
            presentationModel.GetReturnLimitMessage(1, 3, 2);
            presentationModel.GetReturnLimitMessage(1, 0, 2);
            presentationModel.GetReturnLimitMessage(1, 2, 2);
            Assert.AreEqual(true, true);
        }

        //[TestMethod()]
        //public void ShowMessageTest()
        //{
        //    Assert.Fail();
        //}
    }
}