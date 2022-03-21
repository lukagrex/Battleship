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
            return null;
        }
    }
}
