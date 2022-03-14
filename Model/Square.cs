using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Square
    {
        public Square(int row, int column)
        {
            this.Row = row;
            this.Column = column;
        }

        public readonly int Row;
        public readonly int Column;
    }
}
