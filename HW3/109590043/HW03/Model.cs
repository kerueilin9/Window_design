using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;

namespace Homework
{
    public class Model
    {
        public event Action _updateBookItem;
        public event Action<string, string, int, int> _showMessage;
        private const int DIVIDE = 7;
        private string[,] _data;
        private List<string> _dataList = new List<string>();
        private List<string> _categoriesNames = new List<string>();
        private List<BookCategory> _bookCategories = new List<BookCategory>();
        private List<BookItem> _bookItems = new List<BookItem>();
        private List<Book> _books = new List<Book>();
        private BorrowedList _borrowedList = new BorrowedList();
        private List<Book> _borrowList = new List<Book>();
        private Book _book;
        private BookItem _bookItem;

        public Model()
        {
            ReadFile();
            CreateBook();
        }

        //ReadFile
        public void ReadFile()
        {
            const string FILE_NAME = "../../../hw3_books_source.txt";
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
                this._books.Add(book);
                BookItem bookItem = new BookItem(int.Parse(_data[x, BOOKCOUNT]), book);
                this._bookItems.Add(bookItem);
                if (this._bookCategories.Find(i => i.GetCategoryName() == _data[x, CATEGORY]) == null) 
                    this._bookCategories.Add(new BookCategory(_data[x, CATEGORY]));
                this._bookCategories.Find(i => i.GetCategoryName() == _data[x, CATEGORY]).AddBook(book);
            }
        }

        //GetBookCategories
        public List<BookCategory> GetBookCategories()
        {
            return this._bookCategories;
        }

