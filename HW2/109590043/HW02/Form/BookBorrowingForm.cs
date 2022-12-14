using Homework02.PresentationModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace Homework02
{
    public partial class BookBorrowingForm : Form
    {
        private Model _model;
        private int _bookId = 1;
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
            _addBook.Enabled = false;
            _confirm.Enabled = false;
            _model.ReadFile();
            _model.CreateBook();
            _borrowingFormPresentationModel = new BookBorrowingFormPresentationModel(_model);
            _backPackForm = new BackPackForm(_model);
            _backPackForm._updateBorrowingForm += this.UpdateButtonView;
            _backPackForm.FormClosing += new FormClosingEventHandler(BackPackFormClosing);
            SetDataGridView();
            SetView();
            _tabControl1.Selecting += new TabControlCancelEventHandler(ControlSelecting);   
        }

        //ControlSelecting
        void ControlSelecting(object sender, TabControlCancelEventArgs e)
        {
            _borrowingFormPresentationModel.ResetCurrentPage(this._tabControl1.SelectedTab.Text);
            UpdateView();
        }

        //SetView
        private void SetView()
        {
            List<BookCategory> bookCategories = _model.GetBookCategories();
            foreach (BookCategory bookCategory in bookCategories)
            {
                TabPage tabPage = new TabPage(bookCategory.GetCategoryName());
                this._tabControl1.TabPages.Add(tabPage);
                for (int book = 0; book < bookCategory.GetBookCount(); book++)
                {
                    CreateButton(tabPage, book);
                }
            }
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
            button.BackgroundImage = Image.FromFile(string.Format("../../../image/{0}.jpg", _bookId++));
            button.BackgroundImageLayout = ImageLayout.Stretch;
            button.Click += new System.EventHandler(ButtonClick);
        }

        //SetDataGridView
        private void SetDataGridView()
        {
            const int COLUMN_COUNT = 6;
            string[] columnName = new string[5] { "書籍名稱", "數量", "書籍編號", "作者", "出版社" };
            DataGridViewButtonColumn deleteColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            deleteColumn.HeaderText = "刪除";
            deleteColumn.Name = "deleteColumn";
            _dataGridView1.Columns.Add(deleteColumn);
            _dataGridView1.ColumnCount = COLUMN_COUNT;
            _dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            _dataGridView1.AllowUserToAddRows = false;
            _dataGridView1.RowHeadersVisible = false;
            _dataGridView1.CellClick += new DataGridViewCellEventHandler(DeleteBookInBorrowList);
            _dataGridView1.CellPainting += new DataGridViewCellPaintingEventHandler(SetDataGridViewCellPainting);
            for (int i = 1; i < COLUMN_COUNT; i++)
                _dataGridView1.Columns[i].Name = columnName[i - 1];
        }

        //DeleteBookInBorrowList
        private void DeleteBookInBorrowList(object sender, DataGridViewCellEventArgs e)
        {
            var grid = (DataGridView)sender;
            if (e.RowIndex < 0)
                return;
            if (grid[e.ColumnIndex, e.RowIndex] is DataGridViewButtonCell)
            {
                _model.DeleteBorrowListUseName(grid.Rows[e.RowIndex].Cells[1].Value.ToString());
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
            this._richTextBox1.Text = _model.GetContent(this._tabControl1.SelectedTab.Text, int.Parse(((Button)sender).Tag.ToString()));
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
                _dataGridView1.Rows.Add(_model.GetBorrowBookArray());
                _model.UpdateBorrowList();
                UpdateButtonView();   
            }
        }

        //ConfirmClick
        private void ConfirmClick(object sender, EventArgs e)
        {
            MessageBox.Show(_borrowingFormPresentationModel.GetMessage());
            _model.UpdateBorrowedList();
            _model.ClearBorrowList();
            _dataGridView1.Rows.Clear();
            _backPackForm.CreateGridRow();
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
            _page.Text = _borrowingFormPresentationModel.GetPageText();
            _borrowingFormPresentationModel.SetVisibleList(currentTabName);
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
            this._restCount.Text = REST_COUNT + _model.GetRestBookCount().ToString();
            _borrowBookCount.Text = BORROW_COUNT + _model.GetBorrowedBookCount().ToString();
            _addBook.Enabled = _borrowingFormPresentationModel.IsAddBookEnable();
            _confirm.Enabled = _borrowingFormPresentationModel.IsConfirmEnable();
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