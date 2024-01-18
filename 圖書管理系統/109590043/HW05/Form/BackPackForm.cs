using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Homework.PresentationModel;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataGridViewNumericUpDownElements;

namespace Homework
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
            this._backPackFormPresentation._showMessage += this.ShowMessage;
            this._model._updateEditedBook += this.CreateGridRow;
        }

        //BackPackForm_Load
        private void BackPackFormLoad(object sender, EventArgs e)
        {
            DataGridViewButtonColumn deleteColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            deleteColumn.HeaderText = "還書";
            deleteColumn.Name = "returnColumn";
            deleteColumn.FillWeight = 12;
            deleteColumn.Text = "歸還";
            deleteColumn.UseColumnTextForButtonValue = true;
            _dataGridView1.Columns.Insert(0, deleteColumn);
            this._dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            ((DataGridViewNumericUpDownColumn)_dataGridView1.Columns[1]).Minimum = 0;
            _dataGridView1.EditingControlShowing += EditingControlShowing;
            _dataGridView1.CellValueChanged += ChangeReturnCount;
            CreateGridRow(); 
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

        //CreateGridRow
        public void CreateGridRow()
        {
            _dataGridView1.Rows.Clear();
            foreach (string[] borrowedItem in this._backPackFormPresentation.ReturnList())
                this._dataGridView1.Rows.Add(borrowedItem);
        }

        //ChangeReturnCount
        private void ChangeReturnCount(object sender, DataGridViewCellEventArgs e)
        {
            var grid = (DataGridView)sender;
            if (e.RowIndex < 0)
                return;
            this._backPackFormPresentation.GetReturnLimitMessage(e.RowIndex, int.Parse(grid[1, e.RowIndex].Value.ToString()), int.Parse(grid[3, e.RowIndex].Value.ToString()));
        }

        //ReturnBookInBorrowList
        public void ReturnBookInBorrowList(object sender, DataGridViewCellEventArgs e)
        {
            const int INDEX = 2;
            var grid = (DataGridView)sender;
            if (e.RowIndex < 0)
                return;
            if (grid[e.ColumnIndex, e.RowIndex] is DataGridViewButtonCell)
            {
                MessageBox.Show(_backPackFormPresentation.GetMessage(grid.Rows[e.RowIndex].Cells[INDEX].Value.ToString() , grid.Rows[e.RowIndex].Cells[1].Value.ToString()));
                _model.DeleteBorrowedList(grid.Rows[e.RowIndex].Cells[INDEX].Value.ToString(), int.Parse(grid[1, e.RowIndex].Value.ToString()));
                CreateGridRow();
                _model.UpdateBookItem();
                this.UpdateBorrowingForm();
            }
        }

        //UpdateBorrowingForm
        public void UpdateBorrowingForm()
        {
            if (this._updateBorrowingForm != null)
                this._updateBorrowingForm.Invoke();
        }

        //ShowMessage
        private void ShowMessage(string content, string title, int rowIndex, int resultCount)
        {
            this._dataGridView1.EndEdit();
            MessageBox.Show(content, title);
            this._dataGridView1.Rows[rowIndex].Cells[1].Value = resultCount.ToString();
        }
    }
}
