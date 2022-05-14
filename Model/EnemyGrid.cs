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
            switch (squares[row, column].SquareState)
            {
                case SquareState.Initial:
                    squares[row, column].ChangeState(newState);
                    break;
                case SquareState.Hit:
                    if (newState == SquareState.Sunken)
                        squares[row, column].ChangeState(newState);
                    break;
                case SquareState.Missed:
                    break;
                case SquareState.Sunken:
                    break;
            }
            
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

        protected override bool IsSquareAvailable(int i1, int i2, Func<int, int, Square> squareSelect)
        {
            return squareSelect(i1, i2).SquareState == SquareState.Initial;
        }
    }
}