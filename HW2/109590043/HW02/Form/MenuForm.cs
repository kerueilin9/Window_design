using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Homework02
{
    public partial class MenuForm : Form
    {
        private Model _model;
        private Form _bookBorrowingForm;
        private Form _bookInventoryForm;
        public MenuForm(Model model)
        {
            this._model = model;
            this._bookBorrowingForm = new BookBorrowingForm(_model);
            this._bookInventoryForm = new BookInventoryForm(_model);
            this._bookBorrowingForm.FormClosing += new FormClosingEventHandler(BookBorrowingFormFormClosing);
            this._bookInventoryForm.FormClosing += new FormClosingEventHandler(BookInventoryFormFormClosing);
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
    }
}
