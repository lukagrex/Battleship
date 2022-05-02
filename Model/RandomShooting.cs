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
        private Random randGen = new Random();

        public RandomShooting(Grid grid)
        {
            this.grid = grid;
        }
        public Square NextTarget()
        {
            if(grid.Squares.Count() == 0)
                return null;

            var nextElementIndex = randGen.Next(grid.Squares.Count());
            return grid.Squares.ElementAtOrDefault(nextElementIndex);
        }
    }
}
