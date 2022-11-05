
namespace Homework
{
    partial class BackPackForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._dataGridView1 = new System.Windows.Forms.DataGridView();
            this._returnCount = new DataGridViewNumericUpDownElements.DataGridViewNumericUpDownColumn();
            this._name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._borrowedCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._borrowingDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._returnDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._author = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._publisher = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this._dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // _dataGridView1
            // 
            this._dataGridView1.AllowUserToAddRows = false;
            this._dataGridView1.AllowUserToResizeColumns = false;
            this._dataGridView1.AllowUserToResizeRows = false;
            this._dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._returnCount,
            this._name,
            this._borrowedCount,
            this._borrowingDate,
            this._returnDate,
            this._id,
            this._author,
            this._publisher});
            this._dataGridView1.Location = new System.Drawing.Point(12, 12);
            this._dataGridView1.Name = "_dataGridView1";
            this._dataGridView1.RowHeadersVisible = false;
            this._dataGridView1.RowHeadersWidth = 51;
            this._dataGridView1.RowTemplate.Height = 27;
            this._dataGridView1.Size = new System.Drawing.Size(920, 426);
            this._dataGridView1.TabIndex = 0;
            this._dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ReturnBookInBorrowList);
            // 
            // _returnCount
            // 
            this._returnCount.FillWeight = 20F;
            this._returnCount.HeaderText = "歸還數量";
            this._returnCount.MinimumWidth = 6;
            this._returnCount.Name = "_returnCount";
            this._returnCount.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this._returnCount.Width = 50;
            // 
            // _name
            // 
            this._name.FillWeight = 30F;
            this._name.HeaderText = "書籍名稱";
            this._name.MinimumWidth = 6;
            this._name.Name = "_name";
            this._name.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this._name.Width = 180;
            // 
            // _borrowedCount
            // 
            this._borrowedCount.FillWeight = 20F;
            this._borrowedCount.HeaderText = "已借數量";
            this._borrowedCount.MinimumWidth = 6;
            this._borrowedCount.Name = "_borrowedCount";
            this._borrowedCount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this._borrowedCount.Width = 125;
            // 
            // _borrowingDate
            // 
            this._borrowingDate.FillWeight = 20F;
            this._borrowingDate.HeaderText = "借書日期";
            this._borrowingDate.MinimumWidth = 6;
            this._borrowingDate.Name = "_borrowingDate";
            this._borrowingDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this._borrowingDate.Width = 125;
            // 
            // _returnDate
            // 
            this._returnDate.FillWeight = 20F;
            this._returnDate.HeaderText = "還書期限";
            this._returnDate.MinimumWidth = 6;
            this._returnDate.Name = "_returnDate";
            this._returnDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this._returnDate.Width = 125;
            // 
            // _id
            // 
            this._id.FillWeight = 25F;
            this._id.HeaderText = "書籍編號";
            this._id.MinimumWidth = 6;
            this._id.Name = "_id";
            this._id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this._id.Width = 125;
            // 
            // _author
            // 
            this._author.FillWeight = 25F;
            this._author.HeaderText = "作者";
            this._author.MinimumWidth = 6;
            this._author.Name = "_author";
            this._author.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this._author.Width = 125;
            // 
            // _publisher
            // 
            this._publisher.FillWeight = 25F;
            this._publisher.HeaderText = "出版社";
            this._publisher.MinimumWidth = 6;
            this._publisher.Name = "_publisher";
            this._publisher.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this._publisher.Width = 125;
            // 
            // BackPackForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 450);
            this.Controls.Add(this._dataGridView1);
            this.Name = "BackPackForm";
            this.Text = "我的書包(還書)";
            this.Load += new System.EventHandler(this.BackPackFormLoad);
            ((System.ComponentModel.ISupportInitialize)(this._dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView _dataGridView1;
        private DataGridViewNumericUpDownElements.DataGridViewNumericUpDownColumn _returnCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn _name;
        private System.Windows.Forms.DataGridViewTextBoxColumn _borrowedCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn _borrowingDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn _returnDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn _id;
        private System.Windows.Forms.DataGridViewTextBoxColumn _author;
        private System.Windows.Forms.DataGridViewTextBoxColumn _publisher;
    }
}