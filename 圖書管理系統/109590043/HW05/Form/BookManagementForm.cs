using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Homework
{
    public partial class BookManagementForm : Form
    {
        private Model _model;
        private BookManagementFormPresentationModel _presentationModel;

        public BookManagementForm()
        {
            InitializeComponent();
        }

        public BookManagementForm(Model model)
        {
            this._presentationModel = new BookManagementFormPresentationModel(model);
            this._model = model;
            InitializeComponent();
            const string TEXT_TYPE = "Text";
            const string ENABLE_TYPE = "Enabled";
            _nameTextBox.DataBindings.Add(TEXT_TYPE, _presentationModel, "NameTextBox");
            _idTextBox.DataBindings.Add(TEXT_TYPE, _presentationModel, "IdTextBox");
            _authorTextBox.DataBindings.Add(TEXT_TYPE, _presentationModel, "AuthorTextBox");
            _publisherTextBox.DataBindings.Add(TEXT_TYPE, _presentationModel, "PublisherTextBox");
            _fileTextBox.DataBindings.Add(TEXT_TYPE, _presentationModel, "FileTextBox");
            _categoryComboBox.DataBindings.Add(TEXT_TYPE, _presentationModel, "CategoryComboBox");
            _addBookButton.DataBindings.Add(ENABLE_TYPE, _presentationModel, "IsAddBookButton");
            _save.DataBindings.Add(ENABLE_TYPE, _presentationModel, "IsSave");
            _browse.DataBindings.Add(ENABLE_TYPE, _presentationModel, "IsBrowse");
        }

        //FormLoad
        private void FormLoad(object sender, EventArgs e)
        {
            CreateList();
            foreach (string name in _presentationModel.GetCategoryNames())
                _categoryComboBox.Items.Add(name);
        }

        //CreateList
        public void CreateList()
        {
            this._bookList.Items.Clear();
            foreach (String bookName in _presentationModel.GetListBoxList())
            {
                this._bookList.Items.Add(bookName);
            }
        }

        //SelectedIndexChanged
        private void SelectedIndexChanged(object sender, EventArgs e)
        {
            _presentationModel.ChangeContent(_bookList.SelectedItem.ToString());
            _nameTextBox.Enabled = true;
            _idTextBox.Enabled = true;
            _authorTextBox.Enabled = true;
            _publisherTextBox.Enabled = true;
            _categoryComboBox.Enabled = true;
            _fileTextBox.Enabled = true;
        }

        //ChangeNameTextBoxText
        private void ChangeNameTextBoxText(object sender, EventArgs e)
        {
            _presentationModel.NameTextBox = _nameTextBox.Text;
        }

        //ChangeIdTextBoxTextChange
        private void ChangeIdTextBoxTextChange(object sender, EventArgs e)
        {
            _presentationModel.IdTextBox = _idTextBox.Text;
        }

        //ChangeAuthorTextBoxText
        private void ChangeAuthorTextBoxText(object sender, EventArgs e)
        {
            _presentationModel.AuthorTextBox = _authorTextBox.Text;
        }

        //ChangeCategoryComboBoxSelectedIndex
        private void ChangeCategoryComboBoxSelectedIndex(object sender, EventArgs e)
        {
            _presentationModel.CategoryComboBox = _categoryComboBox.Text;
        }

        //ChangePublisherTextBoxText
        private void ChangePublisherTextBoxText(object sender, EventArgs e)
        {
            _presentationModel.PublisherTextBox = _publisherTextBox.Text;
        }

        //ChangeFileTextBoxText
        private void ChangeFileTextBoxText(object sender, EventArgs e)
        {
            _presentationModel.FileTextBox = _fileTextBox.Text;
        }

        //ClickBrowse
        private void ClickBrowse(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Files|*.jpg;*.jpeg;*.png;";
            dialog.InitialDirectory = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"../../../image/"));
            dialog.Title = "請選擇書籍圖片";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                _fileTextBox.Text = _presentationModel.GetFilePath(dialog.SafeFileName);
            }
        }

        //ClickSave
        private void ClickSave(object sender, EventArgs e)
        {
            _presentationModel.ClickSave();
            CreateList();
            int index = _bookList.FindString(_presentationModel.NameTextBox);
            if (index != -1)
                _bookList.SetSelected(index, true);
        }
    }
}
