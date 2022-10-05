
namespace Homework02
{
    partial class BookBorrowingForm
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this._groupBox1 = new System.Windows.Forms.GroupBox();
            this._page = new System.Windows.Forms.Label();
            this._nextPage = new System.Windows.Forms.Button();
            this._previousPage = new System.Windows.Forms.Button();
            this._addBook = new System.Windows.Forms.Button();
            this._restCount = new System.Windows.Forms.Label();
            this._label1 = new System.Windows.Forms.Label();
            this._richTextBox1 = new System.Windows.Forms.RichTextBox();
            this._tabControl1 = new System.Windows.Forms.TabControl();
            this._label3 = new System.Windows.Forms.Label();
            this._dataGridView1 = new System.Windows.Forms.DataGridView();
            this._borrowBookCount = new System.Windows.Forms.Label();
            this._confirm = new System.Windows.Forms.Button();
            this._viewBag = new System.Windows.Forms.Button();
            this._groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // _groupBox1
            // 
            this._groupBox1.Controls.Add(this._page);
            this._groupBox1.Controls.Add(this._nextPage);
            this._groupBox1.Controls.Add(this._previousPage);
            this._groupBox1.Controls.Add(this._addBook);
            this._groupBox1.Controls.Add(this._restCount);
            this._groupBox1.Controls.Add(this._label1);
            this._groupBox1.Controls.Add(this._richTextBox1);
            this._groupBox1.Controls.Add(this._tabControl1);
            this._groupBox1.Location = new System.Drawing.Point(12, 12);
            this._groupBox1.Name = "_groupBox1";
            this._groupBox1.Size = new System.Drawing.Size(363, 429);
            this._groupBox1.TabIndex = 0;
            this._groupBox1.TabStop = false;
            this._groupBox1.Text = "書籍";
            // 
            // _page
            // 
            this._page.AutoSize = true;
            this._page.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._page.Location = new System.Drawing.Point(2, 396);
            this._page.Name = "_page";
            this._page.Size = new System.Drawing.Size(69, 20);
            this._page.TabIndex = 6;
            this._page.Text = "Page：";
            // 
            // _nextPage
            // 
            this._nextPage.Location = new System.Drawing.Point(188, 391);
            this._nextPage.Name = "_nextPage";
            this._nextPage.Size = new System.Drawing.Size(65, 30);
            this._nextPage.TabIndex = 5;
            this._nextPage.Text = "下一頁";
            this._nextPage.UseVisualStyleBackColor = true;
            // 
            // _previousPage
            // 
            this._previousPage.Location = new System.Drawing.Point(117, 391);
            this._previousPage.Name = "_previousPage";
            this._previousPage.Size = new System.Drawing.Size(65, 30);
            this._previousPage.TabIndex = 4;
            this._previousPage.Text = "上一頁";
            this._previousPage.UseVisualStyleBackColor = true;
            // 
            // _addBook
            // 
            this._addBook.Location = new System.Drawing.Point(259, 391);
            this._addBook.Name = "_addBook";
            this._addBook.Size = new System.Drawing.Size(98, 30);
            this._addBook.TabIndex = 3;
            this._addBook.Text = "加入借書單";
            this._addBook.UseVisualStyleBackColor = true;
            this._addBook.Click += new System.EventHandler(this.AddBookClick);
            // 
            // _restCount
            // 
            this._restCount.AutoSize = true;
            this._restCount.Location = new System.Drawing.Point(7, 361);
            this._restCount.Name = "_restCount";
            this._restCount.Size = new System.Drawing.Size(82, 15);
            this._restCount.TabIndex = 3;
            this._restCount.Text = "剩餘數量：";
            // 
            // _label1
            // 
            this._label1.AutoSize = true;
            this._label1.Location = new System.Drawing.Point(7, 204);
            this._label1.Name = "_label1";
            this._label1.Size = new System.Drawing.Size(67, 15);
            this._label1.TabIndex = 2;
            this._label1.Text = "書籍介紹";
            this._label1.Visible = false;
            // 
            // _richTextBox1
            // 
            this._richTextBox1.Location = new System.Drawing.Point(10, 222);
            this._richTextBox1.Name = "_richTextBox1";
            this._richTextBox1.Size = new System.Drawing.Size(347, 136);
            this._richTextBox1.TabIndex = 1;
            this._richTextBox1.Text = "";
            // 
            // _tabControl1
            // 
            this._tabControl1.Location = new System.Drawing.Point(6, 24);
            this._tabControl1.Name = "_tabControl1";
            this._tabControl1.SelectedIndex = 0;
            this._tabControl1.Size = new System.Drawing.Size(351, 165);
            this._tabControl1.TabIndex = 0;
            // 
            // _label3
            // 
            this._label3.Font = new System.Drawing.Font("新細明體", 22F);
            this._label3.Location = new System.Drawing.Point(591, 9);
            this._label3.Name = "_label3";
            this._label3.Size = new System.Drawing.Size(132, 46);
            this._label3.TabIndex = 4;
            this._label3.Text = "借書單";
            // 
            // _dataGridView1
            // 
            this._dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dataGridView1.Location = new System.Drawing.Point(381, 58);
            this._dataGridView1.Name = "_dataGridView1";
            this._dataGridView1.RowHeadersWidth = 51;
            this._dataGridView1.RowTemplate.Height = 27;
            this._dataGridView1.Size = new System.Drawing.Size(553, 330);
            this._dataGridView1.TabIndex = 5;
            // 
            // _borrowBookCount
            // 
            this._borrowBookCount.Font = new System.Drawing.Font("新細明體", 18F);
            this._borrowBookCount.Location = new System.Drawing.Point(381, 395);
            this._borrowBookCount.Name = "_borrowBookCount";
            this._borrowBookCount.Size = new System.Drawing.Size(244, 46);
            this._borrowBookCount.TabIndex = 6;
            this._borrowBookCount.Text = "借書數量：";
            // 
            // _confirm
            // 
            this._confirm.Location = new System.Drawing.Point(848, 400);
            this._confirm.Name = "_confirm";
            this._confirm.Size = new System.Drawing.Size(86, 38);
            this._confirm.TabIndex = 4;
            this._confirm.Text = "確認借書";
            this._confirm.UseVisualStyleBackColor = true;
            this._confirm.Click += new System.EventHandler(this.ConfirmClick);
            // 
            // _viewBag
            // 
            this._viewBag.Location = new System.Drawing.Point(724, 400);
            this._viewBag.Name = "_viewBag";
            this._viewBag.Size = new System.Drawing.Size(118, 38);
            this._viewBag.TabIndex = 7;
            this._viewBag.Text = "查看我的書包";
            this._viewBag.UseVisualStyleBackColor = true;
            // 
            // BookBorrowingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(946, 450);
            this.Controls.Add(this._viewBag);
            this.Controls.Add(this._confirm);
            this.Controls.Add(this._borrowBookCount);
            this.Controls.Add(this._dataGridView1);
            this.Controls.Add(this._label3);
            this.Controls.Add(this._groupBox1);
            this.Name = "BookBorrowingForm";
            this.Text = "借書";
            this.Load += new System.EventHandler(this.Form1Load);
            this._groupBox1.ResumeLayout(false);
            this._groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox _groupBox1;
        private System.Windows.Forms.Button _addBook;
        private System.Windows.Forms.Label _restCount;
        private System.Windows.Forms.Label _label1;
        private System.Windows.Forms.RichTextBox _richTextBox1;
        private System.Windows.Forms.Label _label3;
        private System.Windows.Forms.DataGridView _dataGridView1;
        private System.Windows.Forms.Label _borrowBookCount;
        private System.Windows.Forms.Button _confirm;
        private System.Windows.Forms.Label _page;
        private System.Windows.Forms.Button _nextPage;
        private System.Windows.Forms.Button _previousPage;
        private System.Windows.Forms.Button _viewBag;
        private System.Windows.Forms.TabControl _tabControl1;
    }
}

