using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class SquareEliminator
    {
        private readonly int rows;
        private readonly int columns;

        public SquareEliminator(int rows, int columns)
        {
            this.rows = rows;
            this.columns = columns;
        }

        public IEnumerable<Square> ToEliminate(IEnumerable<Square> shipSquares)
        {
            int startRow = shipSquares.First().Row;
            if (startRow > 0)
            {
                --startRow;
            }

            int endrow = shipSquares.Last().Row;
            if (endrow < rows - 1)
            {
                ++endrow;
            }

            int startColumn = shipSquares.First().Column;
            if (startColumn > 0)
            {
                --startColumn;
            }

            int endColumn = shipSquares.Last().Column;
            if (endColumn < columns - 1)
            {
                ++endColumn;
            }

            List<Square> result = new List<Square>();

            for (int r = startRow; r <= endrow; r++)
            {
                for (int c = startColumn; c <= endColumn; c++)
                {
                    result.Add(new Square(r,c));
                }
            }

            return result;
        }
    }
}
