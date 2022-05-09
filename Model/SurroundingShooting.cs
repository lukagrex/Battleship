using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vsite.Battleship.Model
{
    public class SurroundingShooting : INextTarget
    {
        public SurroundingShooting(Grid grid, Square firstSquareHit, int shipLength)
        {
            this.grid = grid;
            this.firstSquareHit = firstSquareHit;
            this.shipLength = shipLength;
        }

        private Grid grid;
        private readonly Square firstSquareHit;
        private readonly int shipLength;
        public Square NextTarget()
        {
            int row = firstSquareHit.Row;
            int column = firstSquareHit.Column;
            var candidates = grid.Squares.Where(s => s.SquareState == SquareState.Initial
                                                     && ((s.Row == row && (s.Column == column - 1 || s.Column == column + 1)) 
                                                     || (s.Column == column && (s.Row == row - 1 || s.Row == row + 1))));

            if (!candidates.Any()) return null;

            return candidates.FirstOrDefault();
        }
    }
}
