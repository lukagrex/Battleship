using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vsite.Battleship.Model
{
    using SquareSequence = IEnumerable<Square>;

    public enum Direction
    {
        Leftwards,
        Upwards,
        Rightwards,
        Bottomwards
    }
    public class EnemyGrid : Grid
    {
        public EnemyGrid(int rows, int columns) : base(rows, columns)
        {
        }

        public void ChangeSquareState(int row, int column, SquareState newState)
        {
            // TODO: Prevent weakening square state (e.g. if square is sunken, it cannot be hit)
            squares[row, column].ChangeState(newState);
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
                case Direction.Bottomwards:
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

        protected override bool IsSquareAvailable(Square square)
        {
            return square.SquareState == SquareState.Initial;
        }
    }
}
