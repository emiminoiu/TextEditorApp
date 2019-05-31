using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextEditor
{
        public class MyTabPage : System.Windows.Forms.TabPage
        {
        public Form1 mainform;
        public MyRichTextBox _myRichTextBox = new MyRichTextBox();

        public MyTabPage(Form1 mf)
        {
            mainform = mf;

            this._myRichTextBox.Dock = DockStyle.Fill;

            this._myRichTextBox.richTextBox.Text = "";
            _myRichTextBox.richTextBox.Font = new System.Drawing.Font("Monospaced", 10, FontStyle.Regular);
            this._myRichTextBox.richTextBox.Select();

            _myRichTextBox.richTextBox.TextChanged += new EventHandler(this.richTextBox2_TextChanged);
            _myRichTextBox.richTextBox.SelectionChanged += new EventHandler(this.richTextBox2_SelectionChanged);

            _myRichTextBox.richTextBox.LinkClicked += new LinkClickedEventHandler(this.richTextBox2_LinkClicked);

            this.Controls.Add(_myRichTextBox);
        }

        private void richTextBox2_LinkClicked(object sender, LinkClickedEventArgs e)
        {
              Process.Start(e.LinkText);
        }
      

        private void richTextBox2_SelectionChanged(object sender, EventArgs e)
        {
            int sel = _myRichTextBox.richTextBox.SelectionStart;
            int line = _myRichTextBox.richTextBox.GetLineFromCharIndex(sel) + 1;
            int col = sel - _myRichTextBox.richTextBox.GetFirstCharIndexFromLine(line - 1) + 1;

          
        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {
            String str = this.Text;
            if (str.Contains("*"))
            {

            }
            else
            {
                this.Text = str + "*";
            }
        }
    }
    }