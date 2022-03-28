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
            this.Rows = rows;
            this.Columns = columns;
            squares = new Square[rows, columns];
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < columns; c++)
                {
                    squares[r, c] = new Square(r, c);
                }
            }
        }

        public IEnumerable<Square> Squares
        {
            // Cast -> casts 2D squares array into 1D array
            get { return squares.Cast<Square>().Where(s => s != null); }
        }

        public void EliminateSquare(int row, int column)
        {
            squares[row, column] = null;
        }

        public IEnumerable<SquareSequence> GetAvailablePlacements(int length)
        {
            return GetHorizontalPlacements(length).Concat(GetVerticalPlacements(length));
        }
        
        private IEnumerable<SquareSequence> GetHorizontalPlacements(int length)
        {
            List<SquareSequence> result = new List<SquareSequence>();
            for (int r = 0; r< Rows; r++)
            {
                int squaresInSequence = 0;
                for(int c = 0; c < Columns; c++)
                {
                    if (squares[r, c] != null)
                    {
                        squaresInSequence++;
                        if(squaresInSequence >= length)
                        {
                            List<Square> s = new List<Square>();
                            for(int cc = c - length + 1; cc<=c; cc++)
                            {
                                s.Add(squares[r, cc]);
                            }
                            result.Add(s);
                        }
                    }
                    else
                        squaresInSequence = 0;
                }
            }

            return result;
        }

        private IEnumerable<SquareSequence> GetVerticalPlacements(int length)
        {
            List<SquareSequence> result = new List<SquareSequence>();
            for (int c = 0; c < Columns; c++)
            {
                int squaresInSequence = 0;
                for (int r = 0; r < Rows; r++)
                {
                    if (squares[r, c] != null)
                    {
                        squaresInSequence++;
                        if (squaresInSequence >= length)
                        {
                            List<Square> s = new List<Square>();
                            for (int rr = r - length + 1; rr <= r; rr++)
                            {
                                s.Add(squares[rr, c]);
                            }
                            result.Add(s);
                        }
                    }
                    else
                        squaresInSequence = 0;
                }
            }

            return result;
        }


        public readonly int Rows;
        public readonly int Columns;

        private Square[,] squares;
    }
}
