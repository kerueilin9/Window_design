using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Homework
{
    public partial class MenuForm : Form
    {
        private Model _model;
        private Form _bookBorrowingForm;
        private Form _bookInventoryForm;
        private Form _bookManagementForm;
        public MenuForm(Model model)
        {
            this._model = model;
            this._bookBorrowingForm = new BookBorrowingForm(_model);
            this._bookInventoryForm = new BookInventoryForm(_model);
            this._bookManagementForm = new BookManagementForm(_model);
            this._bookBorrowingForm.FormClosing += new FormClosingEventHandler(BookBorrowingFormFormClosing);
            this._bookInventoryForm.FormClosing += new FormClosingEventHandler(BookInventoryFormFormClosing);
            this._bookManagementForm.FormClosing += new FormClosingEventHandler(BookManagementFormFormClosing);
            InitializeComponent();
        }

        //Form2_Load
        private void Form2Load(object sender, EventArgs e)
        {

        }

        //BookBorrowingSystemClick
        private void BookBorrowingSystemClick(object sender, EventArgs e)
        {
            _bookBorrowingForm.Show();
            this._bookBorrowingSystem.Enabled = false;
        }

        //BookInventorySystemClick
        private void BookInventorySystemClick(object sender, EventArgs e)
        {
            _bookInventoryForm.Show();
            this._bookInventorySystem.Enabled = false;
        }

        //_bookManagementSystem_Click
        private void BookManagementSystemClick(object sender, EventArgs e)
        {
            _bookManagementForm.Show();
            this._bookManagementSystem.Enabled = false;
        }

        //ExitClick
        private void ExitClick(object sender, EventArgs e)
        {
            this.Close();
        }

        //BookBorrowingFormFormClosing
        private void BookBorrowingFormFormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                _bookBorrowingForm.Hide();
                this._bookBorrowingSystem.Enabled = true;
            }
        }

        //BookInventoryFormFormClosing
        private void BookInventoryFormFormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                _bookInventoryForm.Hide();
                this._bookInventorySystem.Enabled = true;
            }
        }

        //BookManagementFormFormClosing
        private void BookManagementFormFormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                _bookManagementForm.Hide();
                this._bookManagementSystem.Enabled = true;
            }
        }
    }
}
