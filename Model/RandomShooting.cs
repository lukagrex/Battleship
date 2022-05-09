using System;
using System.Linq;

namespace Vsite.Battleship.Model
{
    public class RandomShooting : INextTarget
    {
        private EnemyGrid enemyGrid;
        private int shipLength;
        private Random random = new Random();

        public RandomShooting(EnemyGrid enemyGrid, int shipLength)
        {
            this.enemyGrid = enemyGrid;
            this.shipLength = shipLength;
        }

        public Square NextTarget()
        {
            var availablePlacements = enemyGrid.GetAvailablePlacements(shipLength);
            var all = availablePlacements.SelectMany(x => x);

            int index = random.Next(all.Count());
            return all.ElementAt(index);
        }
    }
}
