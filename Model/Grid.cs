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

        public void EliminateSquare(int row, int column)
        {
            squares[row, column] = null;
        }

        public IEnumerable<Square> squares 
        {
            get{ squares.Cast<Square>().Where(s => s != null); }
        }

        public IEnumerable<Square> GetAvailablePlacements(int length)
        {
            return GetHorizontalPlacements(length).Concat(GetVerticalPlacements(length))
        }

        public IEnumerable<Square> GetHorizontalPlacements(int length)
        {
            List<SquareSequence> result = new List<SquareSequence> ();

            for(int i = 0; i < Rows; i++)
            {
                int squaresInSequence = 0;
                for(var j = 0; j < Columns; j++)
                {
                    if(squares[i, j] != null)
                    {
                        squaresInSequence++;
                        if(squaresInSequence >= length) 
                        { 
                            List<Square> s = new List<Square>();

                            for(int k = j - length; k <= j; ++k)
                            {
                                s.Add(new Square(i, k));
                            }
                            result.Add(s);
                        }
                    }
                    else
                    {
                        squaresInSequence = 0;
                    }
                }
            }
            return result;
        }

        public IEnumerable<Square> GetVerticalPlacements(int length)
        {
            List<SquareSequence> result = new List<SquareSequence>();
            return result;
        }

        public readonly int Rows;
        public readonly int Columns;

        private Square[,] squares;
    }
}
