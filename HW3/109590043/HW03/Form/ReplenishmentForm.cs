using DataGridViewNumericUpDownElements;
using Homework.PresentationModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace Homework
{
    public partial class SupplementForm : Form
    {
        private Model _model;
        private BookItem _bookItem;
        private string _content;

        public SupplementForm()
        {
            InitializeComponent();
        }

        public SupplementForm(Model model, BookItem bookItem, string content)
        {
            this._model = model;
            this._bookItem = bookItem;
            this._content = content;
            InitializeComponent();
        }

        //FormLoad
        private void FormLoad(object sender, EventArgs e)
        {
            this._richTextBox1.Text = this._content;
        }

        //ConfirmClick
        private void ConfirmClick(object sender, EventArgs e)
        {
            this._bookItem.SetPlusBookCount(int.Parse(this._textSupplyCount.Text));
            _model.UpdateBookItem();
            this.Close();
        }

        //CancelClick
        private void CancelClick(object sender, EventArgs e)
        {
            this.Close();
        }

        //DecideKeyPress
        private void DecideKeyPress(object sender, KeyPressEventArgs e)
        {
            int key = Convert.ToInt32(e.KeyChar);
            if (!(48 <= key && key <= 58 || key == 8))
            {
                e.Handled = true;
            }
        }
    }
}
