using System;
using System.Collections.Generic;

namespace Model
{
    using SquareSequence = IEnumerable<Square>;

    public class EnemyGrid : Grid
    {
        public EnemyGrid(int rows, int columns) : base(rows, columns)
        {
        }

        public void ChangeSquareState(int lastTargetRow, int lastTargetColumn, SquareState hit)
        {
            //TODO prevent weakening square state (e.g. if square is sunken, it cannot be hit)
            this.squares[lastTargetRow, lastTargetColumn].ChangeState(hit);
        }

        public SquareSequence GetAvailableSquares(int row, int column, Direction direction)
        {
            int deltaRow = 0;
            int deltaColumn = 0;
            int counter = 0;
            switch (direction)
            {
                case Direction.Leftwards:
                    deltaColumn = -1;
                    counter = column;
                    break;
                case Direction.Upwards:
                    deltaRow = -1;
                    counter = row;
                    break;
                case Direction.Rightwards:
                    deltaColumn = +1;
                    counter = Columns - column - 1;
                    break;
                case Direction.BottomWards:
                    deltaRow = +1;
                    counter = Rows - row - 1;
                    break;
            }
            List<Square> result = new List<Square>();
            for (int i = 0; i < counter; ++i)
            {
                row += deltaRow;
                column += deltaColumn;
                if (squares[row, column].SquareState != SquareState.Initial)
                {
                    break;
                }
                result.Add(new Square(row, column));
            }
            return result;
        }

        public override bool IsSquareAvailable(Func<int, int, Square> squareSelect, int row, int column)
        {
            return squareSelect(row, column).SquareState == SquareState.Initial;
        }
    }
}