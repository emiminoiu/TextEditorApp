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
    public partial class SearchInFolder : Form
    {
        int hits = 0;
        string[] files;
        ListBox listBox;
        int count;
        public SearchInFolder(ListBox l)
        {
            this.Show();
            InitializeComponent();
            listBox = l;
        }


        private void btnSearch_Click(object sender, EventArgs e)
        {
            count = 0;
            if (string.IsNullOrWhiteSpace(searchTextBox.Text))
                return;


            
            foreach (string file in files)
            {
                Console.WriteLine(file.ToString());
                listBox.Items.Add("Path: " + file.ToString());
                string[] lines = File.ReadAllLines(file);
                foreach (var line in lines)
                {
                    count++;
                    if (line.Contains(searchTextBox.Text))
                    {
                        hits++;
                        SearchedItems s = new SearchedItems();
                        s.LineNumber = count;
                        s.LineText = line;
                        s.findForm = false;
                        s.path = file.ToString();
                        listBox.Items.Add(s);
                        listBox.Visible = true;
                    }
                }
                
               
                count = 0;
            }
            listBox.Items.Add("Total Matches:  " + hits );

        }


        private void btnOpenFileDialog_Click(object sender, EventArgs e)
        {

            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    files = Directory.GetFiles(fbd.SelectedPath);
                    folderPathTextBox.Text = fbd.SelectedPath;
                }
            }
        }

    }
}
