using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Homework02.PresentationModel;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Homework02
{
    public partial class BackPackForm : Form
    {
        public event Action _updateBorrowingForm;
        private Model _model;
        private BackPackFormPresentationModel _backPackFormPresentation;

        public BackPackForm(Model model)
        {
            InitializeComponent();
            this._model = model;
            this._backPackFormPresentation = new BackPackFormPresentationModel(_model);
        }

        //BackPackForm_Load
        private void BackPackFormLoad(object sender, EventArgs e)
        {
            DataGridViewButtonColumn deleteColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            deleteColumn.HeaderText = "還書";
            deleteColumn.Name = "returnColumn";
            deleteColumn.FillWeight = 10;
            deleteColumn.Text = "歸還";
            deleteColumn.UseColumnTextForButtonValue = true;
            _dataGridView1.Columns.Insert(0, deleteColumn);
            _dataGridView1.AllowUserToAddRows = false;
            _dataGridView1.RowHeadersVisible = false;
            _dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            _dataGridView1.CellClick += new DataGridViewCellEventHandler(ReturnBookInBorrowList);
            CreateGridRow();
        }

        //CreateGridRow
        public void CreateGridRow()
        {
            _dataGridView1.Rows.Clear();
            foreach (string[] borrowedItem in this._backPackFormPresentation.ReturnList())
                this._dataGridView1.Rows.Add(borrowedItem);
        }

        //ReturnBookInBorrowList
        public void ReturnBookInBorrowList(object sender, DataGridViewCellEventArgs e)
        {
            const string UPPER_BRACKET = "【";
            const string LAST_STRING = "】 已成功歸還";
            var grid = (DataGridView)sender;
            if (e.RowIndex < 0)
                return;
            if (grid[e.ColumnIndex, e.RowIndex] is DataGridViewButtonCell)
            {
                MessageBox.Show(UPPER_BRACKET + grid.Rows[e.RowIndex].Cells[1].Value.ToString() + LAST_STRING);
                _model.DeleteBorrowedList(grid.Rows[e.RowIndex].Cells[1].Value.ToString());
                _dataGridView1.Rows.RemoveAt(e.RowIndex);
                this.UpdateBorrowingForm();
            }
        }

        //UpdateBorrowingForm
        public void UpdateBorrowingForm()
        {
            if (this._updateBorrowingForm != null)
                this._updateBorrowingForm.Invoke();
        }
    }
}
