using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vsite.Battleship.Model
{
    public enum ShootingTactics
    {
        Random,
        Surrounding,
        Inline
    }

    public class Gunnery
    {
        public Gunnery(int rows, int columns, IEnumerable<int> shipLengths)
        {
            monitoringGrid = new Grid(rows, columns);
            currentTactics = ShootingTactics.Random;
            targetSelector = new RandomShooting(monitoringGrid);
        }

        private Grid monitoringGrid;
        private List<Square> squaresHit = new List<Square>();

        public ShootingTactics ShootingTactics
        {
            get { return currentTactics; }
        }

        public Square NextTarget()
        {
            return targetSelector.NextTarget();
        }

        public void ProcessHitResult(HitResult hitResult)
        {
            if (currentTactics.Equals(ShootingTactics.Random) && hitResult.Equals(HitResult.Hit))
            {
                currentTactics = ShootingTactics.Surrounding;
                targetSelector = new SurroundingShooting(monitoringGrid, squaresHit.First());
                return;
            }
            if (currentTactics.Equals(ShootingTactics.Surrounding) && hitResult.Equals(HitResult.Hit))
            {
                currentTactics = ShootingTactics.Inline;
                targetSelector = new InlineShooting(monitoringGrid, squaresHit);
                return;
            }
            if (hitResult.Equals(HitResult.Sunken))
            {
                currentTactics = ShootingTactics.Random;
                targetSelector = new RandomShooting(monitoringGrid);
                return;
            }
        }

        private INextTarget targetSelector;

        private Grid grid;
        private ShootingTactics currentTactics = ShootingTactics.Random;
    }
}
