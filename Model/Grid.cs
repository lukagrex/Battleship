using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vsite.Battleship.Model
{
    using SquareSequence = IEnumerable<Square>;

    public class Grid
    {
        public Grid(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            squares = new Square[Rows, Columns];

            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    squares[i, j] = new Square(i, j);
                }
            }
        }

        public IEnumerable<Square> squares 
        {
            get
            {
                squares.Cast<Square>().Where(s => s != null);
            }
        }

        public IEnumerable<Square> GetAvailablePlacements(int length)
        {
            throw new NotImplementedException();
        }

        public readonly int Rows;
        public readonly int Columns;

        private Square[,] squares;
    }
}
