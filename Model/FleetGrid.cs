using System;
using System.Collections.Generic;
using System.Linq;

namespace Model
{

    public class FleetGrid : Grid
    {
        private readonly Square[,] squares;

        public FleetGrid(int rows, int columns) : base(rows, columns)
        {
            
        }

        public readonly int Rows;
        public readonly int Columns;

        public void EliminateSquare(int row, int column)
        {
            this.squares[row, column] = null;
        }

        public override bool IsSquareAvailable(Func<int, int, Square> squareSelect, int row, int column)
        {
            return squareSelect(row, column) != null;
        }
    }
}
