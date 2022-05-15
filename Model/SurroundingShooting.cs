using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vsite.Battleship.Model
{
    using SquareSequence = IEnumerable<Square>;

    public class SurroundingShooting : INextTarget
    {
        public SurroundingShooting(EnemyGrid grid, Square firstSquareHit, int shipLength)
        {
            this.grid = grid;
            this.firstSquareHit = firstSquareHit;
            this.shipLength = shipLength;
        }

        public Square NextTarget()
        {
            List<SquareSequence> candidates = new List<SquareSequence>();
            foreach (Direction direction in Enum.GetValues(typeof(Direction)))
            {
                var available = grid.GetAvailableSquares(firstSquareHit.Row, firstSquareHit.Column, direction);
                if (available.Count() > 0)
                    candidates.Add(available);
            }
            int index = random.Next(candidates.Count);
            return candidates[index].First();
        }

        private readonly Square firstSquareHit;
        private EnemyGrid grid;
        private int shipLength;
        private Random random = new Random();
    }
}
