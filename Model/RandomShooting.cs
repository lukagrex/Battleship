using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vsite.Battleship.Model
{
    public class RandomShooting : INextTarget
    {

        private EnemyGrid enemyGrid;
        private int shipLength;
        private Random randGen = new Random();

        public RandomShooting(EnemyGrid enemyGrid, int shipLength)
        {
            this.enemyGrid = enemyGrid;
            this.shipLength = shipLength;
        }
        public Square NextTarget()
        {
            var availablePlacements = enemyGrid.GetAvailablePlacements(shipLength).SelectMany(x => x).GroupBy(x => x);

            var largestGroup = availablePlacements.FirstOrDefault();
            foreach (var availablePlacement in availablePlacements)
            {
                if (availablePlacement.Count() > largestGroup.Count())
                {
                    largestGroup = availablePlacement;
                }
            }

            return largestGroup.FirstOrDefault();
        }
    }
}
