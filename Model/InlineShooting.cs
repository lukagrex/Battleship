﻿using System;
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
            this.squaresAlreadyHit = squaresAlreadyHit;
            this.shipLength = shipLength;
        }

        private EnemyGrid grid;
        private List<Square> squaresAlreadyHit;
        private int shipLength;

        public Square NextTarget()
        {
            throw new NotImplementedException();
        }
     }
}
