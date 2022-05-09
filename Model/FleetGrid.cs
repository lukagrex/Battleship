using System;

namespace Vsite.Battleship.Model
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

        protected override bool IsSquareAvailable(int i1, int i2, Func<int, int, Square> squareSelect)
        {
            return squareSelect(i1, i2) != null;
        }
    }
}
