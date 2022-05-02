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

        private Grid grid;
        private readonly Square firstSquareHit;
        public Square NextTarget()
        {
            throw new NotImplementedException();
        }
    }
}
