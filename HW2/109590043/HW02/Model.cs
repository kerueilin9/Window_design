using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Homework02
{
    public class Model
    {
        private int _borrowedBookCount = 0;
        private const int DIVIDE = 7;
        private string[,] _data;
        private List<string> _dataList = new List<string>();
        private List<BookCategory> _bookCategories = new List<BookCategory>();
        private List<BookItem> _bookItems = new List<BookItem>();
        private List<Book> _books = new List<Book>();
        private BorrowedList _borrowedList = new BorrowedList();
        private Book _book;
        private BookItem _bookItem;

        public Model()
        {

        }

        //ReadFile
        public void ReadFile()
        {
            const string FILE_NAME = "../../../hw2_books_source.txt";
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
                const int BOOKCOUNT = 1;
                const int CATEGORY = 2;
                const int NAME = 3;
                const int ID = 4;
                const int CONTENT = 5;
                const int ADDRESS = 6;
                Book book = new Book(_data[x, NAME], _data[x, ID], _data[x, CONTENT], _data[x, ADDRESS]);
                BookItem bookItem = new BookItem(int.Parse(_data[x, BOOKCOUNT]), book);
                this._bookItems.Add(bookItem);
                if (this._bookCategories.Find(i => i.GetCategoryName() == _data[x, CATEGORY]) == null) 
                {
                    this._bookCategories.Add(new BookCategory(_data[x, CATEGORY]));
                }
                this._bookCategories.Find(i => i.GetCategoryName() == _data[x, CATEGORY]).AddBook(book);
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
            BookCategory category = _bookCategories.Find(x =>
            {
                return x.GetCategoryName() == categoryName;
            });
            this._book = category.GetBooks()[id];
            this._bookItem = this._bookItems.Find(x => x.GetBook() == _book);
            return this._book.GetAllContent();
        }

        //GetBorrowBook
        public string[] GetBorrowBook()
        {
            _borrowedBookCount += 1;
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
