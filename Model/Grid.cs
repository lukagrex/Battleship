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
                var listFound = new LimitedQueue<Square>(shipSize);

                for (int column = 0; column < this.numOfColumns; column++)
                {
                    if (squares[row, column] != null)
                    {
                        listFound.Enqueue(squares[row, column]);

                        if (listFound.Count == shipSize)
                        {
                            availableSquares.Add(listFound);
                        }
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
                var listFound = new LimitedQueue<Square>(shipSize);

                for (int row = 0; row < this.numOfRows; row++)
                {
                    if (squares[row, column] != null)
                    {
                        listFound.Enqueue(squares[row, column]);

                        if (listFound.Count == shipSize)
                        {
                            availableSquares.Add(listFound);
                        }
                    }
                }
            }

            return availableSquares;
        }

    }
}
