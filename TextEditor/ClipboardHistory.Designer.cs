namespace TextEditor
{
    partial class ClipboardHistory
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
            this.listBoxClipboard = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // listBoxClipboard
            // 
            this.listBoxClipboard.FormattingEnabled = true;
            this.listBoxClipboard.ItemHeight = 20;
            this.listBoxClipboard.Location = new System.Drawing.Point(0, 0);
            this.listBoxClipboard.Name = "listBoxClipboard";
            this.listBoxClipboard.Size = new System.Drawing.Size(412, 604);
            this.listBoxClipboard.TabIndex = 0;
            this.listBoxClipboard.Click += new System.EventHandler(this.listBoxClipboard_Click);
            // 
            // ClipboardHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 609);
            this.Controls.Add(this.listBoxClipboard);
            this.Name = "ClipboardHistory";
            this.Text = "ClipboardHistory";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxClipboard;
    }
}