using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vsite.Battleship.Model
{
    using SquareSequence = IEnumerable<Square>;

    public abstract class Grid
    {
        public Grid(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            squares = new Square[Rows, Columns];
            for (int r = 0; r < Rows; ++r)
            {
                for (int c = 0; c < Columns; ++c)
                {
                    squares[r, c] = new Square(r, c);
                }
            }
        }

        public Square GetSquare(int row, int column)
        {
            return squares[row, column];
        }

        public IEnumerable<Square> Squares
        {
            get { return squares.Cast<Square>().Where(s => s != null); }
        }

        public IEnumerable<SquareSequence> GetAvailablePlacements(int length)
        {
            return GetPlacements(length, new LoopIndex(Rows, Columns), (i, j) => squares[i, j])
                .Concat(GetPlacements(length, new LoopIndex(Columns, Rows), (i, j) => squares[j, i])).Where(pl => pl.Count() > 0);

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

            private int outerBound;
            private int innerBound;
        }

        private IEnumerable<SquareSequence> GetPlacements(int length, LoopIndex loopIndex, Func<int, int, Square> squareSelect)
        {
            List<SquareSequence> result = new List<SquareSequence>();

            foreach (int o in loopIndex.Outer())
            {
                LimitedQueue<Square> lqueue = new LimitedQueue<Square>(length);
                foreach (int i in loopIndex.Inner())
                {
                    if (IsSquareAvailable(o, i, squareSelect))
                    {
                        lqueue.Enqueue(squareSelect(o, i));
                        if (lqueue.Count >= length)
                        {
                            result.Add(lqueue.ToArray());
                        }
                    }
                    else
                        lqueue.Clear();
                }
            }
            return result;
        }

        protected abstract bool IsSquareAvailable(int i1, int i2, Func<int, int, Square> squareSelect);

        public readonly int Rows;
        public readonly int Columns;

        protected Square[,] squares;
    }
}
