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

        public IEnumerable<Square> Squares
        {
            get { return squares.Cast<Square>().Where(s => s != null); }
        }

        public IEnumerable<SquareSequence> GetAvailablePlacements(int length)
        {
            //return this.GetHorizontalPlacements(length).Concat(GetVerticalPlacements(length));
//            return this.GetPlacements(length, new LoopIndex(this.Rows, this.Columns)).Concat(GetVerticalPlacements(length));
            return this.GetPlacements(length, new LoopIndex(this.Rows, this.Columns),(i, j) => squares[i,j]).Concat(this.GetPlacements(length, new LoopIndex(this.Columns, this.Rows), (i, j) => squares[j, i]));
        }

        private IEnumerable<SquareSequence> GetHorizontalPlacements(int length)
        {
            var availableSquares = new List<SquareSequence>();
            for (var r = 0; r < this.Rows; ++r)
            {
                var squaresInSequence = 0;
                for (var c = 0; c < this.Columns; ++c)
                {
                    if (squares[r, c] != null)
                    {
                        ++squaresInSequence;
                        if (squaresInSequence < length)
                        {
                            continue;
                        }

                        var square = new List<Square>();
                        for (var cc = c - length +1; cc <= c; ++cc)
                        {
                            square.Add(squares[r, cc]);
                        }
                        availableSquares.Add(square);
                    }
                    else
                        squaresInSequence = 0;
                }
            }

            return availableSquares;
        }

        private IEnumerable<SquareSequence> GetVerticalPlacements(int length)
        {
            var availableSquares = new List<SquareSequence>();
            for (var column = 0; column < this.Columns; column++)
            {
                var foundSquares = new LimitedQueue<Square>(length);
                for (var row = 0; row < this.Rows; row++)
                {
                    if (squares[row, column] != null)
                    {
                        foundSquares.Enqueue(squares[row, column]);

                        if (foundSquares.Count == length)
                        {
                            availableSquares.Add(foundSquares);
                        }
                    }
                    else
                    {
                        foundSquares.Clear();
                    }
                }
            }

            return availableSquares;
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

        private IEnumerable<SquareSequence> GetPlacements(int length, LoopIndex loopIndex, Func<int,int, Square> ss)
        {
            var availableSquares = new List<SquareSequence>();
            foreach (int o in loopIndex.Outer())
            {
                var foundSquares = new LimitedQueue<Square>(length);
                foreach (int i in loopIndex.Inner())
                {
                    if (ss(o, i) != null)
                    {
                        foundSquares.Enqueue(squares[i, o]);

                        if (foundSquares.Count == length)
                        {
                            availableSquares.Add(foundSquares);
                        }
                    }
                    else
                    {
                        foundSquares.Clear();
                    }
                }
            }

            return availableSquares;
        }
    }
}
