using System;
using System.Collections.Generic;
using System.Data;
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

        public IEnumerable<SquareSequence> GetAvailablePlacements(int length)
        {
            return GetHorizontalPlacements(length).Concat(GetVerticalPlacements(length));
        }
        private IEnumerable<SquareSequence> GetHorizontalPlacements(int length)
        {
            List<SquareSequence> result = new List<SquareSequence>();
            LimitedQueue<Square> limitedQueue = new LimitedQueue<Square>(length);

            for (int r = 0; r < Rows; ++r)
            {
                limitedQueue.Clear();
                for (int c = 0; c < Columns; ++c)
                {
                    if (squares[r, c] != null)
                    {
                        limitedQueue.Enqueue(squares[r, c]);
                        if (limitedQueue.Count == length)
                        {
                            result.Add(limitedQueue);
                        }
                    }
                    else
                        limitedQueue.Clear();
                }
            }

            return result;
        }
        
        private IEnumerable<SquareSequence> GetVerticalPlacements(int length)
        {
            List<SquareSequence> result = new List<SquareSequence>();
            LimitedQueue<Square> limitedQueue = new LimitedQueue<Square>(length);

            for (int c = 0; c < Columns; ++c)
            {
                limitedQueue.Clear();
                for (int r = 0; r < Rows; ++r)
                {
                    if (squares[r, c] != null)
                    {
                        limitedQueue.Enqueue(squares[r, c]);
                        if (limitedQueue.Count == length)
                        {
                            result.Add(limitedQueue);
                        }
                    }
                    else
                        limitedQueue.Clear();
                }
            }

            return result;
        }

        public readonly int Rows;
        public readonly int Columns;

        private Square[,] squares;
    }
}
