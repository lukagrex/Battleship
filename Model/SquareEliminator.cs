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
            if (startRow > 1)
            {
                --startRow;
            }

            int endRow = shipSquares.Last().Row;
            if (endRow < rows - 1)
            {
                ++endRow;
            }


            int startColumn = shipSquares.First().Column;
            if (startColumn > 1)
            {
                --startColumn;
            }

            int endColumn = shipSquares.Last().Column;
            if (endRow < columns - 1)
            {
                ++endRow;
            }

            List<Square> result = new List<Square>();

            for (int r = startRow; r <= endRow; r++)
            {
                for (int c = startColumn; c <= endColumn; c++)
                {
                    result.Add(new Square(r, c));
                }
            }

            return result;
        }

        private readonly int rows;
        private readonly int columns;

        private IEnumerable<Square> SquaresToEliminateHorizontalShip(bool leftSideIncluded, List<Square> squaresToEliminate, Square firstShipSquare,
            bool rightSideIncluded, Square lastShipSquare, bool upperSideIncluded, bool downSideIncluded)
        {
            if (leftSideIncluded)
            {
                squaresToEliminate.Add(new Square(firstShipSquare.Row, firstShipSquare.Column - 1));
            }

            if (rightSideIncluded)
            {
                squaresToEliminate.Add(new Square(lastShipSquare.Row, lastShipSquare.Column + 1));
            }

            var firstIndex = leftSideIncluded ? firstShipSquare.Column - 1 : firstShipSquare.Column;
            var lastIndex = rightSideIncluded ? lastShipSquare.Column + 1 : lastShipSquare.Column;

            if (upperSideIncluded)
            {
                AddingSquaresToEliminate(ref squaresToEliminate, firstIndex, lastIndex,
                    i => new Square(firstShipSquare.Row - 1, i));
            }

            if (downSideIncluded)
            {
                AddingSquaresToEliminate(ref squaresToEliminate, firstIndex, lastIndex,
                    i => new Square(firstShipSquare.Row + 1, i));
            }

            return squaresToEliminate;
        }

        private IEnumerable<Square> SquaresToEliminateVerticalShip(bool upperSideIncluded, List<Square> squaresToEliminate, Square firstShipSquare,
            bool downSideIncluded, Square lastShipSquare, bool leftSideIncluded, bool rightSideIncluded)
        {
            if (upperSideIncluded)
            {
                squaresToEliminate.Add(new Square(firstShipSquare.Row - 1, firstShipSquare.Column));
            }

            if (downSideIncluded)
            {
                squaresToEliminate.Add(new Square(lastShipSquare.Row + 1, lastShipSquare.Column));
            }

            var firstIndex = upperSideIncluded ? firstShipSquare.Row - 1 : firstShipSquare.Row;
            var lastIndex = downSideIncluded ? lastShipSquare.Row + 1 : lastShipSquare.Row;

            if (leftSideIncluded)
            {
                AddingSquaresToEliminate(ref squaresToEliminate, firstIndex, lastIndex,
                    i => new Square(i, firstShipSquare.Column - 1));
            }

            if (rightSideIncluded)
            {
                AddingSquaresToEliminate(ref squaresToEliminate, firstIndex, lastIndex,
                    i => new Square(i, firstShipSquare.Column + 1));
            }

            return squaresToEliminate;
        }

        private void AddingSquaresToEliminate(ref List<Square> squaresToEliminate, int start, int stop, Func<int, Square> getSquareFunc)
        {
            for (int i = start; i <= stop; i++)
            {
                squaresToEliminate.Add(getSquareFunc(i));
            }
        }
    }
}
