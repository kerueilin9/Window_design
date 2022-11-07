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
    public class BookManagementFormPresentationModelTests
    {
        private Model model;
        BookManagementFormPresentationModel presentationModel;
        string book1Name = "微調有差の日系新版面設計 : 一本前所未有、聚焦於「微調細節差很大」的設計參考書";
        private string name = "name";
        Book book;

        [TestInitialize()]
        public void Initialize()
        {
            model = new Model("hw4_books_source.txt");
            presentationModel = new BookManagementFormPresentationModel(model);
            book = model.GetBookByName(book1Name);
        }

        [TestMethod()]
        public void JudgeIsSaveTest()
        {
            presentationModel.ChangeContent(book1Name);
            presentationModel.JudgeIsSave();
            Assert.AreEqual(false, presentationModel.IsSave);
            presentationModel.NameTextBox = name;
            presentationModel.JudgeIsSave();
            Assert.AreEqual(true, presentationModel.IsSave);
            presentationModel.NameTextBox = "";
            presentationModel.JudgeIsSave();
            Assert.AreEqual(false, presentationModel.IsSave);
        }

        [TestMethod()]
        public void GetListBoxListTest()
        {
            List<string> bookNames = new List<string>();
            foreach (BookCategory bookCategory in model.GetBookCategories())
                foreach (Book book in bookCategory.GetBooks())
                    bookNames.Add(book.GetName());
            Assert.AreEqual(true, Enumerable.SequenceEqual(bookNames.ToArray(), presentationModel.GetListBoxList().ToArray()));
        }

        [TestMethod()]
        public void GetFilePathTest()
        {
            Assert.AreEqual("../../../image/123", presentationModel.GetFilePath("123"));
        }

        [TestMethod()]
        public void GetCategoryNamesTest()
        {
            List<string> categoryNames = new List<string>();
            categoryNames.Add("6月暢銷書");
            categoryNames.Add("4月暢銷書");
            categoryNames.Add("英文學習");
            categoryNames.Add("職場必讀");
            Assert.AreEqual(true, Enumerable.SequenceEqual(categoryNames.ToArray(), presentationModel.GetCategoryNames().ToArray()));
        }

        [TestMethod()]
        public void ClickSaveTest()
        {
            presentationModel.ChangeContent(book1Name);
            presentationModel.NameTextBox = name;
            presentationModel.ClickSave();
            Assert.AreEqual(book.GetName(), name);
            presentationModel.CategoryComboBox = "6月暢銷書";
            presentationModel.CategoryComboBox = "英文學習";
            presentationModel.ClickSave();
            Assert.AreEqual(model.GetCategoryByBook(book).GetCategoryName(), "英文學習");
        }

        [TestMethod()]
        public void GetSetTest()
        {
            presentationModel.ChangeContent(book1Name);
            presentationModel.AuthorTextBox = "";
            presentationModel.FileTextBox = "";
            presentationModel.IdTextBox = "";
            presentationModel.NameTextBox = "";
            presentationModel.PublisherTextBox = "";
            presentationModel.CategoryComboBox = "";
            presentationModel.IsAddBookButton = false;
            presentationModel.IsBrowse = false;
            presentationModel.IsSave = false;
            Assert.AreEqual("", presentationModel.AuthorTextBox);
            Assert.AreEqual("", presentationModel.FileTextBox);
            Assert.AreEqual("", presentationModel.NameTextBox);
            Assert.AreEqual("", presentationModel.IdTextBox);
            Assert.AreEqual("", presentationModel.PublisherTextBox);
            Assert.AreEqual("", presentationModel.CategoryComboBox);
            Assert.AreEqual(false, presentationModel.IsAddBookButton);
            Assert.AreEqual(false, presentationModel.IsBrowse);
            Assert.AreEqual(false, presentationModel.IsSave);

        }
    }
}