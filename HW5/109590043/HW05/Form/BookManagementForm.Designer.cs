
namespace Homework
{
    partial class BookManagementForm
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
            this._bookList = new System.Windows.Forms.ListBox();
            this._addBookButton = new System.Windows.Forms.Button();
            this._title = new System.Windows.Forms.Label();
            this._groupBox = new System.Windows.Forms.GroupBox();
            this._categoryComboBox = new System.Windows.Forms.ComboBox();
            this._browse = new System.Windows.Forms.Button();
            this._fileTextBox = new System.Windows.Forms.TextBox();
            this._publisherTextBox = new System.Windows.Forms.TextBox();
            this._authorTextBox = new System.Windows.Forms.TextBox();
            this._idTextBox = new System.Windows.Forms.TextBox();
            this._nameTextBox = new System.Windows.Forms.TextBox();
            this._file = new System.Windows.Forms.Label();
            this._publisher = new System.Windows.Forms.Label();
            this._category = new System.Windows.Forms.Label();
            this._author = new System.Windows.Forms.Label();
            this._id = new System.Windows.Forms.Label();
            this._name = new System.Windows.Forms.Label();
            this._save = new System.Windows.Forms.Button();
            this._groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // _bookList
            // 
            this._bookList.AllowDrop = true;
            this._bookList.FormattingEnabled = true;
            this._bookList.HorizontalScrollbar = true;
            this._bookList.ItemHeight = 15;
            this._bookList.Location = new System.Drawing.Point(12, 10);
            this._bookList.Name = "_bookList";
            this._bookList.Size = new System.Drawing.Size(229, 454);
            this._bookList.TabIndex = 0;
            this._bookList.SelectedIndexChanged += new System.EventHandler(this.SelectedIndexChanged);
            // 
            // _addBookButton
            // 
            this._addBookButton.Font = new System.Drawing.Font("新細明體", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._addBookButton.Location = new System.Drawing.Point(12, 483);
            this._addBookButton.Name = "_addBookButton";
            this._addBookButton.Size = new System.Drawing.Size(229, 32);
            this._addBookButton.TabIndex = 1;
            this._addBookButton.Text = "新增書籍";
            this._addBookButton.UseVisualStyleBackColor = true;
            // 
            // _title
            // 
            this._title.AutoSize = true;
            this._title.Font = new System.Drawing.Font("微軟正黑體", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._title.Location = new System.Drawing.Point(247, 10);
            this._title.Name = "_title";
            this._title.Size = new System.Drawing.Size(315, 61);
            this._title.TabIndex = 2;
            this._title.Text = "館藏管理系統";
            // 
            // _groupBox
            // 
            this._groupBox.Controls.Add(this._categoryComboBox);
            this._groupBox.Controls.Add(this._browse);
            this._groupBox.Controls.Add(this._fileTextBox);
            this._groupBox.Controls.Add(this._publisherTextBox);
            this._groupBox.Controls.Add(this._authorTextBox);
            this._groupBox.Controls.Add(this._idTextBox);
            this._groupBox.Controls.Add(this._nameTextBox);
            this._groupBox.Controls.Add(this._file);
            this._groupBox.Controls.Add(this._publisher);
            this._groupBox.Controls.Add(this._category);
            this._groupBox.Controls.Add(this._author);
            this._groupBox.Controls.Add(this._id);
            this._groupBox.Controls.Add(this._name);
            this._groupBox.Font = new System.Drawing.Font("標楷體", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._groupBox.Location = new System.Drawing.Point(258, 85);
            this._groupBox.Name = "_groupBox";
            this._groupBox.Size = new System.Drawing.Size(530, 379);
            this._groupBox.TabIndex = 3;
            this._groupBox.TabStop = false;
            this._groupBox.Text = "編輯書籍";
            // 
            // _categoryComboBox
            // 
            this._categoryComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._categoryComboBox.Enabled = false;
            this._categoryComboBox.Font = new System.Drawing.Font("新細明體", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._categoryComboBox.FormattingEnabled = true;
            this._categoryComboBox.Location = new System.Drawing.Point(151, 205);
            this._categoryComboBox.Name = "_categoryComboBox";
            this._categoryComboBox.Size = new System.Drawing.Size(267, 26);
            this._categoryComboBox.TabIndex = 11;
            this._categoryComboBox.SelectedIndexChanged += new System.EventHandler(this.ChangeCategoryComboBoxSelectedIndex);
            // 
            // _browse
            // 
            this._browse.Font = new System.Drawing.Font("新細明體", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._browse.Location = new System.Drawing.Point(424, 314);
            this._browse.Name = "_browse";
            this._browse.Size = new System.Drawing.Size(100, 32);
            this._browse.TabIndex = 4;
            this._browse.Text = "瀏覽";
            this._browse.UseVisualStyleBackColor = true;
            this._browse.Click += new System.EventHandler(this.ClickBrowse);
            // 
            // _fileTextBox
            // 
            this._fileTextBox.Enabled = false;
            this._fileTextBox.Font = new System.Drawing.Font("新細明體-ExtB", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._fileTextBox.Location = new System.Drawing.Point(150, 315);
            this._fileTextBox.Name = "_fileTextBox";
            this._fileTextBox.Size = new System.Drawing.Size(268, 29);
            this._fileTextBox.TabIndex = 10;
            this._fileTextBox.TextChanged += new System.EventHandler(this.ChangeFileTextBoxText);
            // 
            // _publisherTextBox
            // 
            this._publisherTextBox.Enabled = false;
            this._publisherTextBox.Font = new System.Drawing.Font("新細明體-ExtB", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._publisherTextBox.Location = new System.Drawing.Point(150, 260);
            this._publisherTextBox.Name = "_publisherTextBox";
            this._publisherTextBox.Size = new System.Drawing.Size(374, 29);
            this._publisherTextBox.TabIndex = 9;
            this._publisherTextBox.TextChanged += new System.EventHandler(this.ChangePublisherTextBoxText);
            // 
            // _authorTextBox
            // 
            this._authorTextBox.Enabled = false;
            this._authorTextBox.Font = new System.Drawing.Font("新細明體", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._authorTextBox.Location = new System.Drawing.Point(150, 150);
            this._authorTextBox.Name = "_authorTextBox";
            this._authorTextBox.Size = new System.Drawing.Size(268, 29);
            this._authorTextBox.TabIndex = 8;
            this._authorTextBox.TextChanged += new System.EventHandler(this.ChangeAuthorTextBoxText);
            // 
            // _idTextBox
            // 
            this._idTextBox.Enabled = false;
            this._idTextBox.Font = new System.Drawing.Font("新細明體", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._idTextBox.Location = new System.Drawing.Point(150, 95);
            this._idTextBox.Name = "_idTextBox";
            this._idTextBox.Size = new System.Drawing.Size(268, 29);
            this._idTextBox.TabIndex = 7;
            this._idTextBox.TextChanged += new System.EventHandler(this.ChangeIdTextBoxTextChange);
            // 
            // _nameTextBox
            // 
            this._nameTextBox.Enabled = false;
            this._nameTextBox.Font = new System.Drawing.Font("新細明體", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._nameTextBox.Location = new System.Drawing.Point(150, 40);
            this._nameTextBox.Name = "_nameTextBox";
            this._nameTextBox.Size = new System.Drawing.Size(374, 29);
            this._nameTextBox.TabIndex = 6;
            this._nameTextBox.TextChanged += new System.EventHandler(this.ChangeNameTextBoxText);
            // 
            // _file
            // 
            this._file.AutoSize = true;
            this._file.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._file.Location = new System.Drawing.Point(31, 315);
            this._file.Name = "_file";
            this._file.Size = new System.Drawing.Size(113, 25);
            this._file.TabIndex = 5;
            this._file.Text = "圖片路徑(*)";
            // 
            // _publisher
            // 
            this._publisher.AutoSize = true;
            this._publisher.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._publisher.Location = new System.Drawing.Point(31, 260);
            this._publisher.Name = "_publisher";
            this._publisher.Size = new System.Drawing.Size(93, 25);
            this._publisher.TabIndex = 4;
            this._publisher.Text = "出版社(*)";
            // 
            // _category
            // 
            this._category.AutoSize = true;
            this._category.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._category.Location = new System.Drawing.Point(31, 205);
            this._category.Name = "_category";
            this._category.Size = new System.Drawing.Size(113, 25);
            this._category.TabIndex = 3;
            this._category.Text = "書籍類別(*)";
            // 
            // _author
            // 
            this._author.AutoSize = true;
            this._author.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._author.Location = new System.Drawing.Point(31, 150);
            this._author.Name = "_author";
            this._author.Size = new System.Drawing.Size(113, 25);
            this._author.TabIndex = 2;
            this._author.Text = "書籍作者(*)";
            // 
            // _id
            // 
            this._id.AutoSize = true;
            this._id.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._id.Location = new System.Drawing.Point(31, 95);
            this._id.Name = "_id";
            this._id.Size = new System.Drawing.Size(113, 25);
            this._id.TabIndex = 1;
            this._id.Text = "書籍編號(*)";
            // 
            // _name
            // 
            this._name.AutoSize = true;
            this._name.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._name.Location = new System.Drawing.Point(31, 40);
            this._name.Name = "_name";
            this._name.Size = new System.Drawing.Size(113, 25);
            this._name.TabIndex = 0;
            this._name.Text = "書籍名稱(*)";
            // 
            // _save
            // 
            this._save.Font = new System.Drawing.Font("新細明體", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._save.Location = new System.Drawing.Point(581, 483);
            this._save.Name = "_save";
            this._save.Size = new System.Drawing.Size(207, 32);
            this._save.TabIndex = 4;
            this._save.Text = "儲存";
            this._save.UseVisualStyleBackColor = true;
            this._save.Click += new System.EventHandler(this.ClickSave);
            // 
            // BookManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 527);
            this.Controls.Add(this._save);
            this.Controls.Add(this._groupBox);
            this.Controls.Add(this._title);
            this.Controls.Add(this._addBookButton);
            this.Controls.Add(this._bookList);
            this.Name = "BookManagementForm";
            this.Text = "BookManagementForm";
            this.Load += new System.EventHandler(this.FormLoad);
            this._groupBox.ResumeLayout(false);
            this._groupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox _bookList;
        private System.Windows.Forms.Button _addBookButton;
        private System.Windows.Forms.Label _title;
        private System.Windows.Forms.GroupBox _groupBox;
        private System.Windows.Forms.Label _name;
        private System.Windows.Forms.ComboBox _categoryComboBox;
        private System.Windows.Forms.Button _browse;
        private System.Windows.Forms.TextBox _fileTextBox;
        private System.Windows.Forms.TextBox _publisherTextBox;
        private System.Windows.Forms.TextBox _authorTextBox;
        private System.Windows.Forms.TextBox _idTextBox;
        private System.Windows.Forms.TextBox _nameTextBox;
        private System.Windows.Forms.Label _file;
        private System.Windows.Forms.Label _publisher;
        private System.Windows.Forms.Label _category;
        private System.Windows.Forms.Label _author;
        private System.Windows.Forms.Label _id;
        private System.Windows.Forms.Button _save;
    }
}