using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryGame.Logic
{
    public class BoardCell
    {
        public char Value { get; set; }
        public bool IsExposed { get; set; }

        public BoardCell(char value)
        {
            Value = value;
            IsExposed = false;
        }
    }

}
