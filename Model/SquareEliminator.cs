using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vsite.BattleShip.Model
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

        public IEnumerable<Square> ToEliminate(IEnumerable<Square> shipsSquares)
        {
            //throw new NotImplementedException();
            int firstRow = shipsSquares.First().Row;
            if (firstRow > 0)
            {
                --firstRow;
            }

            int lastRow = shipsSquares.Last().Row;
            if (lastRow < rows - 1)
            {
                ++lastRow;
            }

            int firstColumn = shipsSquares.First().Column;
            if (firstColumn > 0)
            {
                --firstColumn;
            }

            int lastColumn = shipsSquares.Last().Column;
            if (lastColumn < columns - 1)
            {
                ++lastColumn;
            }

            List<Square> result = new List<Square>();
            for (int i = firstRow; i < lastRow; ++i)
            {
                for (int j = firstColumn; j < lastColumn; ++j)
                {
                    result.Add(new Square(i, j));
                }
            }

            return result;
        }
    }
}
