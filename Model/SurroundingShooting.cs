using System;

namespace Vsite.BattleShip.Model
{
    internal class SurroundingShooting : INextTarget
    {
        private EnemyGrid grid;
        private Square firstSquareHit;

        public SurroundingShooting(EnemyGrid grid, Square firstSquareHit)
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
