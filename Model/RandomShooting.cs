using System;

namespace Vsite.BattleShip.Model
{
    internal class RandomShooting : INextTarget
    {
        private Grid grid;
        public RandomShooting(Grid grid)
        {
            this.grid = grid;
        }

        public Square NextTarget()
        {
            throw new NotImplementedException();
        }
    }
}
