using System;
using System.Linq;

namespace Vsite.Battleship.Model
{
    public class SurroundingShooting : INextTarget
    {
        private EnemyGrid enemyGrid;
        private Square firstSquareHit;

        public SurroundingShooting(EnemyGrid enemyGrid, Square firstSquareHit)
        {
            this.enemyGrid = enemyGrid;
            this.firstSquareHit = firstSquareHit;
        }
        public Square NextTarget()
        {
            if (enemyGrid.Squares.Where(square => square.SquareState == SquareState.Initial).Contains(new Square(this.firstSquareHit.Row - 1, this.firstSquareHit.Column)))
            {
                return new Square(this.firstSquareHit.Row - 1, this.firstSquareHit.Column);
            }else if (enemyGrid.Squares.Where(square => square.SquareState == SquareState.Initial).Contains(new Square(this.firstSquareHit.Row + 1, this.firstSquareHit.Column)))
            {
                return new Square(this.firstSquareHit.Row + 1, this.firstSquareHit.Column);
            }
            else if (enemyGrid.Squares.Where(square => square.SquareState == SquareState.Initial).Contains(new Square(this.firstSquareHit.Row, this.firstSquareHit.Column - 1)))
            {
                return new Square(this.firstSquareHit.Row, this.firstSquareHit.Column - 1);
            }
            else if (enemyGrid.Squares.Where(square => square.SquareState == SquareState.Initial).Contains(new Square(this.firstSquareHit.Row, this.firstSquareHit.Column + 1)))
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