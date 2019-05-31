using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextEditor
{
    public class SearchedItems
    {
        
        public int LineNumber { get; set; }
        public string LineText { get; set; }
        public bool findForm { get; set; }
        public string path { get; set; }
        public override string ToString()
        {
            return "Line " + LineNumber + ": " + LineText + "\n";
        }
    }
}
