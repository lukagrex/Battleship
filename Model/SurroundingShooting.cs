using System;

namespace Vsite.BattleShip.Model
{
    internal class SurroundingShooting : INextTarget
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
            throw new NotImplementedException();
        }
    }
}
