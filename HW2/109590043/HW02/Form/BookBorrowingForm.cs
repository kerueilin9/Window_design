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
        private BookBorrowingFormPresentationModel borrowingFormPresentationModel;

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
            SetDataGridView();
            SetView();
            _tabControl1.Selecting += new TabControlCancelEventHandler(tabControl1_Selecting);
            borrowingFormPresentationModel = new BookBorrowingFormPresentationModel(_model);
        }

        void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            List<Book> books = _model.GetBookCategoriesBooks(this._tabControl1.SelectedTab.Text);
            this._page.Text = String.Format("Page：{0}/{1}", "1", books.Count / 3 + 1);
            //TabPage current = (sender as TabControl).SelectedTab;

            //// Validate the current page. To cancel the select, use:
            //e.Cancel = true;
        }
        //SetView
        private void SetView()
        {
            List<BookCategory> bookCategories = _model.GetBookCategories();
            this._page.Text = String.Format("Page：{0}/{1}", "1", bookCategories[0].GetBooks().Count / 3 + 1);
            foreach (BookCategory bookCategory in bookCategories)
            {
                TabPage tabPage = new TabPage(bookCategory.GetCategoryName());
                this._tabControl1.TabPages.Add(tabPage);
                for (int book = 0; book < bookCategory.GetBookCount(); book++)
                {
                    CreateButton(tabPage, book);
                }
            }
        }

        //CreateButton
        private void CreateButton(TabPage tabPage, int book)
        {
            const int POSITION = 10;
            const int WIDTH = 75;
            const int HEIGHT = 90;
            const int SPACING = 82;
            const string BOOK = "Book ";
            Button button = new Button();
            tabPage.Controls.Add(button);
            button.Location = new Point(POSITION + SPACING * (book % 3), POSITION);
            button.Size = new Size(WIDTH, HEIGHT);
            button.Text = BOOK + _bookId++.ToString();
            button.Tag = book;
            button.Click += new System.EventHandler(ButtonClick);
        }

        //SetDataGridView
        private void SetDataGridView()
        {
            const int COLUMN_COUNT = 5;
            string[] columnName = new string[4] { "書籍名稱", "書籍編號", "作者", "出版社" };
            DataGridViewButtonColumn deleteColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            deleteColumn.HeaderText = "刪除";
            deleteColumn.Name = "deleteColumn";
            deleteColumn.Text = "退選";
            deleteColumn.UseColumnTextForButtonValue = true;
            _dataGridView1.Columns.Add(deleteColumn);
            _dataGridView1.ColumnCount = COLUMN_COUNT;
            _dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            for (int i = 1; i < COLUMN_COUNT; i++)
            {
                _dataGridView1.Columns[i].Name = columnName[i - 1];
            }
        }

        private void _dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            //I supposed your button column is at index 0
            if (e.ColumnIndex == 0)
            {
                Image img = Image.FromFile("../../../image/trash_can.png");
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                var w = img.Width;
                var h = img.Height;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;

                e.Graphics.DrawImage(img, new Rectangle(x, y, w, h));
                e.Handled = true;
            }
        }

        //ButtonClick
        private void ButtonClick(object sender, EventArgs e)
        {
            const string REST_COUNT = "剩餘數量：";
            this._richTextBox1.Text = _model.GetContent(this._tabControl1.SelectedTab.Text, int.Parse(((Button)sender).Tag.ToString()));
            this._restCount.Text = REST_COUNT + _model.GetRestBookCount().ToString();
            if (_model.GetRestBookCount() <= 0)
                _addBook.Enabled = false;
            else
                _addBook.Enabled = true;
        }

        //AddBookClick
        private void AddBookClick(object sender, EventArgs e)
        {
            const string REST_COUNT = "剩餘數量：";
            const string BORROW_COUNT = "借書數量：";
            _dataGridView1.Rows.Add(_model.GetBorrowBook());
            _confirm.Enabled = true;
            this._restCount.Text = REST_COUNT + _model.GetRestBookCount().ToString();
            _borrowBookCount.Text = BORROW_COUNT + _model.GetBorrowedBookCount().ToString();
            if (_model.GetRestBookCount() <= 0)
            {
                _addBook.Enabled = false;
            }
        }

        //ConfirmClick
        private void ConfirmClick(object sender, EventArgs e)
        {

        }

        private void _nextPage_Click(object sender, EventArgs e)
        {
            foreach (object button in this._tabControl1.SelectedTab.Controls)
            {
                ((Button)button).Visible = false;
            }
        }

        private void _previousPage_Click(object sender, EventArgs e)
        {

        }
    }
}