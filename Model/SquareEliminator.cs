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
            HashSet<Square> eliminated = new HashSet<Square>();
            foreach (var square in shipSquares)
            {
                for (int i = Math.Max(square.Row - 1, 0); i <= Math.Min(square.Row + 1, rows - 1); ++i)
                {
                    for (int j = Math.Max(square.Column - 1, 0); j <= Math.Min(square.Column + 1, columns - 1); ++j)
                    {
                        eliminated.Add(new Square(i, j));
                    }
                }
            }
            return eliminated;
        }

        private readonly int rows;
        private readonly int columns;
    }
}
