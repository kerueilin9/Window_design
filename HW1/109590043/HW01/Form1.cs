using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Homework01
{
    public partial class Form1 : Form
    {
        private Model _model;
        private int _bookId = 1;

        public Form1(Model model)
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
            _model.CreateBookItem();
            SetDataGridView();
            SetView();
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
        }

        //CreateButton
        private void CreateButton(TabPage tabPage, int book)
        {
            const int POSITION = 10;
            const int WIDTH = 60;
            const int HEIGHT = 90;
            const int SPACING = 65;
            const string BOOK = "Book ";
            Button button = new Button();
            tabPage.Controls.Add(button);
            button.Location = new Point(POSITION + SPACING * book, POSITION);
            button.Size = new Size(WIDTH, HEIGHT);
            button.Text = BOOK + _bookId++.ToString();
            button.Tag = book;
            button.Click += new System.EventHandler(ButtonClick);
        }

        //SetDataGridView
        private void SetDataGridView()
        {
            const int COLUMN_COUNT = 4;
            const string NAME = "書籍名稱";
            const string ID = "書籍編號";
            const string AUTHOR = "作者";
            const string PUBLISHER = "出版社";
            string[] columnName = new string[COLUMN_COUNT] { NAME, ID, AUTHOR, PUBLISHER };
            _dataGridView1.ColumnCount = COLUMN_COUNT;
            _dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            for (int i = 0; i < COLUMN_COUNT; i++)
            {
                _dataGridView1.Columns[i].Name = columnName[i];
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
    }
}