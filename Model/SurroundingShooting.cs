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
            this.firstSquareHit = firstSquareHit;
            this.grid = grid;   
        }

        private readonly Square firstSquareHit;
        private readonly Grid grid;

        public Square NextTarget()
        {
            throw new NotImplementedException();
        }
    }
}
