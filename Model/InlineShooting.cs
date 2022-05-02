using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vsite.Battleship.Model
{
    public class InlineShooting : INextTarget
    {
        public InlineShooting(Grid grid, List<Square> squaresAlreadyHit)
        {
            this.grid = grid;
            this.squaresHit = squaresAlreadyHit;
        }

        private Grid grid;
        private List<Square> squaresHit;
        public Square NextTarget()
        {
            throw new NotImplementedException();
        }
     }
}
