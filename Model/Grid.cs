using System.Collections.Generic;
using System.Linq;

namespace Vsite.Battleship.Model
{
    using SquareSequence = IEnumerable<Square>;
    public class Grid
    {
        public readonly int Rows;
        public readonly int Columns;

        private Square[,] squares;


        public Grid(int rows, int columns)
        {
            this.Rows = rows;
            this.Columns = columns;
            this.squares = new Square[Rows, Columns];

            for (int r = 0; r < Rows; ++r)
            {
                for (int c = 0; c < Columns; ++c)
                {
                    squares[r, c] = new Square(r, c);
                }
            }

        }
        public IEnumerable<Square> Squares
        {
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

            for (int r = 0; r < Rows; ++r)
            {
                int squaresInSequence = 0;

                for (int c = 0; c < Columns; ++c)
                {
                    if (squares[r, c] != null)
                    {
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
                    else squaresInSequence = 0;
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
                        ++squaresInSequence;
                        if (squaresInSequence >= length)
                        {
                            List<Square> s = new List<Square>();

                            for (int cc = r - length + 1; cc <= r; ++cc)
                            {
                                s.Add(squares[cc, c]);
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

        class LoopIndex
        {
            public LoopIndex(int outerBound, int innerBound)
            {
                this.outerBound = outerBound;
                this.innerBound = innerBound;
            }

            private int outerBound;
            private int innerBound;

            public IEnumerable<int> Outer()
            {
                for (int i = 0; i < outerBound; ++i)
                {
                    yield return i;
                }
            }
            public IEnumerable<int> Inner()
            {
                for (int i = 0; i < innerBound; ++i)
                {
                    yield return i;
                }
            }

        }

        private IEnumerable<SquareSequence> GetPlacements(int length, LoopIndex loopIndex)
        {
            List<SquareSequence> result = new List<SquareSequence>();

            foreach (int o in loopIndex.Outer())
            {
                List<SquareSequence> queue = new List<SquareSequence>();
                foreach (int i in loopIndex.Inner())
                {
                    if (squares[o, i] != null)
                    {
                        queue.Enqueue(squares);
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
                    else squaresInSequence = 0;
                }


            }

            return result;
        }


    }
}
