using System;
using System.Collections.Generic;
using System.Linq;

namespace Vsite.BattleShip.Model
{
    using SquareSequence = IEnumerable<Square>;

    public class Grid
    {
        public readonly int Rows;
        public readonly int Columns;    


        private Square[,] squares;

        public Grid (int rows, int columns)
        {
            this.Rows = rows;
            this.Columns = columns;
            this.squares = new Square[Rows, Columns];

            for (var r = 0; r < Rows; ++r)
            {
                for (var c = 0; c < Columns; ++c)
                {
                    this.squares[r, c] = new Square(r, c);
                }
            }
        }

        public void EliminateSquares(int row, int column)
        {
            squares[row, column] = null;
        }

        public void ChangeSquareState(int row, int column, SquareState newState)
        {
            squares[row, column].ChangeState(newState);
        }

        public IEnumerable<Square> Squares
        {
            get { return squares.Cast<Square>().Where(s => s != null); }
        }

        public IEnumerable<SquareSequence> GetAvailablePlacements(int length)
        {
            return this.GetPlacements(length, new LoopIndex(this.Rows, this.Columns),(i, j) => squares[i,j])
                       .Concat(this.GetPlacements(length, new LoopIndex(this.Columns, this.Rows), (i, j) => squares[j, i]));
        }

        private class LoopIndex
        {
            private int outerBound;
            private int innerBound;



            public LoopIndex(int outerBound, int innerBound)
            {
                this.outerBound = outerBound;
                this.innerBound = innerBound;
            }

            public IEnumerable<int> Outer()
            {
                for (int i = 0; i < this.outerBound; ++i)
                {
                    yield return i;
                }
            }

            public IEnumerable<int> Inner()
            {
                for (int i = 0; i < this.innerBound; ++i)
                {
                    yield return i;
                }
            }
        }

        private IEnumerable<SquareSequence> GetPlacements(int length, LoopIndex loopIndex, Func<int,int, Square> squareSelect)
        {
            var availableSquares = new List<SquareSequence>();
            foreach (var o in loopIndex.Outer())
            {
                var queue = new LimitedQueue<Square>(length);
                foreach (var i in loopIndex.Inner())
                {
                    if (squareSelect(o, i) != null)
                    {
                        queue.Enqueue(squareSelect(o, i));
                        if (queue.Count >= length)
                        {
                            availableSquares.Add(queue);
                        }
                    }
                    else
                    {
                        queue = new LimitedQueue<Square>(length);
                    }
                }
            }

            return availableSquares;
        }
    }
}
