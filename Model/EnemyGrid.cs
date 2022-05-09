using System;
using System.Collections.Generic;

namespace Vsite.BattleShip.Model
{
    public class EnemyGrid : Grid
    {
        public enum Direction
        {
            Leftwards,
            Upwards,
            Rightwards,
            Bottomwards
        }

        public EnemyGrid(int rows, int columns) : base(rows, columns)
        {

        }

        protected override bool IsSquareAvailable(int i1, int i2, Func<int, int, Square> squareSelect)
        {
            return squareSelect(i1, i2).SquareState == SquareState.Initial;
        }

        public void ChangeSquareState(int row, int column, SquareState newState)
        {
            // TODO: Prevent weak square state (e.g. if square is sunken, it cannot be hit
            squares[row, column].ChangeState(newState);
        }

        public IEnumerable<Square> GetAvailableSquares(int row, int column, EnemyGrid.Direction direction)
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
    }
}
