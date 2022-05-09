using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class InlineShooting : INextTarget
    {
        private readonly EnemyGrid fleetGrid;
        private readonly List<Square> squaresAlreadyHit;

        public InlineShooting(EnemyGrid fleetGrid, List<Square> squaresAlreadyHit)
        {
            this.fleetGrid = fleetGrid;
            this.squaresAlreadyHit = squaresAlreadyHit;
        }

        public Square NextTarget()
        {
            throw new NotImplementedException();
        }
    }
}
