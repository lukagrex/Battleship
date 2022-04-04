using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vsite.Battleship.Model
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
            int startRow = shipSquares.First().Row;
            if (startRow > 0)
                --startRow;
            int endRow = shipSquares.Last().Row;
            if (endRow < rows - 1)
                ++endRow;

            int startColumn = shipSquares.First().Column;
            if (startColumn > 0)
                --startColumn;
            int endColumn = shipSquares.Last().Column;
            if (endColumn < columns - 1)
                ++endColumn;

            List<Square> eliminated = new List<Square>();
            for (int r = startRow; r <= endRow; ++r)
            {
                for (int c = startColumn; c <= endColumn; ++c)
                {
                    eliminated.Add(new Square(r, c));
                }
            }

            return eliminated;
        }

        private readonly int rows;
        private readonly int columns;
    }
}
