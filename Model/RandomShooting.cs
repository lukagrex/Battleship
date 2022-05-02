using System;
using System.Linq;

namespace Vsite.BattleShip.Model
{
    public class RandomShooting : INextTarget
    {
        private Grid grid;
        private int shipLength;
        private Random random = new Random();

        public RandomShooting(Grid grid, int shipLength)
        {
            this.grid = grid;
            this.shipLength = shipLength;
        }

        public Square NextTarget()
        {
            var availablePlacements = grid.GetAvailablePlacements(this.shipLength);
            var all = availablePlacements.SelectMany(pl => pl);
            int index = random.Next(all.Count());

            return all.ElementAt(index);
        }
    }
}
