using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextEditor
{
    public partial class InsertionPanel : Form
    {
        DataTable dt = new DataTable();
        TabControl tabFile;
        RichTextBox richTextBox;
        RichTextBox richTextBox2;
    
        public InsertionPanel(TabControl R1, RichTextBox richTextBox)
        {
            
            dt.Columns.Add("Value", typeof(int));
            dt.Columns.Add("Hex", typeof(string));
            dt.Columns.Add("Character", typeof(string));
            InitializeComponent();
            dataGridView1.DataSource = dt;
            for (int i = 0; i <= 255; i++)
            {
                string hex = Convert.ToString(i, 16);
                if (i <= 15)
                {
                    hex = "0" + Convert.ToString(i, 16);
                }
                char special = Convert.ToChar(i);
                if (i == 32)
                {
                    string x = "Space";
                    dt.Rows.Add(i, hex, x);
               
                }
                if (i == 9)
                {
                    string x = "Tab";
                    dt.Rows.Add(i, hex, x);
                 
                }
                if (i == 10)
                {
                    string x = "LF";
                    dt.Rows.Add(i, hex, x);
                  
                }

                if (i > 32 && (i < 127 || i > 160))
               
                {
                    dt.Rows.Add(i, hex, special);
                   
                }
                
            }
            Show();
            tabFile = R1;
            richTextBox2 = richTextBox;

        }
     
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            bool visited = false;
            richTextBox = tabFile.SelectedTab.Controls[1] as RichTextBox;


            int p = richTextBox.SelectionStart;
            var element = dt.Rows[e.RowIndex]["Character"].ToString();
            int l = dt.Rows[e.RowIndex]["Character"].ToString().Length;
            if(element.Equals("Tab"))
            {
                richTextBox.Text = richTextBox.Text.Insert(richTextBox.SelectionStart,"  ");
                richTextBox.SelectionStart = p + 2;
                richTextBox.ScrollToCaret();
                richTextBox.Focus();
                visited = true;
            }
            if (element.Equals("LF"))
            {
                richTextBox.AppendText("\r\n");
                visited = true;
                richTextBox.ScrollToCaret();
                richTextBox.Focus();

            }
            if (element.Equals("Space"))
            {
                richTextBox.Text = richTextBox.Text.Insert(richTextBox.SelectionStart, " ");
                richTextBox.SelectionStart = p + 1;
                richTextBox.ScrollToCaret();
                richTextBox.Focus();
                visited = true;
            }
            if (!visited)
            {
                richTextBox.Text = richTextBox.Text.Insert(richTextBox.SelectionStart, dt.Rows[e.RowIndex]["Character"].ToString());
                richTextBox.SelectionStart = p + l;
                richTextBox.SelectionLength = 1;
            }
        }
    }
}
