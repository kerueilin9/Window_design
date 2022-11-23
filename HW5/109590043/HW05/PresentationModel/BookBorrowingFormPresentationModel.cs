using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Homework.PresentationModel
{
    public class BookBorrowingFormPresentationModel
    {
        private Model _model;
        private List<List<bool>> _visibleList = new List<List<bool>>();
        private bool _nextEnable;
        private bool _previousEnable;
        private int _currentPage;
        private Book _currentBook = null;
        private BookItem _currentBookItem = new BookItem();
        private string _pageText;

        public BookBorrowingFormPresentationModel(Model model)
        {
            this._model = model;
            Initialize();
            ListInitialize();
        }

        //ListInitialize
        public void ListInitialize()
        {
            _visibleList.Clear();
            int visibleListNumber = 0;
            foreach (BookCategory bookCategory in _model.GetBookCategories())
            {
                List<bool> visibleList = new List<bool>();
                _visibleList.Add(visibleList);
                for (int i = 0; i < bookCategory.GetBookCount(); i++)
                {
                    _visibleList[visibleListNumber].Add(true);
                }
                visibleListNumber++;
            }
            _currentPage = 1;
        }

        //Initialize
        private void Initialize()
        {
            const int BUTTON_COUNT = 3;
            const int FIRST_CATEGORIES = 0;
            int addPage;
            const string PAGE_TEXT = "Page：{0}/{1}";
            List<BookCategory> bookCategories = _model.GetBookCategories();
            if (bookCategories[FIRST_CATEGORIES].GetBooks().Count % BUTTON_COUNT == 0)
                addPage = 0;
            else
                addPage = 1;
            _pageText = String.Format(PAGE_TEXT, 1, bookCategories[FIRST_CATEGORIES].GetBooks().Count / BUTTON_COUNT + addPage);
        }

        //GetPageText
        public string GetPageText()
        {
            return this._pageText;
        }

        //SetPageText
        public void SetPageText(int page, string tabName)
        {
            const int BUTTON_COUNT = 3;
            int addPage = 1;
            const string PAGE_TEXT = "Page：{0}/{1}";
            List<Book> books = _model.GetBookCategoriesBooks(tabName);
            if (books.Count % BUTTON_COUNT == 0)
                addPage = 0;
            this._pageText = String.Format(PAGE_TEXT, _currentPage, books.Count / BUTTON_COUNT + addPage);
        }

        //GetCurrentBookContent
        public string GetCurrentBookContent()
        {
            if (_currentBook != null)
                return _currentBook.GetAllContent();
            else
                return "";
        }

        //SetCurrentBookAndItem
        public void SetCurrentBookAndItem(Book book)
        {
            _currentBook = book;
            this._currentBookItem = this._model.GetBookItemByBook(book);
        }

        //AddCurrentBookToBorrowList
        public void AddCurrentBookToBorrowList()
        {
            _model.UpdateBorrowList(_currentBook);
        }

        //GetRestBookCount
        public int GetRestBookCount()
        {
            return _currentBookItem.GetBookCount();
        }

        //SetAddCurrentPage
        public void SetAddCurrentPage(string tabName)
        {
            this._currentPage++;
            SetPageText(_currentPage, tabName);
        }

        //SetMinusCurrentPage
        public void SetMinusCurrentPage(string tabName)
        {
            this._currentPage--;
            SetPageText(_currentPage, tabName);
        }

        //ResetCurrentPage
        public void ResetCurrentPage(string tabName)
        {
            this._currentPage = 1;
            SetPageText(_currentPage, tabName);
        }

        //IsNextEnable
        public bool IsNextEnable()
        {
            return this._nextEnable;
        }

        //SetNextEnable
        public void SetNextEnable(string tabName)
        {
            const int BUTTON_COUNT = 3;
            int addPage = 1;
            List<Book> books = _model.GetBookCategoriesBooks(tabName);
            if (books.Count % BUTTON_COUNT == 0)
                addPage = 0;
            if (this._currentPage >= books.Count / BUTTON_COUNT + addPage)
                this._nextEnable = false;
            else
                this._nextEnable = true;
        }

        //IsPreviousEnable
        public bool IsPreviousEnable()
        {
            return this._previousEnable;
        }

        //SetPreviousEnable
        public void SetPreviousEnable()
        {
            if (this._currentPage <= 1)
                this._previousEnable = false;
            else
                this._previousEnable = true;
        }

        //IsAddBookEnable
        public bool IsAddBookEnable()
        {
            return !_model.GetBorrowList().Contains(_currentBook) && _currentBookItem.GetBookCount() != 0;
        }

        //IsConfirmEnable
        public bool IsConfirmEnable()
        {
            return _model.GetBorrowList().Count > 0;
        }

        //IsOverLimit
        public bool IsOverLimit()
        {
            const int BORROWING_LIMIT = 5;
            if (_model.GetBorrowList().Count >= BORROWING_LIMIT)
                return true;
            else
            {
                AddCurrentBookToBorrowList();
                return false;
            }
        }

        //GetMessage
        public string GetMessage(List<string> names, List<string> counts)
        {
            const string TEXT = "\n\n已成功借出!";
            const string COUNT_TEXT = "{0}本";
            const string UPPER_BRACKET = "【";
            const string LOWER_BRACKET = "】";
            const string COMMA = "丶";
            string result = "";
            for (int i = 0; i < names.Count; i++)
                result += UPPER_BRACKET + names[i] + LOWER_BRACKET + string.Format(COUNT_TEXT, counts[i]) + COMMA;
            result = result.Remove(result.Length - 1);
            result += TEXT;
            return result;
        }

        //GetVisibleList
        public List<bool> GetVisibleList(string tabName)
        {
            return _visibleList[_model.GetCategoryIndex(tabName)];
        }

        //SetVisibleList
        public void SetVisibleList(string tabName)
        {
            const int BUTTON_COUNT = 3;
            int books = _model.GetBookCategoriesBooks(tabName).Count;
            for (int i = 0; i < books; i++)
            {
                if ((_currentPage - 1) * BUTTON_COUNT <= i && i < _currentPage * BUTTON_COUNT)
                    _visibleList[_model.GetCategoryIndex(tabName)][i] = true;
                else
                    _visibleList[_model.GetCategoryIndex(tabName)][i] = false;
            }
        }

        //ReturnList
        public List<string[]> ReturnList()
        {
            const int INDEXER = 2;
            List<string[]> result = new List<string[]>();
            List<Book> temp = new List<Book>();
            string[] array;
            foreach (Book book in _model.GetBorrowList())
            {
                if (temp.Count(x => x == book) >= 1)
                    continue;
                temp.Add(book);
                array = book.GetDataGridViewArray();
                array[INDEXER] = _model.GetBorrowList().Count(x => x == book).ToString();
                result.Add(array);
            }
            return result;
        }
    }
}
