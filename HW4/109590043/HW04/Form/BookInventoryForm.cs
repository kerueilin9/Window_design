using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Homework.PresentationModel;

namespace Homework
{
    public partial class BookInventoryForm : Form
    {
        private Model _model;
        private BookInventoryFormPresentationModel _formPresentationModel;
        public BookInventoryForm(Model model)
        {
            this._model = model;
            InitializeComponent();
        }

        //BookInventoryForm_Load
        private void BookInventoryFormLoad(object sender, EventArgs e)
        {
            _formPresentationModel = new BookInventoryFormPresentationModel(_model);
            this._model._updateBookItem += UpdateDataGridViewRows;
            this._model._updateEditedBook += UpdateDataGridViewRows;
            SetDataGridView();
            AddDataGridViewRows();
        }

        //SetDataGridView
        private void SetDataGridView()
        {
            DataGridViewButtonColumn deleteColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            deleteColumn.HeaderText = "補貨";
            deleteColumn.Name = "deleteColumn";
            deleteColumn.FillWeight = 15;
            _dataGridView1.Columns.Add(deleteColumn);
            this._dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this._dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        //ReplenishBook
        private void SupplyBook(object sender, DataGridViewCellEventArgs e)
        {
            var grid = (DataGridView)sender;
            if (e.RowIndex < 0)
                return;
            if (grid[e.ColumnIndex, e.RowIndex] is DataGridViewButtonCell)
            {
                BookItem bookItem = _model.GetBookItemByName(grid.Rows[e.RowIndex].Cells[0].Value.ToString());
                string content = _formPresentationModel.GetContent(grid.Rows[e.RowIndex].Cells[0].Value.ToString(), grid.Rows[e.RowIndex].Cells[1].Value.ToString(), grid.Rows[e.RowIndex].Cells[2].Value.ToString());
                SupplementForm form = new SupplementForm(_model, bookItem, content);
                form.ShowDialog();
            }
        }

        //SetDataGridViewCellPainting
        private void SetDataGridViewCellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            if (e.ColumnIndex == 3)
            {
                const int TWO = 2;
                Image img = Image.FromFile("../../../image/replenishment.png");
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                var w = img.Width;
                var h = img.Height;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / TWO;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / TWO;

                e.Graphics.DrawImage(img, new Rectangle(x, y, w, h));
                e.Handled = true;
            }
        }

        //ShowContentCellClick
        private void ShowContentCellClick(object sender, DataGridViewCellEventArgs e)
        {
            var grid = (DataGridView)sender;
            if (e.RowIndex < 0)
                return;
            else
            {
                string bookName = grid.Rows[e.RowIndex].Cells[0].Value.ToString();
                _formPresentationModel.CurrentBook = _model.GetBookByName(bookName);
                this._model._updateEditedBook += UpdateContent;
                UpdateContent();
            }
        }

        //AddDataGridViewRows
        private void AddDataGridViewRows()
        {
            foreach (BookCategory bookCategory in _model.GetBookCategories())
            {
                foreach (Book book in bookCategory.GetBooks())
                {
                    _dataGridView1.Rows.Add(book.GetName(), bookCategory.GetCategoryName(), _model.GetBookCountByBook(book));
                }
            }
        }

        //UpdateDataGridViewRows
        private void UpdateDataGridViewRows()
        {
            this._dataGridView1.Rows.Clear();
            foreach (BookCategory bookCategory in _model.GetBookCategories())
            {
                foreach (Book book in bookCategory.GetBooks())
                {
                    _dataGridView1.Rows.Add(book.GetName(), bookCategory.GetCategoryName(), _model.GetBookCountByBook(book));
                }
            }
            int index = FindIndexByName();
            this._dataGridView1.Rows[0].Selected = false;
            this._dataGridView1.Rows[index].Selected = true;
        }

        //FindIndexByName
        public int FindIndexByName()
        {
            int rowIndex = 0;
            foreach (DataGridViewRow row in _dataGridView1.Rows)
            {
                if (_formPresentationModel.IsCurrentIndex(row.Cells[0].Value.ToString()))
                {
                    rowIndex = row.Index;
                    break;
                }
            }
            return rowIndex;
        }

        //UpdateContent
        private void UpdateContent()
        {
            _pictureBox1.BackgroundImage = Image.FromFile(_formPresentationModel.GetImage());
            _pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            _richTextBox1.Text = _formPresentationModel.GetContentText();
        }
    }
}
