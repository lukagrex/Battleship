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
        private Square lastTarget;

        public ShootingTactics ShootingTactics
        {
            get { return currentTactics; }
        }

        public Square NextTarget()
        {
            lastTarget = targetSelector.NextTarget();
            return lastTarget;
        }

        public void ProcessHitResult(HitResult hitResult)
        {
            if (currentTactics.Equals(ShootingTactics.Random) && hitResult.Equals(HitResult.Hit))
            {
                squaresHit.Add(lastTarget);
                currentTactics = ShootingTactics.Surrounding;
                targetSelector = new SurroundingShooting(monitoringGrid, squaresHit.First());
                return;
            }
            if (currentTactics.Equals(ShootingTactics.Surrounding) && hitResult.Equals(HitResult.Hit))
            {
                squaresHit.Add(lastTarget);
                currentTactics = ShootingTactics.Inline;
                targetSelector = new InlineShooting(monitoringGrid, squaresHit);
                return;
            }
            if (hitResult.Equals(HitResult.Sunken))
            {
                squaresHit.Clear();
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
