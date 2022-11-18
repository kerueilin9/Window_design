using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework
{
    public class BookManagementFormPresentationModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private Model _model;
        private Book _book;
        private string _nameTextBox = "";
        private string _idTextBox = "";
        private string _authorTextBox = "";
        private string _publisherTextBox = "";
        private string _fileTextBox = "";
        private string _categoryComboBox = "";
        private bool _isAddBookButton = false;
        private bool _isSave = false;
        private bool _isBrowse = false;
        private bool _categoryChange = false;
        private bool _imageChange = false;

        private const int INDEX0 = 0;
        private const int INDEX1 = 1;
        private const int INDEX2 = 2;
        private const int INDEX3 = 3;
        private const int INDEX4 = 4;

        public BookManagementFormPresentationModel(Model model)
        {
            this._model = model;
        }

        #region getset
        public string NameTextBox
        {
            get 
            {
                return _nameTextBox;
            }
            set
            {
                _nameTextBox = value;
                JudgeIsSave();
            }
        }

        public string IdTextBox
        {
            get
            {
                return _idTextBox;
            }
            set
            {
                _idTextBox = value;
                JudgeIsSave();
            }
        }

        public string AuthorTextBox
        {
            get
            {
                return _authorTextBox;
            }
            set
            {
                _authorTextBox = value;
                JudgeIsSave();
            }
        }

        public string PublisherTextBox
        {
            get
            {
                return _publisherTextBox;
            }
            set
            {
                _publisherTextBox = value;
                JudgeIsSave();
            }
        }

        public string FileTextBox
        {
            get
            {
                return _fileTextBox;
            }
            set
            {
                if (value != _fileTextBox)
                {
                    _fileTextBox = value;
                    JudgeIsSave();
                    _imageChange = true;
                }
            }
        }

        public string CategoryComboBox
        {
            get
            {
                return _categoryComboBox;
            }
            set
            {
                if (value != _categoryComboBox)
                {
                    _categoryComboBox = value;
                    JudgeIsSave();
                    _categoryChange = true;
                }
            }
        }

        public bool IsAddBookButton
        {
            get
            {
                return _isAddBookButton;
            }
            set
            {
                _isAddBookButton = value;
            }
        }

        public bool IsSave
        {
            get
            {
                return _isSave;
            }
            set
            {
                _isSave = value;
            }
        }

        public bool IsBrowse
        {
            get
            {
                return _isBrowse;
            }
            set
            {
                _isBrowse = value;
            }
        }
        #endregion

        //JudgeIsSave
        public void JudgeIsSave()
        {
            string[] contentArray = _book.GetArray();
            bool notNull = _nameTextBox != "" && _idTextBox != "" && _authorTextBox != "" && _publisherTextBox != "" && _categoryComboBox != "" && _fileTextBox != "";
            bool notEqual = _nameTextBox != contentArray[INDEX0] || _idTextBox != contentArray[INDEX1] || _authorTextBox != contentArray[INDEX2] || _publisherTextBox != contentArray[INDEX3] || _fileTextBox != contentArray[INDEX4] || _categoryComboBox != _model.GetCategoryByBook(_book).GetCategoryName();
            if (notEqual && notNull)
                _isSave = true;
            else
                _isSave = false;
            Notify();
        }

        //GetListBoxList
        public List<string> GetListBoxList()
        {
            List<string> bookNames = new List<string>();
            foreach (BookCategory bookCategory in _model.GetBookCategories())
                foreach (Book book in bookCategory.GetBooks())
                    bookNames.Add(book.GetName());
            return bookNames;
        }

        //GetFilePath
        public string GetFilePath(string fileName)
        {
            const string FILE_PATH = "../../../image/";
            return FILE_PATH + fileName;
        }

        //GetCategoryNames
        public List<string> GetCategoryNames()
        {
            List<string> categoryNames = new List<string>();
            foreach (BookCategory bookCategory in _model.GetBookCategories())
                categoryNames.Add(bookCategory.GetCategoryName());
            return categoryNames;
        }

        //ChangeContent
        public void ChangeContent(string name)
        {
            _book = _model.GetBookByName(name);
            string[] contentArray = _book.GetArray();
            _nameTextBox = contentArray[INDEX0];
            _idTextBox = contentArray[INDEX1];
            _authorTextBox = contentArray[INDEX2];
            _publisherTextBox = contentArray[INDEX3];
            _fileTextBox = contentArray[INDEX4];
            _categoryComboBox = _model.GetCategoryByName(name).GetCategoryName();
            _isBrowse = true;
            Notify();
        }

        //ClickSave
        public void ClickSave()
        {
            _book.SetName(_nameTextBox);
            _book.SetId(_idTextBox);
            _book.SetAuthor(_authorTextBox);
            _book.SetPublisher(_publisherTextBox);
            _book.SetImage(_fileTextBox);
            if (_categoryChange)
            {
                _model.GetCategoryByBook(_book).DeleteBook(_book);
                _model.GetCategoryByTagName(_categoryComboBox).AddBook(_book);
            }
            if (_imageChange || _categoryChange)
                _model.UpdateTabView();
            _categoryChange = false;
            _imageChange = false;
            JudgeIsSave();
            _model.UpdateEditedBook();
        }

        //Notify
        private void Notify()
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(""));
        }
    }
}
