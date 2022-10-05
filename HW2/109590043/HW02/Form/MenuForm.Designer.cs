
namespace Homework02
{
    partial class MenuForm
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
            this._bookBorrowingSystem = new System.Windows.Forms.Button();
            this._bookInventorySystem = new System.Windows.Forms.Button();
            this._exit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _bookBorrowingSystem
            // 
            this._bookBorrowingSystem.Font = new System.Drawing.Font("微軟正黑體", 25F, System.Drawing.FontStyle.Bold);
            this._bookBorrowingSystem.Location = new System.Drawing.Point(12, 12);
            this._bookBorrowingSystem.Name = "_bookBorrowingSystem";
            this._bookBorrowingSystem.Size = new System.Drawing.Size(776, 163);
            this._bookBorrowingSystem.TabIndex = 0;
            this._bookBorrowingSystem.Text = "Book Borrowing System";
            this._bookBorrowingSystem.UseVisualStyleBackColor = true;
            this._bookBorrowingSystem.Click += new System.EventHandler(this._bookBorrowingSystem_Click);
            // 
            // _bookInventorySystem
            // 
            this._bookInventorySystem.Font = new System.Drawing.Font("微軟正黑體", 25.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._bookInventorySystem.Location = new System.Drawing.Point(12, 181);
            this._bookInventorySystem.Name = "_bookInventorySystem";
            this._bookInventorySystem.Size = new System.Drawing.Size(776, 163);
            this._bookInventorySystem.TabIndex = 1;
            this._bookInventorySystem.Text = "Book Inventory System";
            this._bookInventorySystem.UseVisualStyleBackColor = true;
            this._bookInventorySystem.Click += new System.EventHandler(this._bookInventorySystem_Click);
            // 
            // _exit
            // 
            this._exit.Font = new System.Drawing.Font("微軟正黑體", 16F, System.Drawing.FontStyle.Bold);
            this._exit.Location = new System.Drawing.Point(656, 366);
            this._exit.Name = "_exit";
            this._exit.Size = new System.Drawing.Size(132, 52);
            this._exit.TabIndex = 2;
            this._exit.Text = "Exit ";
            this._exit.UseVisualStyleBackColor = true;
            this._exit.Click += new System.EventHandler(this._exit_Click);
            // 
            // MenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 430);
            this.Controls.Add(this._exit);
            this.Controls.Add(this._bookInventorySystem);
            this.Controls.Add(this._bookBorrowingSystem);
            this.Name = "MenuForm";
            this.Text = "Menu";
            this.Load += new System.EventHandler(this.Form2Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button _bookBorrowingSystem;
        private System.Windows.Forms.Button _bookInventorySystem;
        private System.Windows.Forms.Button _exit;
    }
}