using System.Collections.Generic;
using System.Linq;

namespace Vsite.Battleship.Model
{
    using SquareSequence = IEnumerable<Square>;
    public class Grid
    {

        private Square[,] squares;

        public IEnumerable<Square> Squares
        {
            get
            {
                return this.squares.Cast<Square>().Where(s => s != null);
            }
        }

        public readonly int numOfRows;
        public readonly int numOfColumns;

        public Grid(int numOfRows, int numOfColumns)
        {
            this.numOfColumns = numOfColumns;
            this.numOfRows = numOfRows;

            this.CreateGrid();
        }

        private void CreateGrid()
        {
            squares = new Square[numOfRows, numOfColumns];

            for (int row = 0; row < numOfRows; row++)
            {
                for (int column = 0; column < numOfColumns; column++)
                {
                    squares[row, column] = new Square(row, column);
                }
            }
        }

        public IEnumerable<SquareSequence> GetAvailablePlacements(int shipSize)
        {
            return this.GetHorizontalPlacements(shipSize).Concat(this.GetVerticalPlacements(shipSize));
        }

        private IEnumerable<SquareSequence> GetHorizontalPlacements(int shipSize)
        {
            var availableSquares = new List<SquareSequence>();

            for (int row = 0; row < this.numOfRows; row++)
            {
                int squareInSequence = 0;
                for (int column = 0; column < this.numOfColumns; column++)
                {
                    if (squares[row, column] != null)
                    {
                        squareInSequence++;
                        if (squareInSequence >= shipSize)
                        {
                            var listFound = new List<Square>(shipSize);
                            for (int i = column - squareInSequence + 1; i <= column; i++)
                            {
                                listFound.Add(squares[row, i]);
                            }

                            availableSquares.Add(listFound);
                        }
                    }
                    else
                    {
                        squareInSequence = 0;
                    }
                }
            }

            return availableSquares;
        }

        private IEnumerable<SquareSequence> GetVerticalPlacements(int shipSize)
        {
            var availableSquares = new List<SquareSequence>();
            for (int column = 0; column < this.numOfColumns; column++)
            {
                int squareInSequence = 0;

                for (int row = 0; row < this.numOfRows; row++)
                {

                    if (squares[row, column] != null)
                    {
                        squareInSequence++;

                        if (squareInSequence >= shipSize)
                        {
                            var listFound = new List<Square>(shipSize);
                            for (int i = row - squareInSequence + 1; i <= row; i++)
                            {
                                listFound.Add(squares[i, column]);
                            }

                            availableSquares.Add(listFound);
                        }
                    }
                    else
                    {
                        squareInSequence = 0;
                    }
                }
            }

            return availableSquares;
        }

    }
}
