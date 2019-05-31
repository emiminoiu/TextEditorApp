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
    public partial class SearchInFileForm : Form
    {
        public string filePath;
        ListBox listBox;
        public SearchInFileForm(ListBox l)
        {
            this.Show();
            InitializeComponent();
            listBox = l;
        }

        private void btnOpenFileDialog_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog(); //Shows the dialog   
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK && openFileDialog.FileName.Contains(".txt")) //Checks if it's all ok and if the file name contains .txt  
            {
                FileInfo f = new FileInfo(openFileDialog.FileName);
                filePath = f.FullName;
                filePathTextBox.Text = f.FullName; //Shows the path text in the textbox  
            }
            else //If something goes wrong...  
            {
                MessageBox.Show("The file you've chosen is not a text file");
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            listBox.Items.Clear();
            int hits = 0;
            string line;
            int count = 0;
            listBox.Items.Add("Path: " + filePath);        
            using (StreamReader file = new StreamReader(filePath))
            {
                while ((line = file.ReadLine()) != null)
                {
                    count++;
                    if (line.Contains(searchTextBox.Text))
                    {
                        hits++;
                        SearchedItems s = new SearchedItems();
                        s.LineNumber = count;
                        s.LineText = line;
                        s.findForm = false;
                        listBox.Items.Add(s);
                        listBox.Visible = true;
                    }
                }
            }
            var text = "Searched: " + searchTextBox.Text + "(" + hits + " hits)";
            listBox.Items.Add(text);
        }
    }
}
