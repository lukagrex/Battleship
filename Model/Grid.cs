using System;
using System.Collections.Generic;
using System.Linq;

namespace Model
{
    using SquareSequence = IEnumerable<Square>;

    public abstract class Grid
    {
        protected readonly Square[,] squares;

        public Grid(int rows, int columns)
        {
            this.Rows = rows;
            this.Columns = columns;
            this.squares = new Square[this.Rows, this.Columns];
            for (int r = 0; r < this.Rows; ++r)
            {
                for (int c = 0; c < this.Columns; ++c)
                {
                    this.squares[r, c] = new Square(r, c);
                }
            }
        }

        public int Columns { get; set; }

        public int Rows { get; set; }


        public SquareSequence Squares
        {
            get
            {
                return this.squares
                    .Cast<Square>()
                    .Where(s => s != null);
            }
        }

        public IEnumerable<SquareSequence> GetAvailablePlacements(int length)
        {
            return GetPlacements(length, new LoopIndex(Rows, Columns), (i, j) =>
                    this.squares[i, j])
                .Concat(GetPlacements(length, new LoopIndex(Columns, Rows), (i, j) =>
                    this.squares[j, i]))
                .Where(pl => pl.Count() != 0);
        }

        public void EliminateSquare(int row, int column)
        {
            this.squares[row, column] = null;
        }

        private IEnumerable<SquareSequence> GetPlacements(int length, LoopIndex loopIndex, Func<int, int, Square> squareSelect)
        {
            var result = new List<SquareSequence>();
            foreach (var o in loopIndex.Outer())
            {
                var queue = new LimitedQueue<Square>(length);
                foreach (var i in loopIndex.Inner())
                {
                    if (IsSquareAvailable(squareSelect, o, i))
                    {
                        queue.Enqueue(squareSelect(o, i));
                        if (queue.Count >= length)
                        {
                            result.Add(queue.ToArray());
                        }
                    }
                    else
                    {
                        queue.Clear();
                    }
                }
            }

            return result;
        }

        public abstract bool IsSquareAvailable(Func<int, int, Square> squareSelect, int row, int column);

    }
}