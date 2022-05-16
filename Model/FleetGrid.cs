using System;
using System.Collections.Generic;
using System.Linq;

namespace Model
{

    public class FleetGrid : Grid
    {
        public FleetGrid(int rows, int columns) : base(rows, columns)
        {
        }

        public void EliminateSquare(int row, int column)
        {
            squares[row, column] = null;
        }

        protected override bool IsSquareAvailable(Func<int, int, Square> squareSelect, int row, int column)
        {
            return squareSelect(row, column) != null;
        }
    }
}
