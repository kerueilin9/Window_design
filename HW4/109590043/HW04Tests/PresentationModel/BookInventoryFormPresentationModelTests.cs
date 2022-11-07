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
    public class BookInventoryFormPresentationModelTests
    {
        private Model model;
        BookInventoryFormPresentationModel presentationModel;
        string book1Name = "微調有差の日系新版面設計 : 一本前所未有、聚焦於「微調細節差很大」的設計參考書";
        const string _content = "微調有差の日系新版面設計 : 一本前所未有、聚焦於「微調細節差很大」的設計參考書\n編號：964 8394:2-5 2021\n作者：ingectar-e\n原點出版 : 大雁發行, 2021[民110]";
        string book2Name = "零零落落";

        [TestInitialize()]
        public void Initialize()
        {
            model = new Model("hw4_books_source.txt");
            presentationModel = new BookInventoryFormPresentationModel(model);
        }

        [TestMethod()]
        public void GetContentTest()
        {
            string content = "書籍名稱：\n\n書籍類別：\n庫存數量：";
            Assert.AreEqual(content, presentationModel.GetContent("", "", ""));
        }

        [TestMethod()]
        public void GetImageTest()
        {
            presentationModel.CurrentBook = model.GetBookByName(book2Name);
            Assert.AreEqual("../../../image/4.jpg", presentationModel.GetImage());
            Assert.AreEqual("../../../image/4.jpg", presentationModel.CurrentBook.GetImage());
        }

        [TestMethod()]
        public void GetContentTextTest()
        {
            presentationModel.CurrentBook = model.GetBookByName(book1Name);
            Assert.AreEqual(_content, presentationModel.GetContentText());
        }

        [TestMethod()]
        public void GetNameTest()
        {
            Assert.AreEqual("", presentationModel.GetName());
            presentationModel.CurrentBook = model.GetBookByName(book1Name);
            Assert.AreEqual(book1Name, presentationModel.GetName());
        }

        [TestMethod()]
        public void IsCurrentIndexTest()
        {
            Assert.AreEqual(false, presentationModel.IsCurrentIndex("123"));
            presentationModel.CurrentBook = model.GetBookByName(book1Name);
            Assert.AreEqual(true, presentationModel.IsCurrentIndex(book1Name));
        }
    }
}