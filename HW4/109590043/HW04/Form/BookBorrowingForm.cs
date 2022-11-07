using DataGridViewNumericUpDownElements;
using Homework.PresentationModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace Homework
{
    public partial class BookBorrowingForm : Form
    {
        private Model _model;
        private BookBorrowingFormPresentationModel _borrowingFormPresentationModel;
        private BackPackForm _backPackForm;

        public BookBorrowingForm(Model model)
        {
            InitializeComponent();
            _model = model;
        }

        //Form1Load
        private void Form1Load(object sender, EventArgs e)
        {
            _borrowingFormPresentationModel = new BookBorrowingFormPresentationModel(_model);
            _backPackForm = new BackPackForm(_model);
            _addBook.Enabled = false;
            _confirm.Enabled = false;
            _backPackForm._updateBorrowingForm += this.UpdateButtonView;
            _model._updateBookItem += this.UpdateButtonView;
            _model._showMessage += this.ShowMessage;
            _model._updateEditedBook += this.SetView;
            _model._updateEditedBook += this.UpdateRichBox;
            _backPackForm.FormClosing += new FormClosingEventHandler(BackPackFormClosing);
            SetDataGridView();
            SetView();
            _tabControl1.Selecting += new TabControlCancelEventHandler(ControlSelecting);   
        }

        //ControlSelecting
        void ControlSelecting(object sender, TabControlCancelEventArgs e)
        {
            if (this._tabControl1.SelectedTab != null)
            {
                _borrowingFormPresentationModel.ResetCurrentPage(this._tabControl1.SelectedTab.Text);
                this._borrowingFormPresentationModel.ListInitialize();
                UpdateView();
            }
        }

        //SetView
        private void SetView()
        {
            List<BookCategory> bookCategories = _model.GetBookCategories();
            this._tabControl1.TabPages.Clear();
            foreach (BookCategory bookCategory in bookCategories)
            {  
                TabPage tabPage = new TabPage(bookCategory.GetCategoryName());
                this._tabControl1.TabPages.Add(tabPage);
                for (int book = 0; book < bookCategory.GetBookCount(); book++)
                {
                    CreateButton(tabPage, book);
                }
            }
            this._borrowingFormPresentationModel.ListInitialize();
            _borrowingFormPresentationModel.ResetCurrentPage(this._tabControl1.SelectedTab.Text);
            UpdateView();
        }

        //CreateButton
        private void CreateButton(TabPage tabPage, int book)
        {
            const int POSITION = 10;
            const int WIDTH = 75;
            const int HEIGHT = 90;
            const int SPACING = 82;
            Button button = new Button();
            tabPage.Controls.Add(button);
            button.Location = new Point(POSITION + SPACING * (book % 3), POSITION);
            button.Size = new Size(WIDTH, HEIGHT);
            button.Tag = book;
            button.BackgroundImage = Image.FromFile(_model.GetImageByTag(tabPage.Text, book));
            button.BackgroundImageLayout = ImageLayout.Stretch;
            button.Click += new System.EventHandler(ButtonClick);
        }

        //SetDataGridView
        private void SetDataGridView()
        {
            const int COLUMN_COUNT = 5;
            const int TWO_COLUMN = 2;
            string[] columnName = new string[4] { "書籍名稱", "書籍編號", "作者", "出版社" };
            DataGridViewButtonColumn deleteColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            deleteColumn.HeaderText = "刪除";
            deleteColumn.Name = "deleteColumn";
            _dataGridView1.Columns.Add(deleteColumn);
            _dataGridView1.ColumnCount = COLUMN_COUNT;
            _dataGridView1.EditingControlShowing += EditingControlShowing;
            _dataGridView1.CellValueChanged += ChangeCellValue;
            for (int i = 1; i < COLUMN_COUNT; i++)
                _dataGridView1.Columns[i].Name = columnName[i - 1];
            _dataGridView1.Columns.Insert(TWO_COLUMN, new DataGridViewNumericUpDownColumn());
            _dataGridView1.Columns[TWO_COLUMN].Name = "數量";
            ((DataGridViewNumericUpDownColumn)_dataGridView1.Columns[TWO_COLUMN]).Minimum = 1;
        }

        //EditingControlShowing
        private void EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.TextChanged -= this.EditTextChanged;
            e.Control.TextChanged += this.EditTextChanged;
        }

        //EditTextChanged
        private void EditTextChanged(object sender, EventArgs e)
        {
            this._dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        //ChangeBorrowCount
        private void ChangeCellValue(object sender, DataGridViewCellEventArgs e)
        {
            const int INDEX = 2;
            var grid = (DataGridView)sender;
            if (e.RowIndex < 0)
                return;
            this._model.JudgeMessageLimit(int.Parse(grid[INDEX, e.RowIndex].Value.ToString()), grid.Rows[e.RowIndex].Cells[1].Value.ToString(), e.RowIndex);
            UpdateButtonView();
        }

        //ShowMessage
        private void ShowMessage(string content, string title, int rowIndex, int resultCount)
        {
            const int INDEX = 2;
            this._dataGridView1.EndEdit();
            MessageBox.Show(content, title);
            this._dataGridView1.Rows[rowIndex].Cells[INDEX].Value = resultCount.ToString();
        }

        //DeleteBookInBorrowList
        private void DeleteBookInBorrowList(object sender, DataGridViewCellEventArgs e)
        {
            var grid = (DataGridView)sender;
            if (e.RowIndex < 0)
                return;
            if (grid[e.ColumnIndex, e.RowIndex] is DataGridViewButtonCell)
            {
                _model.UpdateBorrowListByCount(0, grid.Rows[e.RowIndex].Cells[1].Value.ToString());
                _dataGridView1.Rows.RemoveAt(e.RowIndex);
                UpdateButtonView();
            }
        }

        //SetDataGridViewCellPainting
        private void SetDataGridViewCellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            if (e.ColumnIndex == 0)
            {
                const int TWO = 2;
                Image img = Image.FromFile("../../../image/trash_can.png");
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                var w = img.Width;
                var h = img.Height;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / TWO;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / TWO;

                e.Graphics.DrawImage(img, new Rectangle(x, y, w, h));
                e.Handled = true;
            }
        }

        //ButtonClick
        private void ButtonClick(object sender, EventArgs e)
        {
            Book book = _model.GetBookByTag(this._tabControl1.SelectedTab.Text, int.Parse(((Button)sender).Tag.ToString()));
            this._borrowingFormPresentationModel.SetCurrentBookAndItem(book);
            //this._richTextBox1.Text = _model.GetContentByTag(this._tabControl1.SelectedTab.Text, int.Parse(((Button)sender).Tag.ToString()));
            UpdateRichBox();
            UpdateButtonView();
        }

        //AddBookClick
        private void AddBookClick(object sender, EventArgs e)
        {
            const string LIMIT_WARNING = "每次借書限界五本，你的借書單已滿。";
            if (_borrowingFormPresentationModel.IsOverLimit())
                MessageBox.Show(LIMIT_WARNING);
            else
            {
                UpdateDataGridView();
                UpdateButtonView();
            }
        }

        //ConfirmClick
        private void ConfirmClick(object sender, EventArgs e)
        {
            List<string> names = new List<string>();
            List<string> counts = new List<string>();
            const int INDEX_OF_COUNTS_COLUMN = 2;
            foreach (DataGridViewRow row in _dataGridView1.Rows)
            {
                names.Add(row.Cells[1].Value.ToString());
                counts.Add(row.Cells[INDEX_OF_COUNTS_COLUMN].Value.ToString());
            }
            MessageBox.Show(_borrowingFormPresentationModel.GetMessage(names, counts));
            _model.UpdateBorrowedList();
            _model.ClearBorrowList();
            _dataGridView1.Rows.Clear();
            _backPackForm.CreateGridRow();
            _model.UpdateBookItem();
            UpdateButtonView();
        }

        //GoNextPageClick
        private void GoNextPageClick(object sender, EventArgs e)
        {
            string currentTabName = this._tabControl1.SelectedTab.Text;
            _borrowingFormPresentationModel.SetAddCurrentPage(currentTabName);
            UpdateView();
        }

        //GoPreviousPageClick
        private void GoPreviousPageClick(object sender, EventArgs e)
        {
            string currentTabName = this._tabControl1.SelectedTab.Text;
            _borrowingFormPresentationModel.SetMinusCurrentPage(currentTabName);
            UpdateView();
        }

        //GoViewBagClick
        private void GoViewBagClick(object sender, EventArgs e)
        {
            
            this._viewBag.Enabled = false;
            this._backPackForm.Show();
        }

        //UpdateView
        private void UpdateView()
        {
            string currentTabName = this._tabControl1.SelectedTab.Text;
            _borrowingFormPresentationModel.SetNextEnable(currentTabName);
            _borrowingFormPresentationModel.SetPreviousEnable();
            _previousPage.Enabled = _borrowingFormPresentationModel.IsPreviousEnable();
            _nextPage.Enabled = _borrowingFormPresentationModel.IsNextEnable();
            _borrowingFormPresentationModel.SetVisibleList(currentTabName);
            _page.Text = _borrowingFormPresentationModel.GetPageText();
            int buttonIndex = 0;
            List<bool> visibleList = _borrowingFormPresentationModel.GetVisibleList(currentTabName);
            foreach (object button in this._tabControl1.SelectedTab.Controls)
            {
                bool i = visibleList[buttonIndex];
                ((Button)button).Visible = visibleList[buttonIndex++];
            }
        }

        //UpdateButtonView
        private void UpdateButtonView()
        {
            const string REST_COUNT = "剩餘數量：";
            const string BORROW_COUNT = "借書數量：";
            this._restCount.Text = REST_COUNT + _borrowingFormPresentationModel.GetRestBookCount().ToString();
            _borrowBookCount.Text = BORROW_COUNT + _model.GetBorrowedBookCount().ToString();
            _addBook.Enabled = _borrowingFormPresentationModel.IsAddBookEnable();
            _confirm.Enabled = _borrowingFormPresentationModel.IsConfirmEnable();
        }

        //UpdateRichBox
        private void UpdateRichBox()
        {
            this._richTextBox1.Text = _borrowingFormPresentationModel.GetCurrentBookContent();
            UpdateDataGridView();
        }

        //UpdateDataGridView
        private void UpdateDataGridView()
        {
            this._dataGridView1.Rows.Clear();
            foreach (string[] borrowItem in this._borrowingFormPresentationModel.ReturnList())
                this._dataGridView1.Rows.Add(borrowItem);
        }

        //BackPackFormClosing
        private void BackPackFormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                _backPackForm.Hide();
                this._viewBag.Enabled = true;
            }
        }
    }
}