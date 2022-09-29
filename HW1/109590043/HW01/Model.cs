using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Homework01
{
    public class Model
    {
        private int _borrowedBookCount = 0;
        private const int DIVIDE = 7;
        private string[,] _data;
        private List<string> _resultList = new List<string>();
        private List<string> _dataList = new List<string>();
        private List<BookCategory> _bookCategories = new List<BookCategory>();
        private List<BookItem> _bookItems = new List<BookItem>();
        private List<Book> _books = new List<Book>();
        private Book _book;
        private BookItem _bookItem;

        public Model()
        {

        }

        //ReadFile
        public void ReadFile()
        {
            const string FILE_NAME = "../../../hw1_books_source.txt";
            StreamReader file = new StreamReader(@FILE_NAME);
            int books = 0;
            while (!file.EndOfStream)
            {
                string line = file.ReadLine();
                if (line == "")
                    continue;
                _dataList.Add(line);
            }

            this._data = new string[_dataList.Count() / DIVIDE, DIVIDE];
            foreach (string temp in _dataList)
            {
                _data[books / DIVIDE, books++ % DIVIDE] = temp;
            }
        }

        //CreateBook
        public void CreateBook()
        {
            for (int x = 1; x < _dataList.Count() / DIVIDE; x++)
            {
                const int CATEGORY = 2;
                const int NAME = 3;
                const int ID = 4;
                const int CONTENT = 5;
                const int ADDRESS = 6;
                Book book = new Book(_data[x, NAME], _data[x, ID], _data[x, CONTENT], _data[x, ADDRESS]);
                this._books.Add(book);
                if (!_resultList.Contains(_data[x, CATEGORY]))
                {
                    _resultList.Add(_data[x, CATEGORY]);
                    this._bookCategories.Add(new BookCategory(_data[x, CATEGORY]));
                }
                this._bookCategories[_resultList.IndexOf(_data[x, CATEGORY])].AddBook(book);
            }
        }

        //CreateBookItem
        public void CreateBookItem()
        {
            for (int x = 1; x < _dataList.Count() / DIVIDE; x++)
            {
                const int BOOKCOUNT = 1;
                int temp = int.Parse(_data[x, BOOKCOUNT]);
                BookItem bookItem = new BookItem(int.Parse(_data[x, BOOKCOUNT]), _books[x - 1]);
                this._bookItems.Add(bookItem);
            }
        }

        //GetBookCategories
        public List<BookCategory> GetBookCategories()
        {
            return this._bookCategories;
        }

        //GetContent
        public string GetContent(string categoryName, int id)
        {
            this._book = _bookCategories[_resultList.IndexOf(categoryName)].GetBooks()[id];
            this._bookItem = this._bookItems.Find(x => x.GetBook() == _book);
            return _book.GetAllContent();
        }

        //GetBorrowBook
        public string[] GetBorrowBook()
        {
            _borrowedBookCount += 1;
            _bookItems.Find(x => x.GetBook() == _book).SetMinusBookCount(1);
            return _book.GetArray();
        }

        //GetTotalItemCount
        public int GetTotalBookCount()
        {
            return this._books.Count;
        }

        //GetBorrowedBookCount
        public int GetBorrowedBookCount()
        {
            return _borrowedBookCount;
        }

        //GetRestBookCount
        public int GetRestBookCount()
        {
            return _bookItem.GetBookCount();
        }
    }
}
