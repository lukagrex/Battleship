using System;
using System.Collections.Generic;
using System.Linq;

namespace Model
{

    public class FleetGrid : Grid
    {
        public FleetGrid(int numOfRows, int numOfColumns) : base(numOfRows, numOfColumns)
        {
        }

        protected override bool IsSquareAvailable(Square selectedSquare)
        {
            return selectedSquare != null;
        }

        public void EliminateSquare(int row, int column)
        {
            if (row < 0 || column < 0 || row >= numOfRows || column >= numOfColumns)
            {
                throw new ArgumentException("index is out of grid");
            }

            squares[row, column] = null;
        }

    }
}
