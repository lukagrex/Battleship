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
            ChangeToRandomtactics();
        }

        private Grid monitoringGrid;
        private List<Square> squaresHit = new List<Square>();

        public Square NextTarget()
        {
            return targetSelector.NextTarget();
        }

        public void ProcessHitResult(HitResult hitResult)
        {

        }

        private void ChangeToSurroundingTactics()
        {
            currentTactics = ShootingTactics.Surrounding;
            targetSelector = new SurroundingShooting(monitoringGrid, squaresHit.First());
        }

        private void InlineShooting()
        {
            currentTactics = ShootingTactics.Inline;
            targetSelector = new SurroundingShooting(monitoringGrid, squaresHit);
        }

        private void ChangeToRandomtactics()
        {
            currentTactics = ShootingTactics.Random;

        }

        private ShootingTactics currentTactics = Model.ShootingTactics.Random;

        public ShootingTactics ShootingTactics
        {
            get
            {
                return currentTactics;
            }
        }

        private INextTarget targetSelector;
    }
}
