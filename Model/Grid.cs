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

        public IEnumerable<Square> Squares
        {
            get { return squares.Cast<Square>().Where(s => s != null); }
        }

        public IEnumerable<SquareSequence> GetAvailablePlacements(int length)
        {
            return this.GetHorizontalPlacements(length).Concat(GetVerticalPlacements(length));
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
    }
}
