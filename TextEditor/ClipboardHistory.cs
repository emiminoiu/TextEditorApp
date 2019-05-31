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
        int position;
        bool firstCopy = true;
        RichTextBox richTextBox;
        public ClipboardHistory(RichTextBox R1)
        {
            Show();
            richTextBox = R1;
            InitializeComponent();
        }
        public void AddItem()
        { 
            listBoxClipboard.Items.Add(richTextBox.SelectedText);
        }

        private void listBoxClipboard_Click(object sender, EventArgs e)
        {
            if (listBoxClipboard.SelectedItem != null)
            {
                //if (firstCopy)
                //{
                //    position = richTextBox.SelectionStart;
                //    richTextBox.Text = richTextBox.Text.Insert(richTextBox.SelectionStart, listBoxClipboard.SelectedItem.ToString());
                //    position += listBoxClipboard.SelectedItem.ToString().Length;
                //    firstCopy = false;
                //}
                //else
                //{ 
                      
                //    richTextBox.Text = richTextBox.Text.Insert(position, listBoxClipboard.SelectedItem.ToString());
                //    position += richTextBox.SelectionStart + listBoxClipboard.SelectedItem.ToString().Length;
                //}
              
                int p = richTextBox.SelectionStart;
                int l = listBoxClipboard.SelectedItem.ToString().Length;

                richTextBox.Text = richTextBox.Text.Insert(richTextBox.SelectionStart, listBoxClipboard.SelectedItem.ToString());
                richTextBox.SelectionStart = p + l;
                richTextBox.SelectionLength = 1;
               
            }

        }
    }
}
