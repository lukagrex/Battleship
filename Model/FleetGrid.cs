using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        protected override bool IsSquareAvailable(Square square)
        {
            return square != null;
        }
    }
}
