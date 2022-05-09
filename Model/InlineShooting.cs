using System;
using System.Collections.Generic;

namespace Model
{
    public class InlineShooting : INextTarget
    {
        private readonly EnemyGrid fleetGrid;
        private readonly List<Square> squaresAlreadyHit;

        public InlineShooting(EnemyGrid fleetGrid, List<Square> squaresAlreadyHit, int i)
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
