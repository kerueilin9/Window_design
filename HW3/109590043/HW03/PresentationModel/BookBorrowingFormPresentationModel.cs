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
        private string _pageText;
        public event Action<string, string> _showMessage;

        public BookBorrowingFormPresentationModel(Model model)
        {
            this._model = model;
            Initialize();
            ListInitialize();
        }

        //ListInitialize
        private void ListInitialize()
        {
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
            int addPage = 1;
            const string PAGE_TEXT = "Page：{0}/{1}";
            List<BookCategory> bookCategories = _model.GetBookCategories();
            if (bookCategories[FIRST_CATEGORIES].GetBooks().Count % BUTTON_COUNT == 0)
                addPage = 0;
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

        //GetCurrentPage
        public int GetCurrentPage()
        {
            return this._currentPage;
        }

        //SetCurrentPage
        public void SetCurrentPage(int page)
        {
            this._currentPage = page;
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
            if (this._currentPage == books.Count / BUTTON_COUNT + addPage)
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
            return _model.IsAddButtonEnable();
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
            if (_model.GetBorrowList().Count == BORROWING_LIMIT)
                return true;
            else
                return false;
        }

        //GetMessage
        public string GetMessage()
        {
            return _model.GetSuccessMessage();
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

        public void GetMessage(int count, string name)
        {
            const string LIMIT_TITLE = "借書違規";
            const string OVER_TITLE = "庫存狀態";
            const string LIMIT_CONTENT = "同一本書限借兩次";
            const string OVER_CONTENT = "該書本剩餘數量不足";
            if (count > 2)
                ShowMessage(LIMIT_CONTENT, LIMIT_TITLE);
            else if (count > _model.GetBookItemByName(name).GetBookCount())
                ShowMessage(OVER_CONTENT, OVER_TITLE);
        }

        public void ShowMessage(string content, string title)
        {
            if (this._showMessage != null)
                this._showMessage(content, title);
        }
    }
}
