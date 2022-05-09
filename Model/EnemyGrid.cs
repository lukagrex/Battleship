using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vsite.Battleship.Model
{
    public class EnemyGrid:Grid
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
