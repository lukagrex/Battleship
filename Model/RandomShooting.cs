using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vsite.Battleship.Model
{
    public class RandomShooting : INextTarget
    {

        private Grid grid;
        private int shipLength;
        private Random randGen = new Random();

        public RandomShooting(Grid grid, int shipLength)
        {
            this.grid = grid;
            this.shipLength = shipLength;
        }
        public Square NextTarget()
        {
            var availablePlacements = grid.GetAvailablePlacements(shipLength).SelectMany(x => x).GroupBy(x => x);

            var largestGroup = availablePlacements.FirstOrDefault();
            foreach (var availablePlacement in availablePlacements)
            {
                if (availablePlacement.Count() > largestGroup.Count())
                {
                    largestGroup = availablePlacement;
                }
            }

            return largestGroup.FirstOrDefault();

            //if (grid.Squares.Count() == 0)
            //    return null;

            //var nextElementIndex = randGen.Next(grid.Squares.Count());
            //return grid.Squares.ElementAtOrDefault(nextElementIndex);
        }
    }
}
