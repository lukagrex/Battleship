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
            Rows = rows;
            Columns = columns;

            squares = new Square[Rows, Columns];
        }
        public void ChangeSquareState(int row, int column, SquareState newState)
        {
            squares[row, column].ChangeState(newState);
            // ako je polje već potopljeno, moramo napraviti provjeru da li je polje već Hit, Missed ili Sunken
            // mi možemo napraviti, ako je Sunken, ne možemo dopustiti promjenu stanja u Hit ili Missed


        }

        protected override bool IsSquareAvailable(int i1, int i2, Func<int, int, Square> squareSelect)
        {
            return squares[row, column].SquareState == SquareState.Initial;
        }
    }
}
