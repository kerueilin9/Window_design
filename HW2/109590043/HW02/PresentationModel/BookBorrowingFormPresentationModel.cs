using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Homework02.PresentationModel
{
    public class BookBorrowingFormPresentationModel
    {
        private Model _model;
        private List<List<bool>> _visibleList = new List<List<bool>>();
        private bool _nextEnable;
        private bool _previousEnable;
        private int _currentPage;
        private string _pageText;

        public BookBorrowingFormPresentationModel(Model model)
        {
            this._model = model;
            Initailize();
            ListInitailize();
        }

        private void ListInitailize()
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

        private void Initailize()
        {
            int BUTTON_COUNT = 3;
            int FIRST_CATEGORIES = 0;
            int ONE = 1;
            List<BookCategory> bookCategories = _model.GetBookCategories();
            _pageText = String.Format("Page：{0}/{1}", "1", bookCategories[FIRST_CATEGORIES].GetBooks().Count / BUTTON_COUNT + ONE);
        }

        public string GetPageText()
        {
            return this._pageText;
        }

        public void SetPageText(int page, string tabName)
        {
            int BUTTON_COUNT = 3;
            int ONE = 1;
            List<Book> books = _model.GetBookCategoriesBooks(tabName);
            this._pageText = String.Format("Page：{0}/{1}", _currentPage, books.Count / BUTTON_COUNT + ONE); ;
        }

        public int GetCurrentPage()
        {
            return this._currentPage;
        }

        public void SetCurrentPage(int page)
        {
            this._currentPage = page;
        }

        public void SetAddCurrentPage(string tabName)
        {
            this._currentPage++;
            SetPageText(_currentPage, tabName);
        }
        public void SetMinusCurrentPage(string tabName)
        {
            this._currentPage--;
            SetPageText(_currentPage, tabName);
        }

        public void ResetCurrentPage(string tabName)
        {
            this._currentPage = 1;
            SetPageText(_currentPage, tabName);
        }

        public bool GetNextEnable()
        {
            return this._nextEnable;
        }
        
        public void SetNextEnable(string tabName)
        {
            int BUTTON_COUNT = 3;
            int ONE = 1;
            List<Book> books = _model.GetBookCategoriesBooks(tabName);
            if (this._currentPage == books.Count / BUTTON_COUNT + ONE)
                this._nextEnable = false;
            else
                this._nextEnable = true;
        }

        public bool GetPreviousEnable()
        {
            return this._previousEnable;
        }

        public void SetPreviousEnable()
        {
            if (this._currentPage <= 1)
                this._previousEnable = false;
            else
                this._previousEnable = true;
        }

        public List<bool> GetVisibleListByCategorie(string tabName)
        {
            return _visibleList[_model.GetCategoryIndex(tabName)];
        }

        public void SetVisibleList(string tabName)
        {
            int BUTTON_COUNT = 3;
            int ONE = 1;
            int books = _model.GetBookCategoriesBooks(tabName).Count;
            for (int i = 0; i < books; i++)
            {
                if ((_currentPage - ONE) * BUTTON_COUNT <= i && i < _currentPage * BUTTON_COUNT)
                    _visibleList[_model.GetCategoryIndex(tabName)][i] = true;
                else
                    _visibleList[_model.GetCategoryIndex(tabName)][i] = false;
            }
        }
    }
}
