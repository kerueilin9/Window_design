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
    public partial class BookInventoryForm : Form
    {
        private Model _model;
        public BookInventoryForm(Model model)
        {
            this._model = model;
            InitializeComponent();
        }

        //BookInventoryForm_Load
        private void BookInventoryFormLoad(object sender, EventArgs e)
        {

        }
    }
}
