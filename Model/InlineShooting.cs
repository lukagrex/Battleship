using System;
using System.Collections.Generic;
using System.Linq;

namespace Model
{
    public class InlineShooting : INextTarget
    {
        private EnemyGrid enemyGrid;
        private List<Square> squaresHit;
        private Direction direction;

        public InlineShooting(EnemyGrid enemyGrid, List<Square> squaresAlreadyHit, int shipLength)
        {
            if (squaresAlreadyHit.Count < 2)
            {
                throw new ArgumentException("Inline shooting requires at least 2 squares already hit!");
            }
            this.enemyGrid = enemyGrid;
            this.squaresHit = squaresAlreadyHit;
            this.direction = squaresAlreadyHit[0].Row == squaresAlreadyHit[1].Row ? Direction.Leftwards : Direction.Upwards;
        }

        public Square NextTarget()
        {
            if (direction == Direction.Leftwards || direction == Direction.Rightwards)
            {
                var row = squaresHit[0].Row;
                var leftColumn = squaresHit.Min(p => p.Column);
                var rightColumn = squaresHit.Max(p => p.Column);

                var availableSquaresLeft = enemyGrid.GetAvailableSquares(row, leftColumn, Direction.Leftwards);
                var availableSquaresRight = enemyGrid.GetAvailableSquares(row, rightColumn, Direction.Rightwards);

                return availableSquaresRight.Count() > availableSquaresLeft.Count() ? availableSquaresRight.First() : availableSquaresLeft.First();
            }
            else
            {
                var column = squaresHit[0].Column;
                var upRow = squaresHit.Min(p => p.Row);
                var downRow = squaresHit.Max(p => p.Row);

                var availableSquaresUp = enemyGrid.GetAvailableSquares(upRow, column, Direction.Upwards);
                var availableSquaresDown = enemyGrid.GetAvailableSquares(downRow, column, Direction.BottomWards);

                return availableSquaresUp.Count() > availableSquaresDown.Count() ? availableSquaresUp.First() : availableSquaresDown.First();
            }
        }
    }
}
