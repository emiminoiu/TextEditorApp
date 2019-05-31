namespace TextEditor
{
    partial class ColumnEditor
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.radioBtnTextToInsert = new System.Windows.Forms.RadioButton();
            this.txtInsertText = new System.Windows.Forms.TextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.radioBtnNumberToInsert = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtInitialNumber = new System.Windows.Forms.TextBox();
            this.txtIncreasedBy = new System.Windows.Forms.TextBox();
            this.txtRepeat = new System.Windows.Forms.TextBox();
            this.checkBoxLeadingZero = new System.Windows.Forms.CheckBox();
            this.radioBtnDec = new System.Windows.Forms.RadioButton();
            this.radioBtnOct = new System.Windows.Forms.RadioButton();
            this.radioBtnHex = new System.Windows.Forms.RadioButton();
            this.radioBtnBin = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(67, 62);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(240, 124);
            this.dataGridView1.TabIndex = 0;
            // 
            // radioBtnTextToInsert
            // 
            this.radioBtnTextToInsert.AutoSize = true;
            this.radioBtnTextToInsert.Location = new System.Drawing.Point(90, 53);
            this.radioBtnTextToInsert.Name = "radioBtnTextToInsert";
            this.radioBtnTextToInsert.Size = new System.Drawing.Size(127, 24);
            this.radioBtnTextToInsert.TabIndex = 1;
            this.radioBtnTextToInsert.TabStop = true;
            this.radioBtnTextToInsert.Text = "Text to Insert";
            this.radioBtnTextToInsert.UseVisualStyleBackColor = true;
            this.radioBtnTextToInsert.CheckedChanged += new System.EventHandler(this.insertingTextButton_CheckedChanged);
            // 
            // txtInsertText
            // 
            this.txtInsertText.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtInsertText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtInsertText.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtInsertText.Location = new System.Drawing.Point(106, 108);
            this.txtInsertText.Name = "txtInsertText";
            this.txtInsertText.Size = new System.Drawing.Size(126, 30);
            this.txtInsertText.TabIndex = 2;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(381, 62);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(128, 44);
            this.btnOk.TabIndex = 3;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(381, 127);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(128, 44);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // dataGridView2
            // 
            this.dataGridView2.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(67, 231);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowTemplate.Height = 28;
            this.dataGridView2.Size = new System.Drawing.Size(555, 372);
            this.dataGridView2.TabIndex = 5;
            // 
            // radioBtnNumberToInsert
            // 
            this.radioBtnNumberToInsert.AutoSize = true;
            this.radioBtnNumberToInsert.Location = new System.Drawing.Point(90, 218);
            this.radioBtnNumberToInsert.Name = "radioBtnNumberToInsert";
            this.radioBtnNumberToInsert.Size = new System.Drawing.Size(153, 24);
            this.radioBtnNumberToInsert.TabIndex = 6;
            this.radioBtnNumberToInsert.TabStop = true;
            this.radioBtnNumberToInsert.Text = "Number to Insert";
            this.radioBtnNumberToInsert.UseVisualStyleBackColor = true;
            this.radioBtnNumberToInsert.CheckedChanged += new System.EventHandler(this.btnNumberToInsert_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(162, 293);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "InitialNumber :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(162, 354);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "Increased by :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(162, 407);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "Repeat :";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // txtInitialNumber
            // 
            this.txtInitialNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtInitialNumber.Location = new System.Drawing.Point(324, 293);
            this.txtInitialNumber.Name = "txtInitialNumber";
            this.txtInitialNumber.Size = new System.Drawing.Size(139, 30);
            this.txtInitialNumber.TabIndex = 10;
            // 
            // txtIncreasedBy
            // 
            this.txtIncreasedBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtIncreasedBy.Location = new System.Drawing.Point(324, 344);
            this.txtIncreasedBy.Name = "txtIncreasedBy";
            this.txtIncreasedBy.Size = new System.Drawing.Size(139, 30);
            this.txtIncreasedBy.TabIndex = 11;
            this.txtIncreasedBy.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // txtRepeat
            // 
            this.txtRepeat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtRepeat.Location = new System.Drawing.Point(324, 400);
            this.txtRepeat.Name = "txtRepeat";
            this.txtRepeat.Size = new System.Drawing.Size(139, 30);
            this.txtRepeat.TabIndex = 12;
            // 
            // checkBoxLeadingZero
            // 
            this.checkBoxLeadingZero.AutoSize = true;
            this.checkBoxLeadingZero.Location = new System.Drawing.Point(469, 403);
            this.checkBoxLeadingZero.Name = "checkBoxLeadingZero";
            this.checkBoxLeadingZero.Size = new System.Drawing.Size(135, 24);
            this.checkBoxLeadingZero.TabIndex = 13;
            this.checkBoxLeadingZero.Text = "Leading zeros";
            this.checkBoxLeadingZero.UseVisualStyleBackColor = true;
            // 
            // radioBtnDec
            // 
            this.radioBtnDec.AutoSize = true;
            this.radioBtnDec.Location = new System.Drawing.Point(47, 25);
            this.radioBtnDec.Name = "radioBtnDec";
            this.radioBtnDec.Size = new System.Drawing.Size(63, 24);
            this.radioBtnDec.TabIndex = 16;
            this.radioBtnDec.TabStop = true;
            this.radioBtnDec.Text = "Dec";
            this.radioBtnDec.UseVisualStyleBackColor = true;
            this.radioBtnDec.Visible = false;
            this.radioBtnDec.CheckedChanged += new System.EventHandler(this.radioBtnDec_CheckedChanged);
            // 
            // radioBtnOct
            // 
            this.radioBtnOct.AutoSize = true;
            this.radioBtnOct.Location = new System.Drawing.Point(47, 55);
            this.radioBtnOct.Name = "radioBtnOct";
            this.radioBtnOct.Size = new System.Drawing.Size(59, 24);
            this.radioBtnOct.TabIndex = 17;
            this.radioBtnOct.TabStop = true;
            this.radioBtnOct.Text = "Oct";
            this.radioBtnOct.UseVisualStyleBackColor = true;
            this.radioBtnOct.Visible = false;
            // 
            // radioBtnHex
            // 
            this.radioBtnHex.AutoSize = true;
            this.radioBtnHex.Location = new System.Drawing.Point(227, 25);
            this.radioBtnHex.Name = "radioBtnHex";
            this.radioBtnHex.Size = new System.Drawing.Size(62, 24);
            this.radioBtnHex.TabIndex = 18;
            this.radioBtnHex.TabStop = true;
            this.radioBtnHex.Text = "Hex";
            this.radioBtnHex.UseVisualStyleBackColor = true;
            this.radioBtnHex.Visible = false;
            this.radioBtnHex.CheckedChanged += new System.EventHandler(this.radioBtnHex_CheckedChanged);
            // 
            // radioBtnBin
            // 
            this.radioBtnBin.AutoSize = true;
            this.radioBtnBin.Location = new System.Drawing.Point(227, 55);
            this.radioBtnBin.Name = "radioBtnBin";
            this.radioBtnBin.Size = new System.Drawing.Size(57, 24);
            this.radioBtnBin.TabIndex = 19;
            this.radioBtnBin.TabStop = true;
            this.radioBtnBin.Text = "Bin";
            this.radioBtnBin.UseVisualStyleBackColor = true;
            this.radioBtnBin.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioBtnBin);
            this.groupBox1.Controls.Add(this.radioBtnHex);
            this.groupBox1.Controls.Add(this.radioBtnOct);
            this.groupBox1.Controls.Add(this.radioBtnDec);
            this.groupBox1.Location = new System.Drawing.Point(177, 465);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(332, 111);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Format";
            this.groupBox1.Visible = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // ColumnEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(648, 627);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.checkBoxLeadingZero);
            this.Controls.Add(this.txtRepeat);
            this.Controls.Add(this.txtIncreasedBy);
            this.Controls.Add(this.txtInitialNumber);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.radioBtnNumberToInsert);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txtInsertText);
            this.Controls.Add(this.radioBtnTextToInsert);
            this.Controls.Add(this.dataGridView1);
            this.Name = "ColumnEditor";
            this.Text = "ColumnEditor";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.RadioButton radioBtnTextToInsert;
        private System.Windows.Forms.TextBox txtInsertText;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.RadioButton radioBtnNumberToInsert;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtInitialNumber;
        private System.Windows.Forms.TextBox txtIncreasedBy;
        private System.Windows.Forms.TextBox txtRepeat;
        private System.Windows.Forms.CheckBox checkBoxLeadingZero;
        private System.Windows.Forms.RadioButton radioBtnDec;
        private System.Windows.Forms.RadioButton radioBtnOct;
        private System.Windows.Forms.RadioButton radioBtnHex;
        private System.Windows.Forms.RadioButton radioBtnBin;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}