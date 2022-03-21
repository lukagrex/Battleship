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
            for (int r=0; r<Rows; ++r)
            {
                for (int c = 0; c< Columns; ++c)
                {
                    squares[r, c] = new Square(r, c);
                }
            }
        }

        public IEnumerable<Square> Squares
        {
            get { return squares.Cast<Square>().Where(s => s != null); }
        }

        public IEnumerable<SquareSequence> GetAvailablePlacements(int length)
        {
            return GetHorizontalPlacements(length).Concat(GetVerticalPlacements(length));
        }
        private IEnumerable<SquareSequence> GetHorizontalPlacements(int length)
        {
            List<SquareSequence> result = new List<SquareSequence>();
            for (int r = 0; r< Rows; ++r)
            {
                int squaresInSequence = 0;
                for (int c = 0; c< Columns; ++c)
                {
                    if (squares[r, c] != null)
                    {
                        //umjesto ovog pomocu Queue napraviti da se ne provjerava duplo
                        //znaci ako je duljina jednaka prekopiraj sve elemente u kju
                        ++squaresInSequence;
                        if (squaresInSequence >= length)
                        {
                            List<Square> s = new List<Square>();
                            for (int cc = c - length + 1; cc <= c; ++cc)
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
            return result;
            //TODO for homework
        }

        public readonly int Rows;
        public readonly int Columns;

        private Square[,] squares;
    }
}
