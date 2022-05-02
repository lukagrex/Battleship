using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Vsite.BattleShip.Model;

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
        private Grid monitoringGrid;
        private List<Square> squaresHit = new List<Square>();

        public Gunnery(int rows, int columns, IEnumerable<int> shipLengths)
        {
            this.monitoringGrid = new Grid(rows, columns);
            this.ChangeToRandomTactics();
        }

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
                    if (currentTactics == ShootingTactics.Inline)
                        return;
                    break;
                case HitResult.Sunken:
                    break;
                default:
                    Debug.Assert(false);
                    return;
            }
            ChangeCurrentTactics(hitResult);
        }

        private ShootingTactics currentTactics = ShootingTactics.Random;
        public ShootingTactics ShootingTactics
        {
            get { return currentTactics; }
        }

        private void ChangeCurrentTactics(HitResult hitResult)
        {
            if (hitResult == HitResult.Sunken)
            {
                ChangeToRandomTactics();
            }
            else
            {
                switch (currentTactics)
                {
                    case ShootingTactics.Random:
                        ChangeToSurroundingTactics();
                        break;
                    case ShootingTactics.Surrounding:
                        ChangeToInlineTactics();
                        break;
                    default:
                        Debug.Assert(false);
                        break;
                }
            }
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

        private void ChangeToRandomTactics()
        {
            currentTactics = ShootingTactics.Random;
            targetSelector = new RandomShooting(monitoringGrid);
        }

        private INextTarget targetSelector;
    }
}
