using System;
using System.Collections.Generic;

namespace Vsite.Battleship.Model
{
    public class SquareEliminator
    {
        public SquareEliminator(int rows, int columns)
        {
            this.rows = rows;
            this.columns = columns;
        }

        private readonly int rows;
        private readonly int columns;

        public IEnumerable<Square> ToEliminate(IEnumerable<Square> shipSquares)
        {
            throw new NotImplementedException();
        }
    }
}
