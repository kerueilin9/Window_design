
namespace Homework
{
    partial class ReplenishmentForm
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
            this._replenishCount = new System.Windows.Forms.Label();
            this._richTextBox1 = new System.Windows.Forms.RichTextBox();
            this._confirm = new System.Windows.Forms.Button();
            this._cancel = new System.Windows.Forms.Button();
            this._textReplenishCount = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // _title
            // 
            this._title.AutoSize = true;
            this._title.Font = new System.Drawing.Font("微軟正黑體", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._title.Location = new System.Drawing.Point(161, 9);
            this._title.Name = "_title";
            this._title.Size = new System.Drawing.Size(142, 50);
            this._title.TabIndex = 0;
            this._title.Text = "補貨單";
            // 
            // _replenishCount
            // 
            this._replenishCount.AutoSize = true;
            this._replenishCount.Font = new System.Drawing.Font("新細明體", 14F);
            this._replenishCount.Location = new System.Drawing.Point(12, 263);
            this._replenishCount.Name = "_replenishCount";
            this._replenishCount.Size = new System.Drawing.Size(130, 24);
            this._replenishCount.TabIndex = 1;
            this._replenishCount.Text = "補貨數量：";
            // 
            // _richTextBox1
            // 
            this._richTextBox1.Location = new System.Drawing.Point(12, 66);
            this._richTextBox1.Name = "_richTextBox1";
            this._richTextBox1.Size = new System.Drawing.Size(435, 190);
            this._richTextBox1.TabIndex = 2;
            this._richTextBox1.Text = "";
            // 
            // _confirm
            // 
            this._confirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this._confirm.Font = new System.Drawing.Font("微軟正黑體", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._confirm.Location = new System.Drawing.Point(12, 306);
            this._confirm.Name = "_confirm";
            this._confirm.Size = new System.Drawing.Size(194, 48);
            this._confirm.TabIndex = 3;
            this._confirm.Text = "確認";
            this._confirm.UseVisualStyleBackColor = false;
            this._confirm.Click += new System.EventHandler(this.ConfirmClick);
            // 
            // _cancel
            // 
            this._cancel.BackColor = System.Drawing.Color.Red;
            this._cancel.Font = new System.Drawing.Font("微軟正黑體", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._cancel.Location = new System.Drawing.Point(253, 306);
            this._cancel.Name = "_cancel";
            this._cancel.Size = new System.Drawing.Size(194, 48);
            this._cancel.TabIndex = 4;
            this._cancel.Text = "取消";
            this._cancel.UseVisualStyleBackColor = false;
            this._cancel.Click += new System.EventHandler(this.CancelClick);
            // 
            // _textReplenishCount
            // 
            this._textReplenishCount.Location = new System.Drawing.Point(148, 262);
            this._textReplenishCount.Name = "_textReplenishCount";
            this._textReplenishCount.Size = new System.Drawing.Size(100, 25);
            this._textReplenishCount.TabIndex = 5;
            this._textReplenishCount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ValidKeyPress);
            // 
            // ReplenishmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 366);
            this.Controls.Add(this._textReplenishCount);
            this.Controls.Add(this._cancel);
            this.Controls.Add(this._confirm);
            this.Controls.Add(this._richTextBox1);
            this.Controls.Add(this._replenishCount);
            this.Controls.Add(this._title);
            this.Name = "ReplenishmentForm";
            this.Text = "ReplenishmentForm";
            this.Load += new System.EventHandler(this.FormLoad);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label _title;
        private System.Windows.Forms.Label _replenishCount;
        private System.Windows.Forms.RichTextBox _richTextBox1;
        private System.Windows.Forms.Button _confirm;
        private System.Windows.Forms.Button _cancel;
        private System.Windows.Forms.TextBox _textReplenishCount;
    }
}