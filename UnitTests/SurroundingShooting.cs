using System;

namespace Vsite.BattleShip.Model
{
    public class SurroundingShooting : INextTarget
    {
        private Grid grid;
        private Square firstSquareHit;
        private int shipLength;

        public SurroundingShooting(Grid grid, Square firstSquareHit, int shipLength)
        {
            this.grid = grid;
            this.firstSquareHit = firstSquareHit;
            this.shipLength = shipLength;
        }

        public Square NextTarget()
        {
            throw new NotImplementedException();
        }
    }
}
