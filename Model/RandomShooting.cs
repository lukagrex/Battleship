using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class RandomShooting : INextTarget
    {
        private EnemyGrid fleetGrid;
        private readonly int shipLength;
        private Random random => new Random();

        public RandomShooting(EnemyGrid fleetGrid, int shipLength)
        {
            this.fleetGrid = fleetGrid;
            this.shipLength = shipLength;
        }

        public Square NextTarget()
        {
            var availablePlacements = this.fleetGrid.GetAvailablePlacements(this.shipLength);
            var allPlacements = availablePlacements.SelectMany(ap => ap).ToList();
            int index = this.random.Next(allPlacements.Count());

            return allPlacements.ElementAt(index);
        }
    }
}
