using System.Collections.Generic;
using System.Linq;

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
            var toEliminateSquares = new List<Square>();
            var ii = new List<int>() { -1, 0, 1 };
            foreach (var shipSquare in shipSquares)
            {
                foreach (var i in ii)
                {
                    foreach (var j in ii)
                    {
                        // Do not eliminate squares out of boundaries
                        if (shipSquare.Row + i >= rows || shipSquare.Row + i < 0 ||
                            shipSquare.Column + j >= columns || shipSquare.Column + j < 0)
                        {
                            continue;
                        }
                        toEliminateSquares.Add(new Square(shipSquare.Row + i, shipSquare.Column + j));
                    }
                }
            }

            return toEliminateSquares.Distinct();
        }

        private readonly int rows;
        private readonly int columns;
    }
}
