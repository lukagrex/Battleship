using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class SurroundingShooting : INextTarget
    {
        private readonly EnemyGrid fleetGrid;
        private readonly Square firstSquareHit;
        private readonly int shipLength;

        public SurroundingShooting(EnemyGrid fleetGrid, Square firstSquareHit, int shipLength)
        {
            this.fleetGrid = fleetGrid;
            this.firstSquareHit = firstSquareHit;
            this.shipLength = shipLength;
        }

        public Square NextTarget()
        {
            return null;
        }
    }
}
