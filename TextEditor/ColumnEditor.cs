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
                    for (int i = line + 1; i <= textBox.Lines.Count(); i++)
                    {
                        textBox.Text = textBox.Text.Insert(textBox.SelectionStart, initialNumber.ToString());
                        textBox.SelectionStart = textBox.GetFirstCharIndexFromLine(i) + column;
                        textBox.ScrollToCaret();
                        count++;
                        if (count % Convert.ToInt32(txtRepeat.Text) == 0)
                        {
                            initialNumber += Convert.ToInt32(txtIncreasedBy.Text);
                            count = 0;
                        }
                                    
                    }
                    
                }
                if(radioBtnBin.Checked)
                {
                    selected++;
                    int line = textBox.GetLineFromCharIndex(textBox.SelectionStart);
                    int initialNumber = Convert.ToInt32(txtInitialNumber.Text);
                    int count = 0;
                    int column = textBox.SelectionStart - textBox.GetFirstCharIndexFromLine(line);
                    for (int i = line + 1; i <= textBox.Lines.Count(); i++)
                    {
                        string binary = Convert.ToString(initialNumber, 2);
                        textBox.Text = textBox.Text.Insert(textBox.SelectionStart, binary);
                        textBox.SelectionStart = textBox.GetFirstCharIndexFromLine(i) + column;
                        textBox.ScrollToCaret();
                        count++;
                        if (count % Convert.ToInt32(txtRepeat.Text) == 0)
                        {
                            initialNumber += Convert.ToInt32(txtIncreasedBy.Text);
                            count = 0;
                        }
                       

                    }
                }
                if (radioBtnDec.Checked)
                {
                    selected++;
                    int line = textBox.GetLineFromCharIndex(textBox.SelectionStart);
                    int initialNumber = Convert.ToInt32(txtInitialNumber.Text);
                    int count = 0;
                    int column = textBox.SelectionStart - textBox.GetFirstCharIndexFromLine(line);
                    for (int i = line + 1; i <= textBox.Lines.Count(); i++)
                    {
                        string dec = Convert.ToString(initialNumber, 10);
                        textBox.Text = textBox.Text.Insert(textBox.SelectionStart, dec);
                        textBox.SelectionStart = textBox.GetFirstCharIndexFromLine(i) + column;
                        textBox.ScrollToCaret();
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
                    for (int i = line + 1; i <= textBox.Lines.Count(); i++)
                    {
                        string oct = Convert.ToString(initialNumber, 8);
                        textBox.Text = textBox.Text.Insert(textBox.SelectionStart, oct);
                        textBox.SelectionStart = textBox.GetFirstCharIndexFromLine(i) + column;
                        textBox.ScrollToCaret();
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
                    for (int i = line + 1; i <= textBox.Lines.Count(); i++)
                    {
                        string hex = Convert.ToString(initialNumber, 16);
                        textBox.Text = textBox.Text.Insert(textBox.SelectionStart, hex);
                        textBox.SelectionStart = textBox.GetFirstCharIndexFromLine(i) + column;
                        textBox.ScrollToCaret();
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
            groupBox1.Visible = false;
            radioBtnBin.Visible = false;
            radioBtnDec.Visible = false;
            radioBtnOct.Visible = false;
            radioBtnHex.Visible = false;
        }

        private void btnNumberToInsert_CheckedChanged(object sender, EventArgs e)
        {
            if(radioBtnNumberToInsert.Checked)
            {
                groupBox1.Visible = true;
                radioBtnBin.Visible = true;
                radioBtnDec.Visible = true;
                radioBtnOct.Visible = true;
                radioBtnHex.Visible = true;
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
