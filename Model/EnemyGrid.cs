using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vsite.Battleship.Model
{
    public class EnemyGrid : Grid
    {
        public EnemyGrid(int rows, int columns) : base(rows, columns)
        {

        }

        public void ChangeSquareState(int row, int column, SquareState newState)
        {
            squares[row, column].ChangeState(newState);
        }

        public void GetAvailableSquares()
        {
            throw new NotImplementedException();
        }

        protected override bool IsSquareAvailable(int i1, int i2, Func<int, int, Square> squareSelect)
        {
            return squareSelect(i1, i2).SquareState == SquareState.Initial;
        }
    }
}
