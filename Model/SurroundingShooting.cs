using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vsite.Battleship.Model
{
    public class SurroundingShooting : INextTarget
    {
        public SurroundingShooting(Grid grid, Square firstSquareHit)
        {
            this.grid = grid;
            this.firstSquareHit = firstSquareHit;
        }

        private readonly Square firstSquareHit;
        private Grid grid;
        public Square NextTarget()
        {
            throw new NotImplementedException();
        }
    }
}
