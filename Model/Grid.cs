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

        public void EliminateSquare(int row, int column)
        {
            squares[row, column] = null;
        }
        public IEnumerable<Square> Squares
        {
            get { return squares.Cast<Square>().Where(s => s != null); }
        }

        public IEnumerable<SquareSequence> GetAvailablePlacements(int length)
        {
            //return GetHorizontalPlacements(length).Concat(GetVerticalPlacements(length));
            return GetPlacements(length, new LoopIndex(Rows, Columns), (i, j) => squares[i, j])
                .Concat(GetPlacements(length, new LoopIndex(Columns, Rows), (i, j) => squares[j, i]));
        }

        class LoopIndex
        {
            public LoopIndex(int outerBound, int innerBound)
            {
                this.outerBound = outerBound;
                this.innerBound = innerBound;
            }

            public IEnumerable<int> Outer()
            {
                for (int i = 0; i < outerBound; ++i)
                    yield return i;
            }

            public IEnumerable<int> Inner()
            {
                for (int i = 0; i < innerBound; ++i)
                    yield return i;
            }

            private int outerBound;
            private int innerBound;
        }

        private IEnumerable<SquareSequence> GetPlacements(int length, LoopIndex loopIndex, Func<int, int, Square> squareSelect)
        {
            List<SquareSequence> result = new List<SquareSequence>();

            foreach (int o in loopIndex.Outer())
            {
                int squaresInSequence = 0;
                foreach (int i in loopIndex.Inner())
                {
                    if (squareSelect(0,i) != null)
                    {
                        //umjesto ovog pomocu Queue napraviti da se ne provjerava duplo
                        //znaci ako je duljina jednaka prekopiraj sve elemente u kju
                        ++squaresInSequence;
                        if (squaresInSequence >= length)
                        {
                            List<Square> s = new List<Square>();
                            for (int cc = i - length + 1; cc <= i; ++cc)
                            {
                                s.Add(squares[o, cc]);
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
