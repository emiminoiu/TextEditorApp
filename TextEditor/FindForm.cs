using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextEditor
{
    public partial class FindForm : Form
    {
        RichTextBox richtext;
        public FindForm(RichTextBox R)
        {
            this.Show();
            InitializeComponent();
            richtext = R;
        }
        public static void Find(RichTextBox rtb, String word, Color color)
        {
            if (word == "")
            {
                return;
            }
            int s_start = rtb.SelectionStart, startIndex = 0, index;
            while ((index = rtb.Text.IndexOf(word, startIndex)) != -1)
            {
                rtb.Select(index, word.Length);
                rtb.SelectionColor = color;
                rtb.SelectionFont = new Font(rtb.Font, FontStyle.Italic);
                startIndex = index + word.Length;
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
           
            this.Close();
            
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            Find(richtext, textBox1.Text, Color.Red);
        }
    }
}
