using System;
using System.Collections.Generic;

namespace Model
{
    public class EnemyGrid : Grid
    {
        public EnemyGrid(int numOfRows, int numOfColumns) : base(numOfRows, numOfColumns)
        {
        }

        public void ChangeSquareState(int row, int column, SquareState newState)
        {
            squares[row, column].ChangeState(newState);
        }

        protected override bool IsSquareAvailable(Square selectedSquare)
        {
            return selectedSquare != null && selectedSquare.SquareState == SquareState.Initial;
        }

    }
}