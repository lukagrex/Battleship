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

        public Square NextTarget()
        {
            return targetSelector.NextTarget();
        }

        public void ProcessHitResult(HitResult hitResult)
        {
            if (hitResult == HitResult.Hit && currentTactics == ShootingTactics.Random)
            {
                currentTactics = ShootingTactics.Surrounding;
                targetSelector = new SurroundingShooting(monitoringGrid, squaresHit.First());
            }
            else if (hitResult == HitResult.Hit && currentTactics == ShootingTactics.Surrounding)
            {
                currentTactics = ShootingTactics.Inline;
                targetSelector = new InlineShooting(monitoringGrid, squaresHit);
            }
            else if (hitResult == HitResult.Sunken)
            {
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
