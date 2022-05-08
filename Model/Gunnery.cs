using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Diagnostics;
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
            ChangeToRandomTactics();
        }

        private Grid monitoringGrid;
        private List<Square> squaresHit = new List<Square>();

        public Square NextTarget()
        {
            return targetSelector.NextTarget();
        }

        public void ProcessHitResult(HitResult hitResult)
        {
            switch (hitResult)
            {
                case HitResult.Missed:
                    return;
                case HitResult.Hit:
                    switch (ShootingTactics)
                    {
                        case ShootingTactics.Random:
                            ChangeToSurroundingTactics();
                            return;
                        case ShootingTactics.Surrounding:
                            ChangeToInlineTactics();
                            return;
                        case ShootingTactics.Inline:
                            return;
                        default:
                            Debug.Assert(false);
                            break;
                    }
                    return;
                case HitResult.Sunken:
                    ChangeToRandomTactics();
                    return;
            }
        }

        private void ChangeToRandomTactics()
        {
            currentTactics = ShootingTactics.Random;
            targetSelector = new RandomShooting(monitoringGrid);

        }

        private void ChangeToSurroundingTactics()
        {
            currentTactics = ShootingTactics.Surrounding;
            targetSelector = new SurroundingShooting(monitoringGrid, squaresHit.First());
        }

        private void ChangeToInlineTactics()
        {
            currentTactics = ShootingTactics.Inline;
            targetSelector = new InlineShooting(monitoringGrid, squaresHit);
        }


        private ShootingTactics currentTactics = ShootingTactics.Random;

        public ShootingTactics ShootingTactics
        {
            get { return currentTactics; }
        }

        private INextTarget targetSelector;
    }
}
