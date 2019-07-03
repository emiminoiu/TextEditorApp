using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;

namespace TextEditor
{
    public partial class ColumnEditor : Form
    {
        RichTextBox textBox;
        public ColumnEditor(RichTextBox textBox)
        {
            InitializeComponent();
            this.textBox = textBox;
           
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
       
        private void btnOk_Click(object sender, EventArgs e)
        {
          
            if (radioBtnTextToInsert.Checked)
            {
                int line = textBox.GetLineFromCharIndex(textBox.SelectionStart);
                int column = textBox.SelectionStart - textBox.GetFirstCharIndexFromLine(line);
                for (int i = line; i < textBox.Lines.Count(); i++)
                {
                    int c = textBox.GetFirstCharIndexFromLine(i) + column;
                    int ll = textBox.Lines[i].Length - c;
                    if (ll < 0)
                    {
                        string s = "".PadRight(-ll);
                        textBox.Text = textBox.Text.Insert(textBox.GetFirstCharIndexFromLine(i) + textBox.Lines[i].Length, s);
                    }
                    textBox.Text = textBox.Text.Insert(c, txtInsertText.Text);
                    
                    if (textBox.TextLength > c)
                        textBox.SelectionStart = c;
                    //textBox.ScrollToCaret();
                }
               
            }
            if(radioBtnNumberToInsert.Checked)
            {
                
                int selected = 0;
                if(radioBtnDec.Checked)
                {
                    selected++;
                    int line = textBox.GetLineFromCharIndex(textBox.SelectionStart);
                    int initialNumber = Convert.ToInt32(txtInitialNumber.Text);
                    int count = 0;
                    int column = textBox.SelectionStart - textBox.GetFirstCharIndexFromLine(line);
                    for (int i = line; i < textBox.Lines.Count(); i++)
                    {
                        int c = textBox.GetFirstCharIndexFromLine(i) + column;
                        int ll = textBox.Lines[i].Length - c;
                        if (ll < 0)
                        {
                            string s = "".PadRight(-ll);
                            textBox.Text = textBox.Text.Insert(textBox.GetFirstCharIndexFromLine(i) + textBox.Lines[i].Length, s);
                        }
                        textBox.Text = textBox.Text.Insert(c, initialNumber.ToString());
                        if (textBox.TextLength > c)
                            textBox.SelectionStart = c;
                        count++;
                        if (count % Convert.ToInt32(txtRepeat.Text) == 0)
                        {
                            initialNumber += Convert.ToInt32(txtIncreasedBy.Text);
                            count = 0;
                        }
                                    
                    }
                    
                }
          
                if (radioBtnBin.Checked)
                {
                    selected++;
                    int line = textBox.GetLineFromCharIndex(textBox.SelectionStart);
                    int initialNumber = Convert.ToInt32(txtInitialNumber.Text);
                    int count = 0;
                    int column = textBox.SelectionStart - textBox.GetFirstCharIndexFromLine(line);
                    for (int i = line; i < textBox.Lines.Count(); i++)
                    {
                        string binary = Convert.ToString(initialNumber, 2);
                        int c = textBox.GetFirstCharIndexFromLine(i) + column;
                        int ll = textBox.Lines[i].Length - c;
                        if (ll < 0)
                        {
                            string s = "".PadRight(-ll);
                            textBox.Text = textBox.Text.Insert(textBox.GetFirstCharIndexFromLine(i) + textBox.Lines[i].Length, s);
                        }
                        textBox.Text = textBox.Text.Insert(c, binary);
                        if (textBox.TextLength > c)
                            textBox.SelectionStart = c;
                        count++;
                        if (count % Convert.ToInt32(txtRepeat.Text) == 0)
                        {
                            initialNumber += Convert.ToInt32(txtIncreasedBy.Text);
                            count = 0;
                        }

                    }

                }

                if (radioBtnOct.Checked)
                {
                    selected++;
                    int line = textBox.GetLineFromCharIndex(textBox.SelectionStart);
                    int initialNumber = Convert.ToInt32(txtInitialNumber.Text);
                    int count = 0;
                    int column = textBox.SelectionStart - textBox.GetFirstCharIndexFromLine(line);
                    for (int i = line; i < textBox.Lines.Count(); i++)
                    {
                        string oct = Convert.ToString(initialNumber, 8);
                        int c = textBox.GetFirstCharIndexFromLine(i) + column;
                        int ll = textBox.Lines[i].Length - c;
                        if (ll < 0)
                        {
                            string s = "".PadRight(-ll);
                            textBox.Text = textBox.Text.Insert(textBox.GetFirstCharIndexFromLine(i) + textBox.Lines[i].Length, s);
                        }
                        textBox.Text = textBox.Text.Insert(c, oct);
                        if (textBox.TextLength > c)
                            textBox.SelectionStart = c;
                        count++;
                        if (count % Convert.ToInt32(txtRepeat.Text) == 0)
                        {
                            initialNumber += Convert.ToInt32(txtIncreasedBy.Text);
                            count = 0;
                        }

                    }
                }

                  
                if (radioBtnHex.Checked)
                {
                    selected++;
                    int line = textBox.GetLineFromCharIndex(textBox.SelectionStart);
                    int initialNumber = Convert.ToInt32(txtInitialNumber.Text);
                    int count = 0;
                    int column = textBox.SelectionStart - textBox.GetFirstCharIndexFromLine(line);
                    for (int i = line; i < textBox.Lines.Count(); i++)
                    {
                        string hex = Convert.ToString(initialNumber, 16);
                        int c = textBox.GetFirstCharIndexFromLine(i) + column;
                        int ll = textBox.Lines[i].Length - c;
                        if (ll < 0)
                        {
                            string s = "".PadRight(-ll);
                            textBox.Text = textBox.Text.Insert(textBox.GetFirstCharIndexFromLine(i) + textBox.Lines[i].Length, s);
                        }
                        textBox.Text = textBox.Text.Insert(c, hex);
                        if (textBox.TextLength > c)
                            textBox.SelectionStart = c;
                        count++;
                        if (count % Convert.ToInt32(txtRepeat.Text) == 0)
                        {
                            initialNumber += Convert.ToInt32(txtIncreasedBy.Text);
                            count = 0;
                        }

                    }

                              }
                if (selected == 0)
                {
                    MessageBox.Show("Please select one format");
                    
                }
            }
            
        }

        private void insertingTextButton_CheckedChanged(object sender, EventArgs e)
        {
            groupBox1.Enabled = false;
            radioBtnBin.Enabled = false;
            radioBtnDec.Enabled = false;
            radioBtnHex.Enabled = false;
            radioBtnOct.Enabled = false;
        }

        private void btnNumberToInsert_CheckedChanged(object sender, EventArgs e)
        {
            if(radioBtnNumberToInsert.Checked)
            {
                groupBox1.Enabled = true;
                radioBtnBin.Enabled = true;
                radioBtnDec.Enabled = true;
                radioBtnHex.Enabled = true;
                radioBtnOct.Enabled = true;
            }
        }
        private void radioBtnDec_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioBtnHex_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
