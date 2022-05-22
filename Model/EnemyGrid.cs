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
        Up,
        Down,
        Left,
        Right
    }
    public class EnemyGrid : Grid
    {
        public EnemyGrid(int Rows, int Columns) : base(Rows, Columns)
        {
            //this.Rows = rows;
            //this.Columns = columns;
            //squares = new Square[Rows, Columns];
        }
        public void ChangeSquareState(int row, int column, SquareState newState)
        {
            squares[row, column].ChangeState(newState);
            // ako je polje već potopljeno, moramo napraviti provjeru da li je polje već Hit, Missed ili Sunken
            // mi možemo napraviti, ako je Sunken, ne možemo dopustiti promjenu stanja u Hit ili Missed
        }

        public SquareSequence GetAvailableSquares(int row, int column, Direction direction)
        {
            var deltaRow = 0;
            var deltaColumn = 0;
            var counter = 0;
            switch (direction)
            {
                case Direction.Left:
                    deltaColumn = -1;
                    counter = column;
                    break;
                case Direction.Up:
                    deltaRow = -1;
                    counter = row;
                    break;
                case Direction.Right:
                    deltaColumn = +1;
                    counter = Columns - column - 1;
                    break;
                case Direction.Down:
                    deltaRow = +1;
                    counter = Rows - row - 1;
                    break;
            }
            var result = new List<Square>();
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
