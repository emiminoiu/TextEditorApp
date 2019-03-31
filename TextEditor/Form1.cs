using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextEditor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public int getWidth()
        {
            int w = 25;
            // get total lines of richTextBox1
            int line = richTextBox1.Lines.Length;

            if (line <= 99)
            {
                w = 20 + (int)richTextBox1.Font.Size;
            }
            else if (line <= 999)
            {
                w = 30 + (int)richTextBox1.Font.Size;
            }
            else
            {
                w = 50 + (int)richTextBox1.Font.Size;
            }

            return w;
        }

        public void AddLineNumbers()
        {
            richTextBox1.Select();
            // create & set Point pt to (0,0)
            Point pt = new Point(0, 0);
            // get First Index & First Line from richTextBox1
            int First_Index = richTextBox1.GetCharIndexFromPosition(pt);
            int First_Line = richTextBox1.GetLineFromCharIndex(First_Index);
            // set X & Y coordinates of Point pt to ClientRectangle Width & Height respectively
            pt.X = ClientRectangle.Width;
            pt.Y = ClientRectangle.Height;
            // get Last Index & Last Line from richTextBox1
            int Last_Index = richTextBox1.GetCharIndexFromPosition(pt);
            int Last_Line = richTextBox1.GetLineFromCharIndex(Last_Index);
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



       
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog(); //Shows the dialog   
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK && openFileDialog.FileName.Contains(".txt")) //Checks if it's all ok and if the file name contains .txt  
            {
                string open = File.ReadAllText(openFileDialog.FileName); //Reads the text from file  
                richTextBox1.Text = open; //Shows the reded text in the textbox  
            }
            else //If something goes wrong...  
            {
                MessageBox.Show("The file you've chosen is not a text file");
            }
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();
            fontDialog.ShowDialog(); //Shows the font dialog   
            if (fontDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                richTextBox1.Font = fontDialog.Font; //Sets the font to the one selected in the dialog  
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.ShowDialog(); //Opens the Show File Dialog  
            if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK) //Check if it's all ok  
            {
                string name = saveFileDialog.FileName + ".txt"; //Just to make sure the extension is .txt  
                File.WriteAllText(name, richTextBox1.Text); //Writes the text to the file and saves it               
            }
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void foreColorToolStripMenuItem_Click(object sender, EventArgs e)
        {

            ColorDialog colorDialog = new ColorDialog();
            colorDialog.ShowDialog(); //Shows the font dialog   
            if (colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                richTextBox1.ForeColor = colorDialog.Color; //Sets the font to the one selected in the dialog  
            }
        }

        private void backColorToolStripMenuItem_Click(object sender, EventArgs e)
        {

            ColorDialog colorDialog = new ColorDialog();
            colorDialog.ShowDialog(); //Shows the font dialog   
            if (colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                richTextBox1.BackColor = colorDialog.Color; //Sets the font to the one selected in the dialog  
            }
        }

        private void LineNumberTextBox_KeyUp(object sender, KeyEventArgs e)
        {
           
        }

        private void richTextBox1_DoubleClick(object sender, EventArgs e)
        {
            
        }

        private void richTextBox1_Enter(object sender, EventArgs e)
        {
            
        }

        private void addLineNumbersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.BackColor = Color.White;

            LineNumberTextBox.Font = richTextBox1.Font;
            AddLineNumbers();
        }

        private void removeLineNumbersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LineNumberTextBox.Clear();
        }

        private void richTextBox1_SelectionChanged(object sender, EventArgs e)
        {
            this.Invalidate();
            Point pt = richTextBox1.GetPositionFromCharIndex(richTextBox1.SelectionStart);
            if (pt.X == 1)
            {
                AddLineNumbers();
            }
            richTextBox1.ForeColor = Color.Black;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (richTextBox1.Text == "")
            {
                AddLineNumbers();
            }
        }

        private void richTextBox1_VScroll(object sender, EventArgs e)
        {
            LineNumberTextBox.Text = "";
            AddLineNumbers();
            LineNumberTextBox.Invalidate();
        }

        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FindForm f = new FindForm(richTextBox1);
        }

        private void replaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReplaceForm f = new ReplaceForm(richTextBox1);
        }

        private void richTextBox1_Click(object sender, EventArgs e)
        {
         richTextBox1.ForeColor = Color.Black;
        }

        private void richTextBox1_MouseClick(object sender, MouseEventArgs e)
        {
          
        }
    }
}
