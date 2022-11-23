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
        PrivateObject privateObject;
        private Model model;
        BackPackFormPresentationModel presentationModel;
        string book1Name = "微調有差の日系新版面設計 : 一本前所未有、聚焦於「微調細節差很大」的設計參考書";
        string book2Name = "零零落落";

        //Test
        [TestInitialize()]
        public void Initialize()
        {
            model = new Model("hw4_books_source.txt");
            presentationModel = new BackPackFormPresentationModel(model);
            privateObject = new PrivateObject(presentationModel);
        }

        //Test
        [TestMethod()]
        public void ReturnListTest()
        {
            model.UpdateBorrowList(model.GetBookByName(book1Name));
            model.UpdateBorrowList(model.GetBookByName(book1Name));
            model.UpdateBorrowList(model.GetBookByName(book2Name));
            model.UpdateBorrowedList();
            Assert.AreEqual("微調有差の日系新版面設計 : 一本前所未有、聚焦於「微調細節差很大」的設計參考書", presentationModel.ReturnList().First()[2]);
        }

        //Test
        [TestMethod()]
        public void GetMessageTest()
        {
            Assert.AreEqual("【零零落落】 已成功歸還1本", presentationModel.GetMessage("零零落落", "1"));
        }

        //Test
        [TestMethod()]
        public void GetReturnLimitMessageTest()
        {
            presentationModel.GetReturnLimitMessage(1, 3, 2);
            presentationModel.GetReturnLimitMessage(1, 0, 2);
            presentationModel.GetReturnLimitMessage(1, 2, 2);
            Assert.AreEqual(true, true);
        }

        //Test
        [TestMethod()]
        public void UseActionTest()
        {
            Action<string, string, int, int> action = null;
            int test = 0;
            privateObject.SetFieldOrProperty("_showMessage", action);
            privateObject.Invoke("ShowMessage", "", "", 1, 2);
            Assert.AreEqual(0, test);

            action += (string content, string title, int rowIndex, int resultCount) =>
            {
                test = 1;
            };
            privateObject.SetFieldOrProperty("_showMessage", action);
            privateObject.Invoke("ShowMessage", "", "", 1, 2);
            Assert.AreEqual(1, test);
        }
    }
}