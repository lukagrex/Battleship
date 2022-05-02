using System;
using System.Linq;

namespace Vsite.Battleship.Model
{
    public class SurroundingShooting : INextTarget
    {
        private Grid grid;
        private Square firstSquareHit;

        public SurroundingShooting(Grid grid, Square firstSquareHit)
        {
            this.grid = grid;
            this.firstSquareHit = firstSquareHit;
        }
        public Square NextTarget()
        {
            if (grid.Squares.Contains(new Square(this.firstSquareHit.Row - 1, this.firstSquareHit.Column)))
            {
                return new Square(this.firstSquareHit.Row - 1, this.firstSquareHit.Column);
            }else if (grid.Squares.Contains(new Square(this.firstSquareHit.Row + 1, this.firstSquareHit.Column)))
            {
                return new Square(this.firstSquareHit.Row + 1, this.firstSquareHit.Column);
            }
            else if (grid.Squares.Contains(new Square(this.firstSquareHit.Row, this.firstSquareHit.Column - 1)))
            {
                return new Square(this.firstSquareHit.Row, this.firstSquareHit.Column - 1);
            }
            else if (grid.Squares.Contains(new Square(this.firstSquareHit.Row, this.firstSquareHit.Column + 1)))
            {
                return new Square(this.firstSquareHit.Row, this.firstSquareHit.Column + 1);
            }
            else
            {
                return null;
            }
        }
    }
}