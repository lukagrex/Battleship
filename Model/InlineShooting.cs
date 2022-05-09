using System;
using System.Collections.Generic;

namespace Vsite.Battleship.Model
{
    public class InlineShooting : INextTarget
    {
        private EnemyGrid enemyGrid;
        private List<Square> squaresHit;

        public InlineShooting(EnemyGrid enemyGrid, List<Square> squaresAlreadyHit)
        {
            this.enemyGrid = enemyGrid;
            this.squaresHit = squaresAlreadyHit;
        }

        public Square NextTarget()
        {
            throw new NotImplementedException();
        }
    }
}
