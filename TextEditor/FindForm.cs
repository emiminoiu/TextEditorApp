using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextEditor
{
    public partial class FindForm : Form
    {
        [DllImport("user32.dll", SetLastError = true)]
        internal static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);

       
        public  bool clicked { get; set; }
       
        static bool firstFind = true;
        static bool firstReplace = true;
        static int startIndex;
        RichTextBox richtext;
        RichTextBox richtext2;
        public Color x;
        Form MainWindow;
        public static FontStyle y;

        public FindForm(Form f)
        {
            this.Show();
            InitializeComponent();
            //richtext = R;
            //richtext2 = R1;
            MainWindow = f;
        }

        public FindForm()
        {
        }

        public static void Find(RichTextBox rtb, String word, Color color, FontStyle font)
        {
            rtb.Select(0, rtb.TextLength);
            rtb.SelectionBackColor = rtb.BackColor;
            rtb.SelectionFont = rtb.Font;
            if (word == "")
            {
                return;
            }

            int s_start = rtb.SelectionStart, startIndex = 0, index;
            while ((index = rtb.Text.IndexOf(word, startIndex)) != -1)
            {

                rtb.Select(index, word.Length);
                rtb.SelectionBackColor = color;
                rtb.SelectionFont = new Font(rtb.Font, y);
                startIndex = index + word.Length;
            }
            rtb.SelectionStart = s_start;
            rtb.SelectionLength = 0;
            rtb.SelectionColor = color;
        }
        public static void FindNext(RichTextBox rtb, String word, Color color)
        {
            rtb.Select(0, rtb.TextLength);
            rtb.SelectionBackColor = rtb.BackColor;
            rtb.SelectionFont = rtb.Font;
            if (word == "")
            {
                return;
            }
            int index;
            int s_start = 0;
            if (firstFind == true)
            {
                s_start = rtb.SelectionStart;
                startIndex = 0;
            }

            if ((index = rtb.Text.IndexOf(word, startIndex)) != -1)
            {
                rtb.Select(index, word.Length);
                rtb.SelectionBackColor = color;
                rtb.SelectionFont = new Font(rtb.Font, y);
                startIndex = index + word.Length;
                firstFind = false;
            }
            rtb.SelectionStart = s_start;
            rtb.SelectionLength = 0;
            rtb.SelectionColor = Color.Red;
        }
        public static void ReplaceNext(RichTextBox rtb, String oldWord, Color color, String newWord)
        {
            rtb.Select(0, rtb.TextLength);
            rtb.SelectionBackColor = rtb.BackColor;
            rtb.SelectionFont = rtb.Font;

            if (oldWord == "")
            {
                return;
            }
            int index;
            if (firstReplace == true)
            {
                int s_start = rtb.SelectionStart;
                startIndex = 0;
            }

            if ((index = rtb.Text.IndexOf(oldWord, startIndex)) != -1)
            {
                rtb.Select(index, oldWord.Length);
                // rtb.SelectionBackColor = color;
                // rtb.SelectionFont = new Font(rtb.Font, FontStyle.Italic);
                rtb.SelectedText = rtb.SelectedText.Replace(oldWord, newWord);
                startIndex = index + oldWord.Length;
                firstReplace = false;
            }
            //rtb.SelectionStart = s_start;
            //rtb.SelectionLength = 0;
            //rtb.SelectionColor = Color.Red;
        }




        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            foreach (var x in richtext.SelectedText)
            {

            }
            richtext.SelectionBackColor = Color.White;
            richtext2.Clear();
           
            this.Close();

        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            FindNext(richtext, textBox1.Text,x);
            //List<string> found = new List<string>();
            //string line;
            //using (StreamReader file = new StreamReader("C:\\Users\\Minoiu Emi\\Desktop\\asp.net.txt"))
            //{
            //    while ((line = file.ReadLine()) != null)
            //    {
            //        if (line.Contains(textBox1.Text))
            //        {
            //            found.Add(line);
            //        }
            //    }
            //}
            //foreach(var x in found)
            //{
            //    Console.WriteLine(x);
            //}


        }
        private void button1_Click(object sender, EventArgs e)
        {
            richtext2.Clear();
            
          
            Find(richtext, textBox1.Text, x, y);
            startIndex = 0;
            clicked = true;
            var lines = richtext.Lines;
            int count = 0;
            List<string> items = new List<string>();
            foreach (var x in lines)
            {
                count++;
                if (x.Contains(textBox1.Text))
                {
                    richtext2.AppendText("Line" + count + ":  ");
                    Console.WriteLine(x + "\n");
                    richtext2.AppendText(x + "\n");
                    richtext2.Visible = true;
                    items.Add(x);

                }
            }
            Select(richtext2, textBox1.Text,Color.Yellow, FontStyle.Bold);
            
            //richtext
           
        }

        private void Select(RichTextBox richtext2, string text, Color x, FontStyle y)
        {
            richtext2.Select(0, richtext2.TextLength);
            richtext2.SelectionBackColor = richtext2.BackColor;
            richtext2.SelectionFont = richtext2.Font;
            if (text == "")
            {
                return;
            }

            int s_start = richtext2.SelectionStart, startIndex = 0, index;
            while ((index = richtext2.Text.IndexOf(text, startIndex)) != -1)
            {

                richtext2.Select(index, text.Length);
                richtext2.SelectionBackColor = x;
                richtext2.SelectionFont = new Font(richtext2.Font, y);
                startIndex = index + text.Length;
            }
            richtext2.SelectionStart = s_start;
            richtext2.SelectionLength = 0;
            richtext2.SelectionColor = x;
        }

        private void lblFind_Click(object sender, EventArgs e)
        {

        }

        private void chkReplace_CheckedChanged(object sender, EventArgs e)
        {
            bool v = chkReplace.Checked;
            if (v)
            {
                lblReplace.Visible = true;
                btnReplace.Visible = true;
                btnReplaceAll.Visible = true;
                lblAnd.Visible = true;
                txtReplace.Visible = true;
                this.Text = "Find and Replace";
            }
            else
            {
                lblReplace.Visible = false;
                btnReplace.Visible = false;
                btnReplaceAll.Visible = false;
                lblAnd.Visible = false;
                txtReplace.Visible = false;
                this.Text = "Find";
            }
        }

        private void btnReplaceAll_Click(object sender, EventArgs e)
        {
            richtext.Text = richtext.Text.Replace(textBox1.Text, txtReplace.Text);
            richtext.Select(0, richtext.TextLength);
            richtext.SelectionBackColor = richtext.BackColor;
            richtext.SelectionFont = richtext.Font;
            startIndex = 0;
        }

        private void btnReplace_Click(object sender, EventArgs e)
        {
            ReplaceNext(richtext, textBox1.Text, x, txtReplace.Text);
            startIndex = 0;
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.Color = richtext.ForeColor;
            colorDialog.ShowDialog(); //Shows the font dialog   
            if (colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                x = colorDialog.Color;
            }
        }

        private void btnFont_Click(object sender, EventArgs e)
        {

            FontDialog fontDialog = new FontDialog();
            fontDialog.Font = richtext.Font;

            fontDialog.ShowDialog(); //Shows the font dialog   
            if (fontDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                y = fontDialog.Font.Style; //Sets the font to the one selected in the dialog  
            }
        }

        private void btnForeColor_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();
            fontDialog.Font = richtext.Font;

            fontDialog.ShowDialog(); //Shows the font dialog   
            if (fontDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                // z = fontDialog.Font; //Sets the font to the one selected in the dialog  
            }
        }
    }
}
