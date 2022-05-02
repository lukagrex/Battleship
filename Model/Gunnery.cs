using System.Collections.Generic;
using System.Diagnostics;

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
        private ShootingTactics currentTactics = ShootingTactics.Random;
        private Grid monitoringGrid;
        private INextTarget targetSelector;
        private List<Square> squaresHit = new List<Square>();
        private Square lastTarget;

        public Gunnery(int rows, int columns, IEnumerable<int> shipLengths)
        {
            monitoringGrid = new Grid(rows, columns);
            ChangeToRandomTactics();
        }

        public Square NextTarget()
        {
            lastTarget = targetSelector.NextTarget();
            return lastTarget;
        }

        public void ProcessHitResult(HitResult hitResult)
        {
            switch (hitResult)
            {
                case HitResult.Missed:
                    return;
                case HitResult.Hit:
                    squaresHit.Add(lastTarget);
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
                    squaresHit.Clear();
                    ChangeToRandomTactics();
                    return;
                default:
                    Debug.Assert(false);
                    break;
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
            targetSelector = new SurroundingShooting(monitoringGrid, squaresHit[0]);
        }

        private void ChangeToInlineTactics()
        {
            currentTactics = ShootingTactics.Inline;
            targetSelector = new InlineShooting(monitoringGrid, squaresHit);
        }

        public ShootingTactics ShootingTactics => currentTactics;
    }
}
