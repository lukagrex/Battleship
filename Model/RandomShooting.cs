using System;
using System.Linq;

namespace Vsite.Battleship.Model
{
    public class RandomShooting : INextTarget
    {
        public RandomShooting(Grid grid, int shipLength)
        {
            this.grid = grid;
            this.shipLength = shipLength;
        }

        public Square NextTarget()
        {
            var availablePlacements = grid.GetAvailablePlacements(shipLength);
            var all = availablePlacements.SelectMany(x => x);
            int index = random.Next(all.Count());
            return all.ElementAt(index);
        }

        private Grid grid;
        private int shipLength;
        private Random random = new Random();
    }
}