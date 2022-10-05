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
        public MenuForm(Model model)
        {
            this._model = model;
            InitializeComponent();
        }

        //Form2_Load
        private void Form2Load(object sender, EventArgs e)
        {

        }

        private void _bookBorrowingSystem_Click(object sender, EventArgs e)
        {
            Form form = new BookBorrowingForm(_model);
            form.Show();
        }

        private void _bookInventorySystem_Click(object sender, EventArgs e)
        {
            Form form = new BookInventoryForm(_model);
            form.Show();
        }

        private void _exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
