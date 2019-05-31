using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextEditor
{
    public partial class Form1 : Form
    {
        RichTextBox richTextBox;
        RichTextBox lineTextBox;
        Dictionary<String, TabPage> files;
        int count = 1;
        //I'm using this with filesystemwatcher when modifying content in other opened files
        double clicked;
        public string fileName;
        //I'm using this to count tab pages
        static int pageNumber = 1;
        //I'm using this when open the clipboardhistory page
        public ClipboardHistory ch;
        //I'm testing if clipboard is on where making cut/copy operation in richtextbox
        static bool clipboardOn = false;
        public Form1()
        {
            InitializeComponent();
            files = new Dictionary<string, TabPage>();
            files.Add("New", tabItem);
        }
        public void ResizeFrame()
        {
            this.Size = new System.Drawing.Size(570, 550);
        }

        private void watch(string path)
        {
            FileSystemWatcher watcher = new FileSystemWatcher();
            watcher.Path = path;
            watcher.NotifyFilter = NotifyFilters.LastWrite;
            watcher.Filter = "*.txt";
            watcher.Changed += new FileSystemEventHandler(OnChanged);
            watcher.EnableRaisingEvents = true;
        }

        private void OnChanged(object sender, FileSystemEventArgs e)
        {
            FileInfo file = new FileInfo(e.FullPath);
            if (clicked != file.LastWriteTime.Millisecond)
            {
                clicked = file.LastWriteTime.Millisecond;
                DialogResult dialogResult = MessageBox.Show("The file has been modified,do you want to load the changes?", "File Modified", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    //using (var fileStream = new FileStream(fileName, FileMode.OpenOrCreate))
                    //{
                    //    using (var reader = new StreamReader(fileStream))
                    //    {
                    //        richTextBox1.Invoke(new Action(() => { richTextBox1.Text = reader.ReadToEnd(); }));
                    //        reader.Close();
                    //    }
                    //}
                    string open = File.ReadAllText(fileName); //Re
                                                              //richTextBox1.Text = open;
                    richTextBox1.Invoke(new Action(() => { richTextBox1.Text = open; }));

                }
                else if (dialogResult == DialogResult.No)
                {
                    //do something else
                }
            }

        }
        public int getWidth()
        {
            int w = 25;
            // get total lines of richTextBox1
            int line = LineNumberTextBox.Lines.Length;

            if (line <= 99)
            {
                w = 20 + (int)LineNumberTextBox.Font.Size;
            }
            else if (line <= 999)
            {
                w = 30 + (int)LineNumberTextBox.Font.Size;
            }
            else
            {
                w = 50 + (int)LineNumberTextBox.Font.Size;
            }

            return w;
        }
        public int getWidthTabs()
        {
            int w = 25;
            // get total lines of richTextBox1
            int line = lineTextBox.Lines.Length;

            if (line <= 99)
            {
                w = 20 + (int)lineTextBox.Font.Size;
            }
            else if (line <= 999)
            {
                w = 30 + (int)lineTextBox.Font.Size;
            }
            else
            {
                w = 50 + (int)lineTextBox.Font.Size;
            }

            return w;
        }
        public void AddLineNumbers()
        {
            richTextBox1.Select();
            // create & set Point pt to (0,0)
            Point pt = new Point(0, 0);
            // get First Index & First Line from richTextBox1
            int First_Index = richTextBox1.GetCharIndexFromPosition(pt);
            int First_Line = richTextBox1.GetLineFromCharIndex(First_Index);
            // set X & Y coordinates of Point pt to ClientRectangle Width & Height respectively
            pt.X = ClientRectangle.Width;
            pt.Y = ClientRectangle.Height;
            // get Last Index & Last Line from richTextBox1
            int Last_Index = richTextBox1.GetCharIndexFromPosition(pt);
            int Last_Line = richTextBox1.GetLineFromCharIndex(Last_Index);
            // set Center alignment to LineNumberTextBox
            LineNumberTextBox.SelectionAlignment = HorizontalAlignment.Center;
            // set LineNumberTextBox text to null & width to getWidth() function value
            LineNumberTextBox.Text = "";
            LineNumberTextBox.Width = getWidth();
            // now add each line number to LineNumberTextBox upto last line
            for (int i = First_Line; i <= Last_Line + 1; i++)
            {
                LineNumberTextBox.Text += i + 1 + "\n";
            }
        }

        public void AddLineNumbersTabs()
        {
            richTextBox.Select();
            // create & set Point pt to (0,0)
            Point pt = new Point(0, 0);
            // get First Index & First Line from richTextBox1
            int First_Index = richTextBox.GetCharIndexFromPosition(pt);
            int First_Line = richTextBox.GetLineFromCharIndex(First_Index);
            // set X & Y coordinates of Point pt to ClientRectangle Width & Height respectively
            pt.X = ClientRectangle.Width;
            pt.Y = ClientRectangle.Height;
            // get Last Index & Last Line from richTextBox1
            int Last_Index = richTextBox.GetCharIndexFromPosition(pt);
            int Last_Line = richTextBox.GetLineFromCharIndex(Last_Index);
            // set Center alignment to LineNumberTextBox
            lineTextBox.SelectionAlignment = HorizontalAlignment.Center;
            // set LineNumberTextBox text to null & width to getWidth() function value
            lineTextBox.Text = "";
            lineTextBox.Width = getWidth();
            // now add each line number to LineNumberTextBox upto last line
            for (int i = First_Line; i <= Last_Line + 1; i++)
            {
                lineTextBox.Text += i + 1 + "\n";
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            // openFileDialog.ShowDialog(); //Shows the dialog   
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK && openFileDialog.FileName.Contains(".txt")) //Checks if it's all ok and if the file name contains .txt  
            {
                string open = File.ReadAllText(openFileDialog.FileName); //Reads the text from file  
                richTextBox1.Text = open; //Shows the reded text in the textbox  
                FileInfo f = new FileInfo(openFileDialog.FileName);
                string path = f.FullName;
                openFileDialog.Dispose();
                watch(path);


            }
            else //If something goes wrong...  
            {
                MessageBox.Show("The file you've chosen is not a text file");
            }

        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();
            // fontDialog.ShowDialog(); //Shows the font dialog   
            if (fontDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                richTextBox1.Font = fontDialog.Font; //Sets the font to the one selected in the dialog  
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            //saveFileDialog.ShowDialog(); //Opens the Show File Dialog  
            if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK) //Check if it's all ok  
            {
                string name = saveFileDialog.FileName + ".txt"; //Just to make sure the extension is .txt  
                File.WriteAllText(name, richTextBox1.Text); //Writes the text to the file and saves it               
            }
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void foreColorToolStripMenuItem_Click(object sender, EventArgs e)
        {

            ColorDialog colorDialog = new ColorDialog();
            //colorDialog.ShowDialog(); //Shows the font dialog   
            if (colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                richTextBox1.ForeColor = colorDialog.Color; //Sets the font to the one selected in the dialog  
            }
        }

        private void backColorToolStripMenuItem_Click(object sender, EventArgs e)
        {

            ColorDialog colorDialog = new ColorDialog();
            //colorDialog.ShowDialog(); //Shows the font dialog   
            if (colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                richTextBox1.BackColor = colorDialog.Color; //Sets the font to the one selected in the dialog  
            }
        }

        private void LineNumberTextBox_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void richTextBox1_DoubleClick(object sender, EventArgs e)
        {
            string word = richTextBox1.SelectedText;
            SelectAll(richTextBox1, word, Color.Yellow, Font.Bold);

        }

        private void SelectAll(RichTextBox richTextBox1, string word, Color yellow, bool bold)
        {
            richTextBox1.Select(0, richTextBox1.TextLength);
            richTextBox1.SelectionBackColor = richTextBox1.BackColor;
            richTextBox1.SelectionFont = richTextBox1.Font;
            if (word == "")
            {
                return;
            }

            int s_start = richTextBox1.SelectionStart, startIndex = 0, index;
            while ((index = richTextBox1.Text.IndexOf(word, startIndex)) != -1)
            {

                richTextBox1.Select(index, word.Length);
                richTextBox1.SelectionBackColor = yellow;
                richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Bold);
                startIndex = index + word.Length;
            }
            richTextBox1.SelectionStart = s_start;
            richTextBox1.SelectionLength = 0;
            richTextBox1.SelectionColor = yellow;
        }

        private void richTextBox1_Enter(object sender, EventArgs e)
        {

        }


        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FindForm f = new FindForm(richTextBox1, listBox1);
        }

        private void replaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReplaceForm f = new ReplaceForm(richTextBox1);
        }

        private void richTextBox1_Click(object sender, EventArgs e)
        {

            //richTextBox1.Select(0, richTextBox1.TextLength);
            richTextBox1.SelectionBackColor = Color.White;
            richTextBox1.SelectionFont = richTextBox1.Font;
        }
        private void richTextBox1_ClickTabs(object sender, EventArgs e)
        {

            //richTextBox1.Select(0, richTextBox1.TextLength);
            richTextBox.SelectionBackColor = Color.White;
            richTextBox.SelectionFont = richTextBox.Font;
        }


        private void goToLineNumberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GoToForm goToForm = new GoToForm(richTextBox1);
        }
        public static Boolean _isArgsNull = true;
        public Boolean IsArgumentNull
        {
            get { return _isArgsNull; }
            set { _isArgsNull = value; Invalidate(); }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

            if (_isArgsNull)
            {
                File_New_MenuItem_Click(sender, e);

            }

        }



        private void File_New_MenuItem_Click(object sender, EventArgs e)
        {
            //   MyTabPage tabpage = new MyTabPage(this);
            //   tabpage.Text = "Untitled " + count;
            //   tabFiles.TabPages.Add(tabpage);

            //   tabFiles.SelectedTab = tabpage;

            //   var _myRichTextBox = (MyRichTextBox)tabFiles.TabPages[tabFiles.SelectedIndex].Controls[0];
            //   _myRichTextBox.richTextBox.Select();

            //   //add contextmenustrip to richTextBox1
            ////   _myRichTextBox.richTextBox.ContextMenuStrip = myContextMenuStrip;



            //   this.Text = "C# Notepad [ Untitled " + count + " ]";


            //   count++;
        }


        private void LineNumberTextBox_TextChanged(object sender, EventArgs e)
        {

        }



        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index = 1;
            List<string> keys = new List<string>();
            foreach (string key in files.Keys)
            {
                if (key.StartsWith("New"))
                {
                    keys.Add(key);
                }
            }
            if (keys.Count == 0)
            {
                index = 0;
            }
            else if (keys.Count == 1)
            {
                index = 1;
            }
            else
            {
                keys.Sort();
                index = 1;
                foreach (string s in keys)
                {
                    string resultString = Regex.Match(s, @"\d+").Value;
                    if (resultString.Length == 0)
                        continue;
                    int val = Int32.Parse(resultString);
                    if (val > index)
                    {
                        break;
                    }
                    else if (val == index)
                    {
                        index++;
                    }
                }
            }
            TabPage first = tabFiles.TabPages[0];
            RichTextBox txt = first.Controls[0] as RichTextBox;
            RichTextBox txt2 = first.Controls[1] as RichTextBox;
            TabPage page = new TabPage();
            RichTextBox rtb = new RichTextBox();
            RichTextBox rtb2 = new RichTextBox();

         
            page.Bounds = first.Bounds;
            rtb.Bounds = txt.Bounds;
          
            rtb2.Bounds = txt2.Bounds;
            richTextBox = rtb;
            lineTextBox = rtb2;
            rtb2.ScrollBars = 0;
            rtb.Click += richTextBox1_ClickTabs;
            rtb.FontChanged += richTextBox1_FontChangedTabs;
            rtb.SelectionChanged += richTextBox1_SelectionChangedTabs;
            rtb.TextChanged += richTextBox1_TextChangedTabs;
            rtb.VScroll += richTextBox1_VScrollTabs;
            page.Controls.Add(rtb);
            page.Controls.Add(rtb2);
            string title = index == 0 ? "New" : ("New " + index);
            page.Text = title;
            rtb.Text = "";
            files[title] = page;
            tabFiles.TabPages.Add(page);
            tabFiles.SelectedTab = page;
           
        }

        private void openToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "(*.txt)|*.txt";
            DialogResult res = ofd.ShowDialog(this);
            if (res == DialogResult.OK && ofd.FileName.Length > 0)
            {
                string file = ofd.FileName;
                if (files.ContainsKey(file))
                {
                    TabPage page = files[file];
                    RichTextBox rtb = page.Controls[0] as RichTextBox;
                    rtb.Text = File.ReadAllText(file);
                    tabFiles.SelectedTab = page;
                }
                else
                {
                    TabPage first = tabFiles.TabPages[0];
                    RichTextBox txt = first.Controls[1] as RichTextBox;
                    RichTextBox txt2 = first.Controls[0] as RichTextBox;
                    if (txt.TextLength == 0 && first.Text == "New")
                    {
                        FileInfo info = new FileInfo(file);
                        first.Text = info.Name;
                        txt.Text = File.ReadAllText(file);
                        files.Remove("New");
                        files[file] = first;
                        tabFiles.SelectedTab = first;
                    }
                    else
                    {
                        TabPage page = new TabPage();
                        RichTextBox rtb = new RichTextBox();
                        RichTextBox rtb2 = new RichTextBox();
                        page.Bounds = first.Bounds;
                        rtb.Bounds = txt.Bounds;
                        rtb2.Bounds = txt2.Bounds;
                        richTextBox = rtb;
                        lineTextBox = rtb2;
                        rtb2.ScrollBars = 0;
                        rtb.Click += richTextBox1_ClickTabs;
                        rtb.FontChanged += richTextBox1_FontChangedTabs;
                        rtb.SelectionChanged += richTextBox1_SelectionChangedTabs;
                        rtb.TextChanged += richTextBox1_TextChangedTabs;
                        rtb.VScroll += richTextBox1_VScrollTabs;
                        page.Controls.Add(rtb);
                        page.Controls.Add(rtb2);

                        FileInfo info = new FileInfo(file);
                        page.Text = info.Name;
                        rtb.Text = File.ReadAllText(file);
                        files[file] = page;
                        tabFiles.TabPages.Add(page);
                        tabFiles.SelectedTab = page;
                    }
                }

            }

        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            //saveFileDialog.ShowDialog(); //Opens the Show File Dialog  
            if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK) //Check if it's all ok  
            {
                string name = saveFileDialog.FileName + ".txt"; //Just to make sure the extension is .txt  
                File.WriteAllText(name, richTextBox1.Text); //Writes the text to the file and saves it               
            }
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Redo();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
            if (clipboardOn)
            {
                ch.AddItem();
            }

        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void fontToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();
            //fontDialog.ShowDialog(); //Shows the font dialog   
            if (fontDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                richTextBox1.Font = fontDialog.Font; //Sets the font to the one selected in the dialog  
            }
        }

        private void colorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            //colorDialog.ShowDialog(); //Shows the font dialog   
            if (colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                richTextBox1.ForeColor = colorDialog.Color; //Sets the font to the one selected in the dialog  
            }
        }

        private void findAndReplaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FindForm f = new FindForm(richTextBox1, listBox1);
        }

        private void goToLineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GoToForm goToForm = new GoToForm(richTextBox1);
        }



        private void richTextBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                if (richTextBox1.SelectedText != "")
                {
                    var x = richTextBox1.SelectedText;
                    ContextMenuStrip cm = new ContextMenuStrip();
                    var font = cm.Items.Add("Font");
                    font.Click += new EventHandler(Font_Clicked);
                    var color = cm.Items.Add("Color");
                    color.Click += new EventHandler(Color_Clicked);
                    var uppercase = cm.Items.Add("UpperCase");
                    uppercase.Click += new EventHandler(Uppercase_Clicked);
                    var lowercase = cm.Items.Add("LowerCase");
                    lowercase.Click += new EventHandler(Lowercase_Clicked);
                    var cut = cm.Items.Add("Cut");
                    cut.Click += new EventHandler(cut_Clicked);
                    var copy = cm.Items.Add("Copy");
                    copy.Click += new EventHandler(copy_Clicked);
                    var paste = cm.Items.Add("Paste");
                    paste.Click += new EventHandler(Paste_Clicked);
                    var copyAll = cm.Items.Add("Copy All");
                    copyAll.Click += new EventHandler(copyAll_Clicked);
                    var selectAll = cm.Items.Add("Select All");
                    selectAll.Click += new EventHandler(selectAll_Clicked);
                    // cm.add(Equals(Font), 1, Equals(Font), "Font");
                    cm.Show(richTextBox1, e.Location);

                    Console.WriteLine(x);
                }
                else
                {
                    var x = richTextBox1.SelectedText;
                    ContextMenuStrip cm = new ContextMenuStrip();
                    var paste = cm.Items.Add("Paste");
                    paste.Click += new EventHandler(Paste_Clicked);
                    var selectAll = cm.Items.Add("Select All");
                    selectAll.Click += new EventHandler(selectAll_Clicked);
                    var copyAll = cm.Items.Add("Copy All");
                    copyAll.Click += new EventHandler(copyAll_Clicked);


                    cm.Show(richTextBox1, e.Location);
                }
            }
        }

        private void selectAll_Clicked(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }

        private void cut_Clicked(object sender, EventArgs e)
        {

            richTextBox1.Cut();
        }

        private void copy_Clicked(object sender, EventArgs e)
        {
            richTextBox1.Copy();
            if (clipboardOn)
            {
                ch.AddItem();
            }

        }

        private void Paste_Clicked(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void copyAll_Clicked(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
            richTextBox1.Copy();
        }

        private void Lowercase_Clicked(object sender, EventArgs e)
        {
            richTextBox1.SelectedText = richTextBox1.SelectedText.ToLower();
        }

        private void Uppercase_Clicked(object sender, EventArgs e)
        {
            richTextBox1.SelectedText = richTextBox1.SelectedText.ToUpper();
        }

        private void Color_Clicked(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            //colorDialog.ShowDialog(); //Shows the font dialog   
            if (colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                richTextBox1.SelectionColor = colorDialog.Color; //Sets the font to the one selected in the dialog  
            }
        }

        private void Font_Clicked(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();
            //fontDialog.ShowDialog(); //Shows the font dialog   
            if (fontDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                richTextBox1.SelectionFont = fontDialog.Font; //Sets the font to the one selected in the dialog  
            }
        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            File_New_MenuItem_Click(sender, e);
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            //openFileDialog.ShowDialog(); //Shows the dialog   
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK && openFileDialog.FileName.Contains(".txt")) //Checks if it's all ok and if the file name contains .txt  
            {
                string open = File.ReadAllText(openFileDialog.FileName); //Reads the text from file  
                richTextBox1.Text = open; //Shows the reded text in the textbox  
            }
            else //If something goes wrong...  
            {
                MessageBox.Show("The file you've chosen is not a text file");
            }
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            //saveFileDialog.ShowDialog(); //Opens the Show File Dialog  
            if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK) //Check if it's all ok  
            {
                string name = saveFileDialog.FileName + ".txt"; //Just to make sure the extension is .txt  
                File.WriteAllText(name, richTextBox1.Text); //Writes the text to the file and saves it               
            }
        }

        private void cutToolStripButton_Click(object sender, EventArgs e)
        {

            richTextBox1.Cut();
        }

        private void richTextBox2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //string lineNumber = listBox1.SelectedText;

        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var selectedTab1 = tabFiles.SelectedTab;
            RichTextBox selectedRichTextBox1 = selectedTab1.Controls[0] as RichTextBox;

            selectedRichTextBox1.SelectionBackColor = Color.White;
            selectedRichTextBox1.SelectionFont = richTextBox1.Font;
            SearchedItems searchedItems = listBox1.SelectedItem as SearchedItems;
            if (searchedItems != null)
            {
                string file = searchedItems.path;
                if (files.ContainsKey(file))
                {
                    TabPage page = files[file];
                    RichTextBox rtb = page.Controls[0] as RichTextBox;
                    rtb.Text = File.ReadAllText(file);
                    tabFiles.SelectedTab = page;
                }
                else
                {
                    TabPage first = tabFiles.TabPages[0];
                    RichTextBox txt = first.Controls[1] as RichTextBox;
                    RichTextBox txt2 = first.Controls[0] as RichTextBox;
                    if (txt.TextLength == 0 && first.Text == "New")
                    {
                        FileInfo info = new FileInfo(file);
                        first.Text = info.Name;
                        txt.Text = File.ReadAllText(file);
                        files.Remove("New");
                        files[file] = first;
                        tabFiles.SelectedTab = first;
                    }
                    else
                    {
                        TabPage page = new TabPage();
                        RichTextBox rtb = new RichTextBox();
                        RichTextBox rtb2 = new RichTextBox();
                        page.Bounds = first.Bounds;
                        rtb.Bounds = txt.Bounds;
                        rtb2.Bounds = txt2.Bounds;
                        richTextBox = rtb;
                        lineTextBox = rtb2;
                        rtb2.ScrollBars = 0;
                        rtb.Click += richTextBox1_ClickTabs;
                        rtb.FontChanged += richTextBox1_FontChangedTabs;
                        rtb.SelectionChanged += richTextBox1_SelectionChangedTabs;
                        rtb.TextChanged += richTextBox1_TextChangedTabs;
                        rtb.VScroll += richTextBox1_VScrollTabs;
                        page.Controls.Add(rtb);
                        page.Controls.Add(rtb2);

                        FileInfo info = new FileInfo(file);
                        page.Text = info.Name;
                        rtb.Text = File.ReadAllText(file);
                        files[file] = page;
                        tabFiles.TabPages.Add(page);
                        tabFiles.SelectedTab = page;
                    }
                }
                AddLineNumbersTabs();
                int lineNumber = searchedItems.LineNumber;
                var selectedTab = tabFiles.SelectedTab;
                RichTextBox selectedRichTextBox = selectedTab.Controls[0] as RichTextBox;
                if (selectedRichTextBox.SelectionStart >= 0)
                {
                    selectedRichTextBox.SelectionStart = selectedRichTextBox.GetFirstCharIndexFromLine(lineNumber - 1);
                    selectedRichTextBox.SelectionLength = searchedItems.LineText.Count();
                    selectedRichTextBox.SelectionBackColor = Color.LightGreen;
                    selectedRichTextBox.ScrollToCaret();
                }
            }


        }

        private void searchInFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchInFileForm siff = new SearchInFileForm(listBox1);
        }

        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.Graphics.DrawString("x", e.Font, Brushes.Red, e.Bounds.Right - 14, e.Bounds.Top + 8);
            e.Graphics.DrawString(this.tabFiles.TabPages[e.Index].Text, e.Font, Brushes.Black, e.Bounds.Left + 16, e.Bounds.Top + 8);
            e.DrawFocusRectangle();
        }

        private void tabControl1_MouseDown(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < this.tabFiles.TabPages.Count; i++)
            {
                Rectangle r = tabFiles.GetTabRect(i);
                //Getting the position of the "x" mark.
                Rectangle closeButton = new Rectangle(r.Right - 14, r.Top + 8, 16, 8);
                if (closeButton.Contains(e.Location))
                {
                    if (MessageBox.Show("Would you like to save this file before closing?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        TabPage crt = tabFiles.SelectedTab;
                        RichTextBox rtb = crt.Controls[0] as RichTextBox;
                        string key = crt.Text;
                        foreach (string s in files.Keys)
                        {
                            if (files[s] == crt)
                            {
                                key = s;
                                break;
                            }
                        }
                        if (key.StartsWith("New") && !key.EndsWith(".txt"))
                        {
                            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                            saveFileDialog1.Filter = "(*.txt)|*.txt";
                            saveFileDialog1.Title = "Save a Text File";
                            saveFileDialog1.ShowDialog();

                            // If the file name is not an empty string open it for saving.  
                            if (saveFileDialog1.FileName != "")
                            {
                                if (files.ContainsKey(saveFileDialog1.FileName))
                                {
                                    MessageBox.Show("This file already is open");
                                    return;
                                }
                                // Saves the Image via a FileStream created by the OpenFile method.  
                                System.IO.FileStream fs = (System.IO.FileStream)saveFileDialog1.OpenFile();
                                byte[] bytes = Encoding.ASCII.GetBytes(rtb.Text);
                                fs.Write(bytes, 0, bytes.Length);
                                fs.Close();
                                FileInfo info = new FileInfo(saveFileDialog1.FileName);
                                crt.Text = info.Name;
                                files.Remove(key);
                                files[saveFileDialog1.FileName] = crt;
                            }
                        }
                        else
                        {
                            File.WriteAllText(key, rtb.Text);
                        }
                        this.tabFiles.TabPages.RemoveAt(i);
                        pageNumber--;
                        count--;
                        break;
                    }
                }
            }
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void LineNumberTextBox_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void searchInFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchInFolder sif = new SearchInFolder(listBox1);
        }

        private void cToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] keywords = {" foreach "," for ", " abstract ",   " as ",   " base ", " bool ", " break ",
                " byte ", " case ", " catch "," char ", " checked " ," class "," const "};
            richTextBox1.Select(0, richTextBox1.TextLength);
            richTextBox1.SelectionBackColor = richTextBox1.BackColor;
            richTextBox1.SelectionFont = richTextBox1.Font;

            int s_start = richTextBox1.SelectionStart, startIndex = 0, index;
            foreach (var i in keywords)
            {
                while ((index = richTextBox1.Text.IndexOf(i, startIndex)) != -1)
                {

                    richTextBox1.Select(index, i.Length);
                    richTextBox1.SelectionColor = Color.Blue;
                    richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Bold);
                    startIndex = index + i.Length;
                }
            }

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

            if (richTextBox1.Text == "")
            {
                AddLineNumbers();
            }
        }
        private void richTextBox1_TextChangedTabs(object sender, EventArgs e)
        {

            if (richTextBox.Text == "")
            {
                AddLineNumbersTabs();
            }
        }
        private void richTextBox1_VScroll(object sender, EventArgs e)
        {
            LineNumberTextBox.Text = "";
            AddLineNumbers();
            LineNumberTextBox.Invalidate();
        }
        private void richTextBox1_VScrollTabs(object sender, EventArgs e)
        {
            lineTextBox.Text = "";
            AddLineNumbersTabs();
            lineTextBox.Invalidate();
        }

        private void richTextBox1_SelectionChanged(object sender, EventArgs e)
        {
            this.Invalidate();
            Point pt = richTextBox1.GetPositionFromCharIndex(richTextBox1.SelectionStart);
            if (pt.X == 1)
            {
                AddLineNumbers();
            }
            richTextBox1.ForeColor = Color.Black;
        }
        private void richTextBox1_SelectionChangedTabs(object sender, EventArgs e)
        {
            this.Invalidate();
            Point pt = richTextBox.GetPositionFromCharIndex(richTextBox.SelectionStart);
            if (pt.X == 1)
            {
                AddLineNumbersTabs();
            }
            richTextBox.ForeColor = Color.Black;
        }

        private void richTextBox1_MouseClick_1(object sender, MouseEventArgs e)
        {

        }

        private void LineNumberTextBox_MouseDown(object sender, MouseEventArgs e)
        {
            //richTextBox1.Select();
            //LineNumberTextBox.DeselectAll();
        }

        private void LineNumberTextBox_FontChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_FontChanged(object sender, EventArgs e)
        {
            LineNumberTextBox.Font = richTextBox1.Font;
            AddLineNumbers();
        }
        private void richTextBox1_FontChangedTabs(object sender, EventArgs e)
        {
            lineTextBox.Font = richTextBox.Font;
            AddLineNumbersTabs();
        }

        private void columnEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColumnEditor columnEditor = new ColumnEditor(richTextBox1);
            columnEditor.Show();
        }

        private void clipboardHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clipboardOn = true;
            ch = new ClipboardHistory(richTextBox1);
        }

        private void sortLinesLexicographicallyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] linesAsStrings = new string[richTextBox1.Lines.Length]; // We'll store the strings in this array

            int i = 0; // Keep an index of where to place the incoming numbers
            foreach (var line in richTextBox1.Lines)
            {
                linesAsStrings[i++] = Convert.ToString(line); // Convert each line into a number and store it into our newly created array
            }
            Array.Sort(linesAsStrings); // It automatically sorts from lowest to highest
            richTextBox1.Text = String.Join<string>("\n", linesAsStrings);
        }

        private void sortLinesAsIntegersAscendingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int[] linesAsNumbers = new int[richTextBox1.Lines.Length]; // We'll store the numbers in this array

            int i = 0; // Keep an index of where to place the incoming numbers
            foreach (var line in richTextBox1.Lines)
            {
                linesAsNumbers[i++] = Convert.ToInt32(line); // Convert each line into a number and store it into our newly created array
            }
            Array.Sort(linesAsNumbers); // It automatically sorts from lowest to highest
            richTextBox1.Text = String.Join<int>("\n", linesAsNumbers);
        }

        private void sortLinesAsIntegersDescendingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int[] linesAsNumbers = new int[richTextBox1.Lines.Length]; // We'll store the numbers in this array

            int i = 0; // Keep an index of where to place the incoming numbers
            foreach (var line in richTextBox1.Lines)
            {
                linesAsNumbers[i++] = Convert.ToInt32(line); // Convert each line into a number and store it into our newly created array
            }
            Array.Sort(linesAsNumbers); // It automatically sorts from lowest to highest
            Array.Reverse(linesAsNumbers);
            richTextBox1.Text = String.Join<int>("\n", linesAsNumbers);
        }

        private void sortLinesLexicographicallyDescendingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] linesAsStrings = new string[richTextBox1.Lines.Length]; // We'll store the numbers in this array

            int i = 0; // Keep an index of where to place the incoming strings
            foreach (var line in richTextBox1.Lines)
            {
                linesAsStrings[i++] = Convert.ToString(line); // Convert each line into a number and store it into our newly created array
            }
            Array.Sort(linesAsStrings); // It automatically sorts from lowest to highest
            Array.Reverse(linesAsStrings);
            richTextBox1.Text = String.Join<string>("\n", linesAsStrings);
        }

        private void LineNumberTextBox_TextChanged_2(object sender, EventArgs e)
        {

        }
    }

}
