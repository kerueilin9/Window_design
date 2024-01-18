
namespace Homework
{
    partial class BookInventoryForm
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
            this._title = new System.Windows.Forms.Label();
            this._dataGridView1 = new System.Windows.Forms.DataGridView();
            this._name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._category = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._image = new System.Windows.Forms.Label();
            this._content = new System.Windows.Forms.Label();
            this._richTextBox1 = new System.Windows.Forms.RichTextBox();
            this._pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this._dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // _title
            // 
            this._title.AutoSize = true;
            this._title.Font = new System.Drawing.Font("微軟正黑體", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._title.Location = new System.Drawing.Point(205, 9);
            this._title.Name = "_title";
            this._title.Size = new System.Drawing.Size(411, 61);
            this._title.TabIndex = 0;
            this._title.Text = "書籍庫存管理系統";
            // 
            // _dataGridView1
            // 
            this._dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._name,
            this._category,
            this._count});
            this._dataGridView1.Location = new System.Drawing.Point(12, 73);
            this._dataGridView1.Name = "_dataGridView1";
            this._dataGridView1.RowHeadersWidth = 51;
            this._dataGridView1.RowTemplate.Height = 27;
            this._dataGridView1.Size = new System.Drawing.Size(457, 365);
            this._dataGridView1.TabIndex = 1;
            this._dataGridView1.AllowUserToAddRows = false;
            this._dataGridView1.RowHeadersVisible = false;
            this._dataGridView1.AllowUserToResizeColumns = false;
            this._dataGridView1.AllowUserToResizeRows = false;
            this._dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ShowContentCellClick);
            this._dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.SupplyBook);
            this._dataGridView1.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(SetDataGridViewCellPainting);
            // 
            // _name
            // 
            this._name.FillWeight = 40F;
            this._name.HeaderText = "書籍名稱";
            this._name.MinimumWidth = 6;
            this._name.Name = "_name";
            this._name.Width = 125;
            // 
            // _category
            // 
            this._category.FillWeight = 30F;
            this._category.HeaderText = "書籍類別";
            this._category.MinimumWidth = 6;
            this._category.Name = "_category";
            this._category.Width = 125;
            // 
            // _count
            // 
            this._count.FillWeight = 20F;
            this._count.HeaderText = "數量";
            this._count.MinimumWidth = 6;
            this._count.Name = "_count";
            this._count.Width = 125;
            // 
            // _image
            // 
            this._image.AutoSize = true;
            this._image.Location = new System.Drawing.Point(496, 74);
            this._image.Name = "_image";
            this._image.Size = new System.Drawing.Size(67, 15);
            this._image.TabIndex = 2;
            this._image.Text = "書籍圖片";
            // 
            // _content
            // 
            this._content.AutoSize = true;
            this._content.Location = new System.Drawing.Point(496, 224);
            this._content.Name = "_content";
            this._content.Size = new System.Drawing.Size(67, 15);
            this._content.TabIndex = 3;
            this._content.Text = "書籍資訊";
            // 
            // _richTextBox1
            // 
            this._richTextBox1.Location = new System.Drawing.Point(479, 243);
            this._richTextBox1.Name = "_richTextBox1";
            this._richTextBox1.Size = new System.Drawing.Size(309, 195);
            this._richTextBox1.TabIndex = 4;
            this._richTextBox1.Text = "";
            // 
            // _pictureBox1
            // 
            this._pictureBox1.Location = new System.Drawing.Point(499, 92);
            this._pictureBox1.Name = "_pictureBox1";
            this._pictureBox1.Size = new System.Drawing.Size(128, 129);
            this._pictureBox1.TabIndex = 5;
            this._pictureBox1.TabStop = false;
            // 
            // BookInventoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this._pictureBox1);
            this.Controls.Add(this._richTextBox1);
            this.Controls.Add(this._content);
            this.Controls.Add(this._image);
            this.Controls.Add(this._dataGridView1);
            this.Controls.Add(this._title);
            this.Name = "BookInventoryForm";
            this.Text = "書籍庫存";
            this.Load += new System.EventHandler(this.BookInventoryFormLoad);
            ((System.ComponentModel.ISupportInitialize)(this._dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label _title;
        private System.Windows.Forms.DataGridView _dataGridView1;
        private System.Windows.Forms.Label _image;
        private System.Windows.Forms.Label _content;
        private System.Windows.Forms.RichTextBox _richTextBox1;
        private System.Windows.Forms.PictureBox _pictureBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn _name;
        private System.Windows.Forms.DataGridViewTextBoxColumn _category;
        private System.Windows.Forms.DataGridViewTextBoxColumn _count;
    }
}