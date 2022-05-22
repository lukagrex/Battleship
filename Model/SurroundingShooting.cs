using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vsite.Battleship.Model
{
    public class SurroundingShooting : INextTarget
    {
        public SurroundingShooting(EnemyGrid grid, Square firstSquareHit, int shipLength)
        {
            this.firstSquareHit = firstSquareHit;
            this.grid = grid;
            this.shipLength = shipLength;
        }

        private readonly Square firstSquareHit;
        private EnemyGrid grid;
        private int shipLength;

        public Square NextTarget()
        {
            throw new NotImplementedException();
        }
    }
}
