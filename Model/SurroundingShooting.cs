using System;
using Vsite.BattleShip.Model;

namespace Vsite.Battleship.Model
{
    public class SurroundingShooting : INextTarget
    {
        public SurroundingShooting(EnemyGrid grid, Square firstSquareHit, int shipLength)
        {
            this.grid = grid;
            this.firstSquareHit = firstSquareHit;
            this.shipLength = shipLength;
        }

        public Square NextTarget()
        {
            throw new NotImplementedException();
        }

        private readonly Square firstSquareHit;
        private EnemyGrid grid;
        private int shipLength;
    }
}
