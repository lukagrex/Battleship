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

        private readonly int rows;
        private readonly int columns;

        public IEnumerable<Square> ToEliminate(IEnumerable<Square> shipSquares)
        {
            var squaresToEliminate = new List<Square>(shipSquares);
            var firstShipSquare = shipSquares.First();
            var lastShipSquare = shipSquares.Last();
            var isVertical = firstShipSquare.Column == lastShipSquare.Column;
            var leftSideIncluded = firstShipSquare.Column != 0;
            var rightSideIncluded = lastShipSquare.Column != columns - 1;
            var upperSideIncluded = firstShipSquare.Row != 0;
            var downSideIncluded = lastShipSquare.Row != rows - 1;


            if (isVertical)
            {
                if (upperSideIncluded)
                {
                    squaresToEliminate.Add(new Square(firstShipSquare.Row - 1, firstShipSquare.Column));
                }

                if (downSideIncluded)
                {
                    squaresToEliminate.Add(new Square(lastShipSquare.Row + 1, lastShipSquare.Column));
                }

                if (leftSideIncluded)
                {
                    var firstIndex = upperSideIncluded ? firstShipSquare.Row - 1 : firstShipSquare.Row;
                    var lastIndex = downSideIncluded ? lastShipSquare.Row + 1 : lastShipSquare.Row;
                    for (int i = firstIndex; i <= lastIndex; i++)
                    {
                        squaresToEliminate.Add(new Square(i, firstShipSquare.Column - 1));
                    }
                }

                if (rightSideIncluded)
                {
                    var firstIndex = upperSideIncluded ? firstShipSquare.Row - 1 : firstShipSquare.Row;
                    var lastIndex = downSideIncluded ? lastShipSquare.Row + 1 : lastShipSquare.Row;
                    for (int i = firstIndex; i <= lastIndex; i++)
                    {
                        squaresToEliminate.Add(new Square(i, firstShipSquare.Column + 1));
                    }
                }
            }
            else
            {
                if (leftSideIncluded)
                {
                    squaresToEliminate.Add(new Square(firstShipSquare.Row, firstShipSquare.Column - 1));
                }
                if (rightSideIncluded)
                {
                    squaresToEliminate.Add(new Square(lastShipSquare.Row, lastShipSquare.Column + 1));
                }

                if (upperSideIncluded)
                {
                    var firstIndex = leftSideIncluded ? firstShipSquare.Column - 1 : firstShipSquare.Column;
                    var lastIndex = rightSideIncluded ? lastShipSquare.Column + 1 : lastShipSquare.Column;
                    for (int i = firstIndex; i <= lastIndex; i++)
                    {
                        squaresToEliminate.Add(new Square(firstShipSquare.Row - 1, i));
                    }
                }

                if (downSideIncluded)
                {
                    var firstIndex = leftSideIncluded ? firstShipSquare.Column - 1 : firstShipSquare.Column;
                    var lastIndex = rightSideIncluded ? lastShipSquare.Column + 1 : lastShipSquare.Column;
                    for (int i = firstIndex; i <= lastIndex; i++)
                    {
                        squaresToEliminate.Add(new Square(firstShipSquare.Row + 1, i));
                    }
                }
            }

            return squaresToEliminate;
        }
    }
}
