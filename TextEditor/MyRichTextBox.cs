using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextEditor
{
    public partial class MyRichTextBox : UserControl
    {
        public RichTextBox richTextBox;
        public MyRichTextBox()
        {
            InitializeComponent();
            richTextBox = this.richTextBox2;
        }

        public int getWidth()
        {
            int w = 25;
            // get total lines of richTextBox1
            int line = LineNumberTextBox.Lines.Length;

            if (line <= 99)
            {
                w = 20 + (int)LineNumberTextBox.Font.Size;
            }
            else if (line <= 999)
            {
                w = 30 + (int)LineNumberTextBox.Font.Size;
            }
            else
            {
                w = 50 + (int)LineNumberTextBox.Font.Size;
            }

            return w;
        }
        public void AddLineNumbers()
        {
            LineNumberTextBox.Select();
            // create & set Point pt to (0,0)
            Point pt = new Point(0, 0);
            // get First Index & First Line from richTextBox1
            int First_Index = LineNumberTextBox.GetCharIndexFromPosition(pt);
            int First_Line = LineNumberTextBox.GetLineFromCharIndex(First_Index);
            // set X & Y coordinates of Point pt to ClientRectangle Width & Height respectively
            pt.X = ClientRectangle.Width;
            pt.Y = ClientRectangle.Height;
            // get Last Index & Last Line from richTextBox1
            int Last_Index = LineNumberTextBox.GetCharIndexFromPosition(pt);
            int Last_Line = LineNumberTextBox.GetLineFromCharIndex(Last_Index);
            // set Center alignment to LineNumberTextBox
            LineNumberTextBox.SelectionAlignment = HorizontalAlignment.Center;
            // set LineNumberTextBox text to null & width to getWidth() function value
            LineNumberTextBox.Text = "";
            LineNumberTextBox.Width = getWidth();
            // now add each line number to LineNumberTextBox upto last line
            for (int i = First_Line; i <= Last_Line + 1; i++)
            {
                LineNumberTextBox.Text += i + 1 + "\n";
            }
        }
        private void richTextBox2_SelectionChanged(object sender, EventArgs e)
        {

            this.Invalidate();
            Point pt = LineNumberTextBox.GetPositionFromCharIndex(LineNumberTextBox.SelectionStart);
            if (pt.X == 1)
            {
                AddLineNumbers();
            }

        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

            if (richTextBox2.Text == "")
            {
                AddLineNumbers();
            }

        }

        private void richTextBox2_VScroll(object sender, EventArgs e)
        {
            LineNumberTextBox.Text = "";
            AddLineNumbers();
            LineNumberTextBox.Invalidate();
        }

        private void LineNumberTextBox_FontChanged(object sender, EventArgs e)
        {
          
        }

        private void LineNumberTextBox_MouseDown(object sender, MouseEventArgs e)
        {
            richTextBox2.Select();
            LineNumberTextBox.DeselectAll();
        }

        private void richTextBox2_FontChanged(object sender, EventArgs e)
        {
            LineNumberTextBox.Font = richTextBox.Font;
             AddLineNumbers();
        }
    }
}