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
    public partial class GoToForm : Form
    {
        RichTextBox richText;
        public GoToForm(RichTextBox R)
        {
            this.Show();
            richText = R;
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            RichTextBox rtb = new RichTextBox();
            rtb.Text = richText.Text;
            int lines = rtb.Lines.Length;

            if (textBox1.Text == "")
            {
                button1.Enabled = false;
              
            }
            else if (!int.TryParse(textBox1.Text, out int sel))
            {
                button1.Enabled = false;
               
            }
            else if (Int32.Parse(textBox1.Text) > rtb.Lines.Length)
            {
                button1.Enabled = false;
              
            }
            else if (textBox1.Text == "0")
            {
                button1.Enabled = false;
             
            }
            else
            {
                button1.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int line = Int32.Parse(textBox1.Text);
            richText.SelectionStart = richText.GetFirstCharIndexFromLine(line - 1);
            richText.ScrollToCaret();
            this.Close();
        }
    }
}
