using DataGridViewNumericUpDownElements;
using Homework.PresentationModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace Homework
{
    public partial class ReplenishmentForm : Form
    {
        private Model _model;
        private BookItem _bookItem;
        private string _content;

        public ReplenishmentForm()
        {
            InitializeComponent();
        }

        public ReplenishmentForm(Model model, BookItem bookItem, string content)
        {
            this._model = model;
            this._bookItem = bookItem;
            this._content = content;
            InitializeComponent();
        }

        private void FormLoad(object sender, EventArgs e)
        {
            this._richTextBox1.Text = this._content;
        }

        private void ConfirmClick(object sender, EventArgs e)
        {
            this._bookItem.SetPlusBookCount(int.Parse(this._textReplenishCount.Text));
            this.Close();
        }

        private void CancelClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ValidKeyPress(object sender, KeyPressEventArgs e)
        {
            int key = Convert.ToInt32(e.KeyChar);
            if (!(48 <= key && key <= 58 || key == 8))
            {
                e.Handled = true;
            }
        }
    }
}
