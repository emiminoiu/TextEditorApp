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
    public partial class ClipboardHistory : Form
    {
     
        TabControl tabFile;
        RichTextBox richTextBox;
        RichTextBox richTextBox2;
        public ClipboardHistory(TabControl R1, RichTextBox richTextBox)
        {
            Show();
            tabFile = R1;
            richTextBox2 = richTextBox; 
            InitializeComponent();
        }
        public void AddItem()
        {
            richTextBox2 = tabFile.SelectedTab.Controls[1] as RichTextBox;
            listBoxClipboard.Items.Add(richTextBox2.SelectedText);
        }

        private void listBoxClipboard_Click(object sender, EventArgs e)
        {
            richTextBox = tabFile.SelectedTab.Controls[1] as RichTextBox;
            if (listBoxClipboard.SelectedItem != null)
            {
         
                int p = richTextBox.SelectionStart;
                int l = listBoxClipboard.SelectedItem.ToString().Length;

                richTextBox.Text = richTextBox.Text.Insert(richTextBox.SelectionStart, listBoxClipboard.SelectedItem.ToString());
                richTextBox.SelectionStart = p + l;
                richTextBox.SelectionLength = 1;
               
            }

        }
    }
}
