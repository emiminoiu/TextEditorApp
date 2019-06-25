using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextEditor
{
    public class Undoer : IUndoRedoCommand
    {
        int currentWord;
        RichTextBox txtBox;
        int position = 0;

        protected Dictionary<RichTextBox, string> dictionary = new Dictionary<RichTextBox, string>();
        protected List<string> LastData = new List<string>();
        protected int undoCount = 0;

        Stack<string> undoList = new Stack<string>();
        Stack<string> redoList = new Stack<string>();

        protected bool undoing = false;
        protected bool redoing = false;

        public Undoer(RichTextBox txtBox)
        {
            this.txtBox = txtBox;
            LastData.Add(txtBox.Text);
            //dictionary.Add(txtBox, txtBox.Text);
        }

        public void undoWord_Click(object sender, EventArgs e)
        {
            this.UndoWords();
        }
        public void redoWord_Click(object sender, EventArgs e)
        {
            this.RedoWords();
        }
        public void undoLetter_Click(object sender, EventArgs e)
        {
            this.UndoLetters();
        }
        public void redoLetter_Click(object sender, EventArgs e)
        {
            this.RedoLetters();
        }

        public void UndoWords()
        {
            List<string> allOperands = new List<string>();
            List<string> allOperandsWithoutSpaces = new List<string>();
            string sentence = txtBox.Text;
            int count = 0;
            string[] lineOperands = Regex.Split(sentence, @"\n");
            foreach (var operand in lineOperands)
            {
                allOperands.AddRange(Regex.Split(operand, @" "));
            }

            allOperands.ForEach(a => a = a.Trim());
            foreach (var operand in allOperands)
            {
                if (operand != "")
                {
                    allOperandsWithoutSpaces.Add(operand);
                }
            }
            foreach (string searchString in allOperandsWithoutSpaces)
            {
                count++;
                if (count == allOperandsWithoutSpaces.Count())
                {
                    try
                    {
                        undoing = true;
                        currentWord = searchString.Length + 1;
                        undoCount += searchString.Length + 1;

                        //  txtBox.Text = dictionary.Values.ElementAt(dictionary.Count - undoCount - 1);
                        if (allOperandsWithoutSpaces.Count == 1)
                        {
                            txtBox.Text = "";
                            return;
                        }
                        redoList.Push(undoList.First());
                       
                        //  LastData[LastData.Count - undoCount - 1] = LastData[LastData.Count - undoCount - 1].TrimEnd();
                        //string lastWord = undoList.First().Split(' ').Last();
                        txtBox.Text = undoList.ElementAt(searchString.Count());
                        txtBox.SelectionStart = undoList.Count();
                        txtBox.SelectionLength = 1;
                        for (int i = 1; i <= searchString.Count() + 1; i++)
                        {
                            undoList.Pop();
                        }
                        /*LastData[LastData.Count - undoCount - 1];*/

                        //++undoCount;
                    }
                    catch { }
                    finally { this.undoing = false; }
                    break;
                }

            }
        }

        public void RedoWords()
        {
            try
            {
                if (undoCount == 0)
                    return;

                redoing = true;
                undoCount -= currentWord;

                //   LastData[LastData.Count - undoCount - 1] = LastData[LastData.Count - undoCount - 1].Trim();
                var x = redoList.Pop();
                txtBox.Text = x;
                // txtBox.Text = LastData[LastData.Count - undoCount - 1];
            }
            catch { }
            finally { this.redoing = false; }
        }

        public void Save()
        {
            if (undoing || redoing)
                return;

            string[] lines = txtBox.Lines.ToArray(); //This is to split the rich text box into an array
            string richText = string.Empty;
            foreach (string line in lines)
            {
                if (!string.IsNullOrEmpty(line))
                {//Here is were you re-build the text in the rich text box with lines that have some data in them
                    richText += line;
                    richText += Environment.NewLine;
                }
                else
                    continue;
            }
            //richText = richText.Substring(0, richText.Length - 2); //Need to remove the last Environment.NewLine, else it will look at it as an other line in the rick text box.
            // txtBox.Text = richText;
           // var resultString = Regex.Replace(txtBox.Text, @"^\s+$[\r\n]*", string.Empty, RegexOptions.Multiline);
           
            undoList.Push(richText);
                
            undoCount = 0;
        }

        public void UndoLetters()
        {
            try
            {
                undoing = true;
                ++undoCount;
                txtBox.Text = LastData[LastData.Count - undoCount - 1];
            }
            catch { }
            finally { this.undoing = false; }
        }
        public void RedoLetters()
        {
            try
            {
                if (undoCount == 0)
                    return;

                redoing = true;
                --undoCount;
                txtBox.Text = LastData[LastData.Count - undoCount - 1];
            }
            catch { }
            finally { this.redoing = false; }
        }
    }
}
