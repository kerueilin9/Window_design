using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework.PresentationModel
{
    public class BookInventoryFormPresentationModel
    {
        private Model _model;
        private Book _currentBook;

        public BookInventoryFormPresentationModel(Model model)
        {
            this._model = model;
        }

        //GetContent
        public string GetContent(string name, string category, string count)
        {
            const string NAME_LABEL = "書籍名稱：";
            const string CATEGORY_LABEL = "書籍類別：";
            const string COUNT_LABEL = "庫存數量：";
            const string NEW_LINE = "\n";
            return NAME_LABEL + name + NEW_LINE + NEW_LINE + CATEGORY_LABEL + category + NEW_LINE + COUNT_LABEL + count;
        }

        public Book CurrentBook
        {
            get
            {
                return _currentBook;
            }
            set
            {
                _currentBook = value;
            }
        }

        //GetImage
        public string GetImage()
        {
            return _currentBook.GetImage();
        }

        //GetContentText
        public string GetContentText()
        {
            return _currentBook.GetAllContent();
        }

        //GetName
        public string GetName()
        {
            if (_currentBook != null)
                return _currentBook.GetName();
            else
                return "";
        }

        //GetCurrentIndex
        public bool IsCurrentIndex(string rowValue)
        {
            if (GetName() == rowValue)
                return true;
            else
                return false;
        }
    }
}
