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
        public readonly int numOfColumns;
        public readonly int numOfRows;
        protected Square[,] squares;

        public Grid(int numOfRows, int numOfColumns)
        {
            this.numOfColumns = numOfColumns;
            this.numOfRows = numOfRows;

            this.CreateGrid();
        }

        private void CreateGrid()
        {
            squares = new Square[numOfRows, numOfColumns];

            for (int row = 0; row < numOfRows; row++)
            {
                for (int column = 0; column < numOfColumns; column++)
                {
                    squares[row, column] = new Square(row, column);
                }
            }
        }

        public IEnumerable<Square> Squares
        {
            get
            {
                return this.squares.Cast<Square>().Where(s => s != null);
            }
        }

        public IEnumerable<SquareSequence> GetAvailablePlacements(int shipSize)
        {
            return this.GetHorizontalPlacements(shipSize).Concat(this.GetVerticalPlacements(shipSize));
        }

        private IEnumerable<SquareSequence> GetHorizontalPlacements(int shipSize)
        {
            return GetPlacements(shipSize, new LoopIndex(this.numOfRows, this.numOfColumns), (i, j) => squares[i, j]);
        }

        private IEnumerable<SquareSequence> GetVerticalPlacements(int shipSize)
        {
            return GetPlacements(shipSize, new LoopIndex(this.numOfColumns, this.numOfRows), (i, j) => squares[j, i]);
        }


        private IEnumerable<SquareSequence> GetPlacements(int shipSize, LoopIndex loopIndex, Func<int, int, Square> squareSelect)
        {
            var availableSquares = new List<SquareSequence>();

            foreach (var o in loopIndex.Outer())
            {
                var listFound = new LimitedQueue<Square>(shipSize);

                foreach (var i in loopIndex.Inner())
                {
                    //Mijenajno
                    if (IsSquareAvailable(squareSelect(o, i)))
                    {
                        listFound.Enqueue(squareSelect(o, i));

                        if (listFound.Count == shipSize)
                        {
                            availableSquares.Add(listFound);

                        }
                    }
                    else
                    {
                        listFound = new LimitedQueue<Square>(shipSize);
                    }
                }
            }

            return availableSquares;
        }

        protected abstract bool IsSquareAvailable(Square selectedSquare);

        class LoopIndex
        {
            private int OuterBound;
            private int InnerBound;

            public LoopIndex(int outerBound, int innerBound)
            {
                this.OuterBound = outerBound;
                this.InnerBound = innerBound;
            }

            public IEnumerable<int> Outer()
            {
                for (int i = 0; i < OuterBound; i++)
                    yield return i;
            }

            public IEnumerable<int> Inner()
            {
                for (int i = 0; i < InnerBound; i++)
                    yield return i;
            }
        }
    }
}
