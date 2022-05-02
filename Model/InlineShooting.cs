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
            this.squaresAlreadyHit = squaresAlreadyHit;
        }

        private Grid grid;
        private List<Square> squaresAlreadyHit;
        public Square NextTarget()
        {
            throw new NotImplementedException();
        }
    }
}
