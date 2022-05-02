using System;
using System.Collections.Generic;
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
            shipsToShoot = new List<int>(shipLengths);
            ChangeToRandomTactics();
        }

        private Grid monitoringGrid;
        private List<Square> squaresHit = new List<Square>();
        private Square lastTarget = new Square(0, 0);
        private List<int> shipsToShoot;
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
                    RecordOnMonitoringGrid(hitResult);
                    return;
                case HitResult.Hit:
                    squaresHit.Add(lastTarget);
                    RecordOnMonitoringGrid(hitResult);
                    if (currentTactics == ShootingTactics.Inline)
                        return;
                    break;
                case HitResult.Sunken:
                    squaresHit.Add(lastTarget);
                    shipsToShoot.Remove(squaresHit.Count);
                    RecordOnMonitoringGrid(hitResult);
                    squaresHit.Clear();
                    break;
                default:
                    Debug.Assert(false);
                    return;
            }
            ChangeCurrentTactics(hitResult);
        }

        private void RecordOnMonitoringGrid(HitResult hitResult)
        {
            switch (hitResult)
            {
                case HitResult.Missed:
                    monitoringGrid.ChangeSquareState(lastTarget.Row, lastTarget.Column, SquareState.Missed);
                    break;
                case HitResult.Hit:
                    monitoringGrid.ChangeSquareState(lastTarget.Row, lastTarget.Column, SquareState.Hit);
                    break;
                case HitResult.Sunken:
                    foreach (var s in squaresHit)
                    {
                        monitoringGrid.ChangeSquareState(s.Row, s.Column, SquareState.Sunken);
                    }
                    // TODO: mark surrounding squares as Missed
                    break;
            }
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
            targetSelector = new SurroundingShooting(monitoringGrid, squaresHit.First(),shipsToShoot[0]);
        }

        private void ChangeToInlineTactics()
        {
            currentTactics = ShootingTactics.Inline;
            targetSelector = new InlineShooting(monitoringGrid, squaresHit);
        }

        private void ChangeToRandomTactics()
        {
            currentTactics = ShootingTactics.Random;
            targetSelector = new RandomShooting(monitoringGrid, shipsToShoot[0]);
        }

        private INextTarget targetSelector;
    }
}
