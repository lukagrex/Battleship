using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vsite.Battleship.Model
{
    public class InlineShooting : INextTarget
    {
        public InlineShooting(EnemyGrid grid, List<Square> squaresAlreadyHit, int shipLength)
        {
            this.grid = grid;
            this.squaresHit = squaresAlreadyHit;
            this.shipLength = shipLength;
        }

        public Square NextTarget()
        {
            throw new NotImplementedException();
        }

        private EnemyGrid grid;
        private List<Square> squaresHit;
        private int shipLength;
     }
}
