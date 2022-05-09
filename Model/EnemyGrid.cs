using System;
using System.Collections.Generic;

namespace Vsite.Battleship.Model
{
    public enum Direction
    {
        Up,
        Down,
        Left,
        Right
    }

    public class EnemyGrid : Grid
    {
        public EnemyGrid(int rows, int columns) : base(rows, columns)
        {
        }
        public void ChangeSquareState(int row, int column, SquareState newState)
        {
            //TODO: Prevent weakening square state (e.g. if square is sunken, it cannot be hit)
            squares[row, column].ChangeState(newState);
        }

        public IEnumerable<Square> GetAvailableSquares(int row, int column, Direction direction)
        {
            throw new NotImplementedException();
        }

        public void RecordTheShooting()
        {
            throw new NotImplementedException();
        }

        protected override bool IsSquareAvailable(int i1, int i2, Func<int, int, Square> squareSelect)
        {
            return squareSelect(i1, i2).SquareState == SquareState.Initial;
        }
    }
}
