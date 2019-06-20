using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextEditor
{
    public interface IUndoRedoCommand
    {
        void UndoWords();
        void RedoWords();
        void UndoLetters();
        void RedoLetters();
    }
    
}