        //GetBookCategoriesBooks
        public List<Book> GetBookCategoriesBooks(string categoryName)
        {
            BookCategory category = _bookCategories.Find(x =>
            {
                return x.GetCategoryName() == categoryName;
            });
            return category.GetBooks();
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

        //GetContentByName
        public string GetContentByName(string name)
        {
            Book book = this._books.Find(x => x.GetName() == name);
            return book.GetAllContent();
        }

        //GetCurrentBook
        public Book GetCurrentBook()
        {
            return this._book;
        }

        //GetBorrowBook
        public string[] GetBorrowBookArray()
        {
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
            return this._borrowList.Count;
        }

        //GetRestBookCount
        public int GetRestBookCount()
        {
            return _bookItem.GetBookCount();
        }

        //GetBorrowList
        public List<Book> GetBorrowList()
        {
            return this._borrowList;
        }

        //SetBorrowList
        public void SetBorrowList(List<Book> books)
        {
            this._borrowList = books;
        }

        //UpdateBorrowList
        public void UpdateBorrowList()
        {
            this._borrowList.Add(this._book);
        }

        //UpdateBorrowListByData
        public void UpdateBorrowListByData(int count, string name)
        {
            List<Book> temp = _borrowList.FindAll(x => x.GetName() == name);
            int countOld = temp.Count;
            if (count > countOld)
                for (int i = 0; i < count - countOld; i++)
                    this._borrowList.Add(temp.First());
            else if (countOld > count)
                for (int i = 0; i < countOld - count; i++)
                    this._borrowList.Remove(temp.First());
            countOld = 0;
        }

        //DeleteBorrowListUseName
        public void DeleteBorrowListUseName(string name, int count)
        {
            Book book = this._books.Find(x => x.GetName() == name);
            for (int i = 0; i < count; i++)
                this._borrowList.Remove(book);
        }

        //GetCategoryIndex
        public int GetCategoryIndex(string tabName)
        {
            foreach (BookCategory bookCategory in _bookCategories)
                this._categoriesNames.Add(bookCategory.GetCategoryName());
            return this._categoriesNames.IndexOf(tabName);
        }

        //ClearBorrowList
        public void ClearBorrowList()
        {
            this._borrowList.Clear();
        }

        //IsAddButtonEnable
        public bool IsAddButtonEnable()
        {
            return !_borrowList.Contains(_book) && _bookItem.GetBookCount() != 0;
        }

        //UpdateBorrowedList
        public void UpdateBorrowedList()
        {
            foreach (Book book in this._borrowList)
            {
                BorrowedItem borrowedItem = new BorrowedItem(System.DateTime.Now, book);
                this._borrowedList.AddBorrowedList(borrowedItem);
                BookItem bookItem = this._bookItems.Find(x => x.GetBook() == book);
                bookItem.SetMinusBookCount(1);
            }
        }

        //GetBookItemByName
        public BookItem GetBookItemByName(string name)
        {
            Book book = this._books.Find(x => x.GetName() == name);
            BookItem bookItem = this._bookItems.Find(x => x.GetBook() == book);
            return bookItem;
        }

        //GetBookCountByBook
        public int GetBookCountByBook(Book book)
        {
            BookItem bookItem = this._bookItems.Find(x => x.GetBook() == book);
            return bookItem.GetBookCount();
        }

        //DeleteBorrowedList
        public void DeleteBorrowedList(string name, int returnCount)
        {
            for (int i = 0; i < returnCount; i++)
                this._borrowedList.DeleteBorrowedItemUseName(name);
            BookItem bookItem = this._bookItems.Find(x => x.GetBook().GetName() == name);
            bookItem.SetPlusBookCount(returnCount);
        }

        //GetBorrowedList
        public List<BorrowedItem> GetBorrowedList()
        {
            return this._borrowedList.BorrowedItems;
        }

        //JudgeMessageLimit
        public int JudgeMessageLimit(int count, string name, int rowIndex)
        {
            bool show = false;
            int resultCount = count;
            const int LIMIT_COUNT = 2;
            if (count > GetBookItemByName(name).GetBookCount() && GetBookItemByName(name).GetBookCount() <= LIMIT_COUNT)
            {
                resultCount = GetBookItemByName(name).GetBookCount();
                show = true;
            }
            if (count > LIMIT_COUNT && GetBookItemByName(name).GetBookCount() > LIMIT_COUNT)
            {
                resultCount = LIMIT_COUNT;
                show = true;
            }
            resultCount = JudgeMessageOverFive(name, rowIndex, resultCount, show);
            return resultCount;
        }

        //JudgeMessageOverFive
        public int JudgeMessageOverFive(string name, int rowIndex, int resultCount, bool show)
        {
            const int LIMIT_COUNT = 5;
            UpdateBorrowListByData(resultCount, name);
            if (_borrowList.Count > LIMIT_COUNT)
            {
                resultCount = 1;
                UpdateBorrowListByData(resultCount, name);
                ShowMessageOverFive(rowIndex, resultCount);
                return resultCount;
            }
            else if (show)
            {
                ShowMessageLimit(rowIndex, resultCount);
                return resultCount;
            }
            else
                return resultCount;
        }

        //ShowMessageLimit
        public void ShowMessageLimit(int rowIndex, int resultCount)
        {
            const string LIMIT_TITLE = "借書違規";
            const string OVER_TITLE = "庫存狀態";
            const string LIMIT_CONTENT = "同一本書限借兩次";
            const string OVER_CONTENT = "該書本剩餘數量不足";
            if (resultCount == 1)
                ShowMessage(OVER_CONTENT, OVER_TITLE, rowIndex, resultCount);
            else
                ShowMessage(LIMIT_CONTENT, LIMIT_TITLE, rowIndex, resultCount);
        }

        //ShowMessageOverFive
        public void ShowMessageOverFive(int rowIndex, int resultCount)
        {
            const string LIMIT_CONTENT = "每次借書限界五本，你的借書單已滿。";
            ShowMessage(LIMIT_CONTENT, "", rowIndex, resultCount);
        }

        //ShowMessage
        public void ShowMessage(string content, string title, int rowIndex, int resultCount)
        {
            if (this._showMessage != null)
                this._showMessage(content, title, rowIndex, resultCount);
        }

        //UpdateBookItem
        public void UpdateBookItem()
        {
            if (this._updateBookItem != null)
                this._updateBookItem();
        }
    }
}
