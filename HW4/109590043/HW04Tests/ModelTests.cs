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
    public class ModelTests
    {
        PrivateObject privateObject;
        Model model;
        const string _content = "微調有差の日系新版面設計 : 一本前所未有、聚焦於「微調細節差很大」的設計參考書\n編號：964 8394:2-5 2021\n作者：ingectar-e\n原點出版 : 大雁發行, 2021[民110]";
        const string book1Name = "微調有差の日系新版面設計 : 一本前所未有、聚焦於「微調細節差很大」的設計參考書";
        private List<string> _categoriesNames = new List<string>();
        private BookCategory bookCategory;
        private Book book1;
        private Book book2;
        private Book book3; 
        private Book book4;

        //Test
        [TestInitialize()]
        public void Initialize()
        {
            model = new Model("hw4_books_source.txt");
            privateObject = new PrivateObject(model);
            _categoriesNames.Add("6月暢銷書");
            _categoriesNames.Add("4月暢銷書");
            _categoriesNames.Add("英文學習");
            _categoriesNames.Add("職場必讀");
            bookCategory = new BookCategory("6月暢銷書");
            book1 = new Book("微調有差の日系新版面設計 : 一本前所未有、聚焦於「微調細節差很大」的設計參考書", "964 8394:2-5 2021", "ingectar-e", "原點出版 : 大雁發行, 2021[民110]", "../../../image/1.jpg");
            book2 = new Book("創造快樂大腦 : 重塑大腦快樂習慣-提升血清素, 多巴胺, 催產素, 腦內啡", "176.51 8564 2022", "羅瑞塔.葛蕾吉亞諾.布魯", "閱樂國際文化出版", "../../../image/2.jpg");
            book3 = new Book("暴力犯罪的大腦檔案 : 從神經犯罪學探究惡行的生物根源, 慎思以治療取代懲罰的未來防治計畫", "415.92 844 2021", "艾德里安.雷恩", "遠流, 2021[民110]", "../../../image/3.jpg");
            book4 = new Book("零零落落", "851.486 8345:2 2022", "黃春明", "聯合文學, 2022[民111]", "../../../image/4.jpg");
            bookCategory.AddBook(book1);
            bookCategory.AddBook(book2);
            bookCategory.AddBook(book3);
            bookCategory.AddBook(book4);
        }

        //Test
        [TestMethod()]
        public void CreateBookTest()
        {
            model.CreateBook();
            Assert.AreEqual(bookCategory.GetBooks().First().GetAllContent(), model.GetCategoryByName("零零落落").GetBooks().First().GetAllContent());
            Assert.AreEqual("6月暢銷書", model.GetCategoryByName("微調有差の日系新版面設計 : 一本前所未有、聚焦於「微調細節差很大」的設計參考書").GetCategoryName());
        }

        //Test
        [TestMethod()]
        public void GetCategoryByNameTest()
        {
            Assert.AreEqual(bookCategory.GetBooks().First().GetAllContent(), model.GetCategoryByName("零零落落").GetBooks().First().GetAllContent());
            Assert.AreEqual("6月暢銷書", model.GetCategoryByName("微調有差の日系新版面設計 : 一本前所未有、聚焦於「微調細節差很大」的設計參考書").GetCategoryName());
        }

        //Test
        [TestMethod()]
        public void GetCategoryByBookTest()
        {
            Book book = model.GetBookByName("零零落落");
            Assert.AreEqual("6月暢銷書", model.GetCategoryByBook(book).GetCategoryName());
        }

        //Test
        [TestMethod()]
        public void GetCategoryByTagNameTest()
        {
            Assert.AreEqual("6月暢銷書", model.GetCategoryByTagName("6月暢銷書").GetCategoryName());
        }

        //Test
        [TestMethod()]
        public void GetCategoryIndexTest()
        {
            Assert.AreEqual(0, model.GetCategoryIndex("6月暢銷書"));
        }

        //Test
        [TestMethod()]
        public void GetBookCategoriesTest()
        {
            Assert.AreEqual("6月暢銷書", model.GetBookCategories().First().GetCategoryName());
        }

        //Test
        [TestMethod()]
        public void GetBookCategoriesBooksTest()
        {
            Assert.AreEqual(model.GetBookByName("微調有差の日系新版面設計 : 一本前所未有、聚焦於「微調細節差很大」的設計參考書"), model.GetBookCategoriesBooks("6月暢銷書").First());
        }
        
        //Test
        [TestMethod()]
        public void GetBookByTagTest()
        {
            Assert.AreEqual(model.GetBookByName("零零落落"), model.GetBookByTag("6月暢銷書", 3)); ;
        }

        //Test
        [TestMethod()]
        public void GetImageByTagTest()
        {
            Assert.AreEqual(model.GetBookByName("零零落落").GetImage(), model.GetImageByTag("6月暢銷書", 3)); ;
        }

        //Test
        [TestMethod()]
        public void GetBookByNameTest()
        {
            Assert.AreEqual("零零落落", model.GetBookByName("零零落落").GetName());
        }

        //Test
        [TestMethod()]
        public void GetContentByNameTest()
        {
            Assert.AreEqual(_content, model.GetContentByName("微調有差の日系新版面設計 : 一本前所未有、聚焦於「微調細節差很大」的設計參考書"));
        }

        //Test
        [TestMethod()]
        public void GetBorrowedBookCountTest()
        {
            Assert.AreEqual(0, model.GetBorrowedBookCount());
        }

        //Test
        [TestMethod()]
        public void GetBorrowListTest()
        {
            model.UpdateBorrowList(book1);
            List<Book> books = new List<Book>();
            books.Add(book1);
            Assert.AreEqual(true, Enumerable.SequenceEqual(books.ToArray(), model.GetBorrowList().ToArray()));
        }

        //Test
        [TestMethod()]
        public void UpdateBorrowListTest()
        {
            model.UpdateBorrowList(book1);
            List<Book> books = new List<Book>();
            books.Add(book1);
            Assert.AreEqual(true, Enumerable.SequenceEqual(books.ToArray(), model.GetBorrowList().ToArray()));
        }

        //Test
        [TestMethod()]
        public void UpdateBorrowListByCountTest()
        {
            model.UpdateBorrowList(book1);
            List<Book> books = new List<Book>();
            books.Add(book1);
            books.Add(book1);
            model.UpdateBorrowListByCount(2, book1Name);
            Assert.AreEqual(true, Enumerable.SequenceEqual(books.ToArray(), model.GetBorrowList().ToArray()));
        }

        //Test
        [TestMethod()]
        public void ClearBorrowListTest()
        {
            model.UpdateBorrowList(book1);
            model.ClearBorrowList();
            model.UpdateBorrowList(book1);
            List<Book> books = new List<Book>();
            books.Add(book1);
            Assert.AreEqual(true, Enumerable.SequenceEqual(books.ToArray(), model.GetBorrowList().ToArray()));
        }

        //Test
        [TestMethod()]
        public void UpdateBorrowedListTest()
        {
            model.UpdateBorrowList(model.GetBookByName(book1Name));
            model.UpdateBorrowList(model.GetBookByName(book1Name));
            BorrowedItem borrowedItem = new BorrowedItem(System.DateTime.Now, model.GetBookByName(book1Name));
            model.UpdateBorrowedList();
            List<BorrowedItem> borrowedItems = new List<BorrowedItem>();
            borrowedItems.Add(borrowedItem);
            borrowedItems.Add(borrowedItem);
            Assert.AreEqual(false, Enumerable.SequenceEqual(borrowedItems.ToArray(), model.GetBorrowedList().ToArray()));
        }

        //Test
        [TestMethod()]
        public void GetBookItemByNameTest()
        {
            Assert.AreEqual(5, model.GetBookItemByName(book1Name).GetBookCount());
        }

        //Test
        [TestMethod()]
        public void GetBookItemByBookTest()
        {
            Assert.AreEqual(5, model.GetBookItemByBook(model.GetBookByName(book1Name)).GetBookCount());
        }

        //Test
        [TestMethod()]
        public void GetBookCountByBookTest()
        {
            Assert.AreEqual(5, model.GetBookCountByBook(model.GetBookByName(book1Name)));
        }

        //Test
        [TestMethod()]
        public void DeleteBorrowedListTest()
        {
            model.DeleteBorrowedList(book1Name, 1);
            Assert.AreEqual(6, model.GetBookCountByBook(model.GetBookByName(book1Name)));
        }

        //Test
        [TestMethod()]
        public void GetBorrowedListTest()
        {
            model.UpdateBorrowList(model.GetBookByName(book1Name));
            model.UpdateBorrowedList();
            Assert.AreEqual(model.GetBookByName(book1Name), model.GetBorrowedList().First().Book);
        }

        //Test
        [TestMethod()]
        public void JudgeMessageLimitTest()
        {
            model.UpdateBorrowList(model.GetBookByName("草莓與灰燼"));
            Assert.AreEqual(1, model.JudgeMessageLimit(1, "草莓與灰燼", 1));
            model.UpdateBorrowList(model.GetBookByName("創造快樂大腦 : 重塑大腦快樂習慣-提升血清素, 多巴胺, 催產素, 腦內啡"));
            model.UpdateBorrowList(model.GetBookByName("創造快樂大腦 : 重塑大腦快樂習慣-提升血清素, 多巴胺, 催產素, 腦內啡"));
            Assert.AreEqual(1, model.JudgeMessageLimit(2, "創造快樂大腦 : 重塑大腦快樂習慣-提升血清素, 多巴胺, 催產素, 腦內啡", 4));
            model.UpdateBorrowList(model.GetBookByName(book1Name));
            model.UpdateBorrowList(model.GetBookByName(book1Name));
            model.UpdateBorrowList(model.GetBookByName(book1Name));
            Assert.AreEqual(2, model.JudgeMessageLimit(3, book1Name, 2));
            model.UpdateBorrowList(model.GetBookByName("零零落落"));
            model.UpdateBorrowList(model.GetBookByName("零零落落"));
            model.UpdateBorrowList(model.GetBookByName("零零落落"));
            model.UpdateBorrowList(model.GetBookByName("零零落落"));
            Assert.AreEqual(1, model.JudgeMessageLimit(4, "零零落落", 3));
        }

        [TestMethod()]
        public void TestUseAction()
        {
            Action<string, string, int, int> action = null;
            int test = 0;
            privateObject.SetFieldOrProperty("_showMessage", action);
            privateObject.Invoke("ShowMessage", "", "", 1, 2);
            Assert.AreEqual(0, test);

            action += (string content, string title, int rowIndex, int resultCount) => {
                test = 1;
            };
            privateObject.SetFieldOrProperty("_showMessage", action);
            privateObject.Invoke("ShowMessage", "", "", 1, 2);
            Assert.AreEqual(1, test);

            Action action1 = null;
            privateObject.SetFieldOrProperty("_updateBookItem", action1);
            model.UpdateBookItem();
            Assert.AreEqual(1, test);
            action1 += () => {
                test = 2;
            };
            privateObject.SetFieldOrProperty("_updateBookItem", action1);
            model.UpdateBookItem();
            Assert.AreEqual(2, test);

            action1 = null;
            privateObject.SetFieldOrProperty("_updateEditedBook", action1);
            model.UpdateEditedBook();
            Assert.AreEqual(2, test);
            action1 += () => {
                test = 3;
            };
            privateObject.SetFieldOrProperty("_updateEditedBook", action1);
            model.UpdateEditedBook();
            Assert.AreEqual(3, test);

            action1 = null;
            privateObject.SetFieldOrProperty("_updateTabView", action1);
            model.UpdateTabView();
            Assert.AreEqual(3, test);
            action1 += () => {
                test = 4;
            };
            privateObject.SetFieldOrProperty("_updateTabView", action1);
            model.UpdateTabView();
            Assert.AreEqual(4, test);
        }
    }
}