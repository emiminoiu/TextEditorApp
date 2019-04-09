namespace TextEditor
{
    partial class FindForm
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnFind = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.lblFind = new System.Windows.Forms.Label();
            this.btnReplace = new System.Windows.Forms.Button();
            this.btnReplaceAll = new System.Windows.Forms.Button();
            this.chkReplace = new System.Windows.Forms.CheckBox();
            this.txtReplace = new System.Windows.Forms.TextBox();
            this.lblReplace = new System.Windows.Forms.Label();
            this.lblAnd = new System.Windows.Forms.Label();
            this.btnColor = new System.Windows.Forms.Button();
            this.btnFont = new System.Windows.Forms.Button();
            this.btnForeColor = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox1.Location = new System.Drawing.Point(176, 44);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(453, 32);
            this.textBox1.TabIndex = 1;
            // 
            // btnFind
            // 
            this.btnFind.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnFind.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnFind.ForeColor = System.Drawing.Color.Black;
            this.btnFind.Location = new System.Drawing.Point(704, 12);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(148, 50);
            this.btnFind.TabIndex = 2;
            this.btnFind.Text = "Find";
            this.btnFind.UseVisualStyleBackColor = false;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnClose.ForeColor = System.Drawing.Color.Black;
            this.btnClose.Location = new System.Drawing.Point(704, 316);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(148, 50);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(704, 81);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(148, 50);
            this.button1.TabIndex = 4;
            this.button1.Text = "FindAll";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblFind
            // 
            this.lblFind.AutoSize = true;
            this.lblFind.Location = new System.Drawing.Point(57, 56);
            this.lblFind.Name = "lblFind";
            this.lblFind.Size = new System.Drawing.Size(40, 20);
            this.lblFind.TabIndex = 5;
            this.lblFind.Text = "Find";
            this.lblFind.Click += new System.EventHandler(this.lblFind_Click);
            // 
            // btnReplace
            // 
            this.btnReplace.Location = new System.Drawing.Point(704, 168);
            this.btnReplace.Name = "btnReplace";
            this.btnReplace.Size = new System.Drawing.Size(148, 46);
            this.btnReplace.TabIndex = 6;
            this.btnReplace.Text = "Replace";
            this.btnReplace.UseVisualStyleBackColor = true;
            this.btnReplace.Visible = false;
            this.btnReplace.Click += new System.EventHandler(this.btnReplace_Click);
            // 
            // btnReplaceAll
            // 
            this.btnReplaceAll.Location = new System.Drawing.Point(704, 242);
            this.btnReplaceAll.Name = "btnReplaceAll";
            this.btnReplaceAll.Size = new System.Drawing.Size(148, 42);
            this.btnReplaceAll.TabIndex = 7;
            this.btnReplaceAll.Text = "ReplaceAll";
            this.btnReplaceAll.UseVisualStyleBackColor = true;
            this.btnReplaceAll.Visible = false;
            this.btnReplaceAll.Click += new System.EventHandler(this.btnReplaceAll_Click);
            // 
            // chkReplace
            // 
            this.chkReplace.AutoSize = true;
            this.chkReplace.Location = new System.Drawing.Point(61, 121);
            this.chkReplace.Name = "chkReplace";
            this.chkReplace.Size = new System.Drawing.Size(134, 24);
            this.chkReplace.TabIndex = 8;
            this.chkReplace.Text = "ReplaceItems";
            this.chkReplace.UseVisualStyleBackColor = true;
            this.chkReplace.CheckedChanged += new System.EventHandler(this.chkReplace_CheckedChanged);
            // 
            // txtReplace
            // 
            this.txtReplace.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtReplace.Location = new System.Drawing.Point(176, 187);
            this.txtReplace.Name = "txtReplace";
            this.txtReplace.Size = new System.Drawing.Size(453, 30);
            this.txtReplace.TabIndex = 9;
            this.txtReplace.Visible = false;
            // 
            // lblReplace
            // 
            this.lblReplace.AutoSize = true;
            this.lblReplace.Location = new System.Drawing.Point(57, 194);
            this.lblReplace.Name = "lblReplace";
            this.lblReplace.Size = new System.Drawing.Size(68, 20);
            this.lblReplace.TabIndex = 10;
            this.lblReplace.Text = "Replace";
            this.lblReplace.Visible = false;
            // 
            // lblAnd
            // 
            this.lblAnd.AutoSize = true;
            this.lblAnd.Location = new System.Drawing.Point(344, 110);
            this.lblAnd.Name = "lblAnd";
            this.lblAnd.Size = new System.Drawing.Size(38, 20);
            this.lblAnd.TabIndex = 11;
            this.lblAnd.Text = "And";
            this.lblAnd.Visible = false;
            // 
            // btnColor
            // 
            this.btnColor.Location = new System.Drawing.Point(91, 342);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(164, 45);
            this.btnColor.TabIndex = 12;
            this.btnColor.Text = "HighlitedColor";
            this.btnColor.UseVisualStyleBackColor = true;
            this.btnColor.Click += new System.EventHandler(this.btnColor_Click);
            // 
            // btnFont
            // 
            this.btnFont.Location = new System.Drawing.Point(295, 342);
            this.btnFont.Name = "btnFont";
            this.btnFont.Size = new System.Drawing.Size(163, 45);
            this.btnFont.TabIndex = 13;
            this.btnFont.Text = "HighlitedFont";
            this.btnFont.UseVisualStyleBackColor = true;
            this.btnFont.Click += new System.EventHandler(this.btnFont_Click);
            // 
            // btnForeColor
            // 
            this.btnForeColor.Location = new System.Drawing.Point(91, 403);
            this.btnForeColor.Name = "btnForeColor";
            this.btnForeColor.Size = new System.Drawing.Size(164, 43);
            this.btnForeColor.TabIndex = 14;
            this.btnForeColor.Text = "ForeColor";
            this.btnForeColor.UseVisualStyleBackColor = true;
            this.btnForeColor.Click += new System.EventHandler(this.btnForeColor_Click);
            // 
            // FindForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(886, 475);
            this.Controls.Add(this.btnForeColor);
            this.Controls.Add(this.btnFont);
            this.Controls.Add(this.btnColor);
            this.Controls.Add(this.lblAnd);
            this.Controls.Add(this.lblReplace);
            this.Controls.Add(this.txtReplace);
            this.Controls.Add(this.chkReplace);
            this.Controls.Add(this.btnReplaceAll);
            this.Controls.Add(this.btnReplace);
            this.Controls.Add(this.lblFind);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.textBox1);
            this.Name = "FindForm";
            this.Text = "Find";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblFind;
        private System.Windows.Forms.Button btnReplace;
        private System.Windows.Forms.Button btnReplaceAll;
        private System.Windows.Forms.CheckBox chkReplace;
        private System.Windows.Forms.TextBox txtReplace;
        private System.Windows.Forms.Label lblReplace;
        private System.Windows.Forms.Label lblAnd;
        private System.Windows.Forms.Button btnColor;
        private System.Windows.Forms.Button btnFont;
        private System.Windows.Forms.Button btnForeColor;
    }
}