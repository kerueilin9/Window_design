using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Homework.Tests
{
    [TestClass()]
    public class BookTests
    {

        Book _book;
        PrivateObject _bookPrivate;
        readonly string[] _bookList = {
            "微調有差の日系新版面設計: 一本前所未有、聚焦於「微調細節差很大」的設計參考書",
            "964 8394:2 - 5 2021",
            "ingectar - e",
            "原點出版: 大雁發行, 2021[民110]",
            "../../../image/1.jpg" };
        readonly string[] _bookDataGridViewArray = {
            "",
            "微調有差の日系新版面設計: 一本前所未有、聚焦於「微調細節差很大」的設計參考書",
            "1",
            "964 8394:2 - 5 2021",
            "ingectar - e",
            "原點出版: 大雁發行, 2021[民110]" };
        const string _content = "微調有差の日系新版面設計: 一本前所未有、聚焦於「微調細節差很大」的設計參考書\n編號：964 8394:2 - 5 2021\n作者：ingectar - e\n原點出版: 大雁發行, 2021[民110]";

        [TestInitialize()]
        public void Initialize()
        {
            _book = new Book(_bookList[0], _bookList[1], _bookList[2], _bookList[3], _bookList[4]);
            _bookPrivate = new PrivateObject(_book);
        }

        [TestMethod()]
        public void BookTest()
        {
            Assert.AreEqual(_bookList[0], _book.GetName());
            Assert.AreEqual(_bookList[1], _book.GetId());
            Assert.AreEqual(_bookList[2], _book.GetAuthor());
            Assert.AreEqual(_bookList[3], _book.GetPublisher());
            Assert.AreEqual(_bookList[4], _book.GetImage());
        }

        [TestMethod()]
        public void SetTest()
        {
            _book.SetName("1");
            _book.SetId("1");
            _book.SetAuthor("1");
            _book.SetPublisher("1");
            _book.SetImage("1");
            Assert.AreEqual("1", _book.GetName());
            Assert.AreEqual("1", _book.GetId());
            Assert.AreEqual("1", _book.GetAuthor());
            Assert.AreEqual("1", _book.GetPublisher());
            Assert.AreEqual("1", _book.GetImage());
        }

        [TestMethod()]
        public void GetAllContentTest()
        {
            Assert.AreEqual(_content, _book.GetAllContent());
        }

        [TestMethod()]
        public void GetDataGridViewArrayTest()
        {
            Assert.AreEqual(true, Enumerable.SequenceEqual(_bookDataGridViewArray, _book.GetDataGridViewArray()));
        }

        [TestMethod()]
        public void GetArrayTest()
        {
            Assert.AreEqual(true, Enumerable.SequenceEqual(_bookList, _book.GetArray()));
        }
    }
}