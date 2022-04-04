using System;
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

            return isVertical ?
            SquaresToEliminateVerticalShip(upperSideIncluded, squaresToEliminate, firstShipSquare, downSideIncluded, lastShipSquare, leftSideIncluded, rightSideIncluded)
            :
            SquaresToEliminateHorizontalShip(leftSideIncluded, squaresToEliminate, firstShipSquare, rightSideIncluded, lastShipSquare, upperSideIncluded, downSideIncluded);
        }

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
