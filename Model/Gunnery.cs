using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vsite.Battleship.Model
{
    public enum ShootingTactics { 
        Random,
        Surrounding,
        Inline
    }
    public class Gunnery
    {
        public Gunnery(int rows, int columns, IEnumerable<int> shipLengths)
        {
            this.monitoringGrid = new Grid(rows, columns);
            this.currentTactics = ShootingTactics.Random;
            this.targetSelector = new RandomShooting(monitoringGrid);
        }

        private Grid monitoringGrid;
        private List<Square> squaresHit = new List<Square>();
        private Square lastTarget;

        public Square NextTarget()
        {
            lastTarget = targetSelector.NextTarget();
            return lastTarget;
        }

        public void ProcessHitResult(HitResult hitResult)
        {
            if (hitResult == HitResult.Hit && currentTactics == ShootingTactics.Random)
            {
                squaresHit.Add(lastTarget);
                currentTactics = ShootingTactics.Surrounding;
                targetSelector = new SurroundingShooting(monitoringGrid, squaresHit.First());
            }
            else if (hitResult == HitResult.Hit && currentTactics == ShootingTactics.Surrounding)
            {
                squaresHit.Add(lastTarget);
                currentTactics = ShootingTactics.Inline;
                targetSelector = new InlineShooting(monitoringGrid, squaresHit);
            }
            else if (hitResult == HitResult.Sunken)
            {
                squaresHit.Clear();
                currentTactics = ShootingTactics.Random;
                targetSelector = new RandomShooting(monitoringGrid);
            }
        }
        private ShootingTactics currentTactics = ShootingTactics.Random;
        public ShootingTactics ShootingTactics
        {
            get { return currentTactics; }
        }

        private INextTarget targetSelector;
    }
}
