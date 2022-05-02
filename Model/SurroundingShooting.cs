using System;
using System.Collections.Generic;

namespace Vsite.Battleship.Model
{
    public class SurroundingShooting : INextTarget
    {
        private Grid grid;
        private Grid monitoringGrid;
        private List<Square> squaresHit;
        private readonly Square firstSquareHit;

        public SurroundingShooting(Grid grid, Square firstSquareHit)
        {
            this.grid = grid;
            this.firstSquareHit = firstSquareHit;
        }

        public SurroundingShooting(Grid monitoringGrid, List<Square> squaresHit)
        {
            this.monitoringGrid = monitoringGrid;
            this.squaresHit = squaresHit;
        }

        public Square NextTarget()
        {
            throw new NotImplementedException();
        }
    }
}
