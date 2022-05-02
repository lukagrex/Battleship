using System;
using System.Collections.Generic;

namespace Vsite.BattleShip.Model
{
    internal class InlineShooting : INextTarget
    {
        private Grid grid;
        private List<Square> squaresHit;

        public InlineShooting(Grid grid, List<Square> squaresAlreadyHit)
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
