using System;
using System.Collections.Generic;
using System.Linq;

namespace Vsite.BattleShip.Model
{
    public class SquareEliminator
    {
        public SquareEliminator(int rows, int columns)
        {
            this.rows = rows;
            this.columns = columns;
        }

        public IEnumerable<Square> ToEliminate(IEnumerable<Square> shipSquares)
        {
            throw new NotImplementedException();
        }

        private readonly int rows;
        private readonly int columns;
    }
}
