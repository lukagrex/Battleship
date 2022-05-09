using System;
using System.Collections.Generic;

namespace Vsite.Battleship.Model
{
    public class InlineShooting : INextTarget
    {
        public InlineShooting(Grid grid, List<Square> squaresAlreadyHit, int shipLength)
        {
            this.grid = grid;
            this.squaresAlreadyHit = squaresAlreadyHit;
            this.shipLength = shipLength;
        }

        private Grid grid;
        private List<Square> squaresAlreadyHit;
        private int shipLength;

        public Square NextTarget()
        {
            throw new NotImplementedException();
        }
    }
}