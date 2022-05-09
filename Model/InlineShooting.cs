using System;
using System.Collections.Generic;

namespace Vsite.BattleShip.Model
{
    public class InlineShooting : INextTarget
    {
        private EnemyGrid grid;
        private List<Square> squaresHit;

        public InlineShooting(EnemyGrid grid, List<Square> squaresAlreadyHit)
        {
            this.grid = grid;
            this.squaresHit = squaresAlreadyHit;
        }

        public Square NextTarget()
        {
            throw new NotImplementedException();
        }
    }
}
