using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vsite.Battleship.Model
{
    public class RandomShooting : INextTarget
    {
        public RandomShooting(Grid grid)
        {
            this.grid = grid;    
        }

        private Grid grid;
        public Square NextTarget()
        {
            throw new NotImplementedException();
        }
    }
}
