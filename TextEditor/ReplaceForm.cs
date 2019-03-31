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
    public partial class ReplaceForm : Form
    {
        RichTextBox richtext;
        public ReplaceForm(RichTextBox R)
        {
            this.Show();
            InitializeComponent();
            richtext = R;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnReplace_Click(object sender, EventArgs e)
        {
            richtext.Text = richtext.Text.Replace(textBox1.Text, textBox2.Text);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
