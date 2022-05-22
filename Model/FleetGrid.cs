using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vsite.Battleship.Model
{
    using SquareSequence = IEnumerable<Square>;
    public class FleetGrid : Grid
    {
        public FleetGrid(int rows, int columns) : base(rows, columns)
        {
            Rows = rows;
            Columns = columns;

            squares = new Square[Rows, Columns];
            // inicijaliziramo svako polje pojedinačno, to je mreža sa poljima
            // po retcma
            for (int r = 0; r < Rows; ++r)
            {
                // po stupcima
                for (int c = 0; c < Columns; ++c)
                {
                    squares[r, c] = new Square(r, c);
                }
            }
        }
        // iz mreže izvlačimo polja
        // nul reference za svako polje
        public void EliminateSquare(int row, int column)
        {
           squares[row, column] = null;
        }

        protected override bool IsSquareAvailable;


        //enkapsuliramo dohvaćanje square-ova
        public IEnumerable<Square> Squares
        {
            get { return squares.Cast<Square>().Where(s => s != null); }
        }

        public IEnumerable<SquareSequence> GetAvailablePlacements(int length)
        {
            return GetPlacements(length, new LoopIndex(Rows, Columns), (i, j) => squares[i, j])
                .Concat(GetPlacements(length, new LoopIndex(Columns, Rows), (j, i) => squares[j, i]));
        }

        class LoopIndex
        {
            public LoopIndex(int outerBound, int innerBound)
            {
                this.outerBound = outerBound;
                this.innerBound = innerBound;
                // Ctrl+k+d ... podešavanje zagrada

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
        //
        
        //
        //private IEnumerable<SquareSequence> GetHorizontalPlacements(int length)
        //{
        //    List<SquareSequence> result = new List<SquareSequence>();
        //    for (int r = 0; r < Rows; ++r)
        //    {
        //        LimitedQueue<Square> queue = new LimitedQueue<Square>(length);
        //        for (int c = 0; c < Columns; ++c)
        //        {
        //            if (squares[r, c] != null)
        //            {
        //                queue.Enqueue(squares[r, c]);
        //                if (queue.Count >= length)
        //                {
        //                    result.Add(queue);
        //                }
        //            }
        //            else
        //            {
        //                queue.Clear();
        //            }
        //        }
        //    }
        //    return result;
        //}
        //private IEnumerable<SquareSequence> GetVerticalPlacements(int length)
        //{
        //    List<SquareSequence> result = new List<SquareSequence>();
        //    for (int c = 0; c < Columns; ++c)
        //    {
        //        LimitedQueue<Square> queue = new LimitedQueue<Square>(length);
        //        for (int r = 0; r < Rows; ++r)
        //        {
        //            if (squares[r, c] != null)
        //            {
        //                queue.Enqueue(squares[r, c]);
        //                if (queue.Count >= length)
        //                {
        //                    result.Add(queue);
        //                }
        //            }
        //            else
        //            {
        //                queue.Clear();
        //            }
        //        }
        //    }
        //    return result;
        //}

        public readonly int Rows;
        public readonly int Columns;

        private Square[,] squares;

        protected abstract bool IsSquareAvailable(int i1, int i2, Func<int, int, Square> squareSelect)
        {
            return squareSelect(i1, i2).SquareState == SquareState.Initial;
        }
    }
}
