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
            string sentence = txtBox.Text;

            string[] lineOperands = Regex.Split(sentence, @"\n");
            foreach (var operand in lineOperands)
            {
                allOperands.AddRange(Regex.Split(operand, @" "));
            }
            int count = 0;
            foreach (string searchString in allOperands)
            {
                count++;
                if (count == allOperands.Count)
                {
                    //if (searchString != "")
                    //{
                    try
                    {
                        undoing = true;
                        currentWord = searchString.Length + 1;
                        undoCount += searchString.Length + 1;
                       
                        //  txtBox.Text = dictionary.Values.ElementAt(dictionary.Count - undoCount - 1);
                        if (allOperands.Count == 1)
                        {
                            txtBox.Text = "";
                            return;
                        }
                        //  LastData[LastData.Count - undoCount - 1] = LastData[LastData.Count - undoCount - 1].TrimEnd();
                        txtBox.Text = undoList.ElementAt(searchString.Count());
                        for (int i = 1; i <= searchString.Count() + 1; i++)
                        {
                          
                           // redoList.Push(undoList.ElementAt(searchString.Count()-i));
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
                txtBox.Text = redoList.ElementAt(currentWord);
                // txtBox.Text = LastData[LastData.Count - undoCount - 1];
            }
            catch { }
            finally { this.redoing = false; }
        }

        public void Save()
        {
            if (undoing || redoing)
                return;
            //if (dictionary.Values.ElementAt(dictionary.Count - 1).Equals(txtBox.Text))
            //    return;
           
            //if (LastData[LastData.Count - 1] == txtBox.Text)
            //    return;
            
            undoList.Push(txtBox.Text.Trim());
            LastData.Add(txtBox.Text);

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
