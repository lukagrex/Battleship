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
        private Square lastTarget = new Square(0, 0);
        private List<int> shipsToShoot;

        public Gunnery(int rows, int columns, IEnumerable<int> shipLengths)
        {
            this.monitoringGrid = new Grid(rows, columns);
            this.shipsToShoot = shipLengths.ToList();
            this.ChangeToRandomTactics();
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
                    shipsToShoot.Remove(squaresHit.Count());
                    RecordOnMonitoringGrid(hitResult);
                    squaresHit.Clear();
                    break;

                default:
                    Debug.Assert(false);
                    return;
            }

            this.ChangeCurrentTactics(hitResult);
        }

        private void RecordOnMonitoringGrid(HitResult hitResult)
        {
            switch (hitResult)
            {
                case HitResult.Missed:
                    this.monitoringGrid.ChangeSquareState(lastTarget.Row, lastTarget.Column, SquareState.Missed);
                    break;

                case HitResult.Hit:
                    this.monitoringGrid.ChangeSquareState(lastTarget.Row, lastTarget.Column, SquareState.Hit);
                    break;

                case HitResult.Sunken:
                    foreach (var square in this.squaresHit)
                    {
                        this.monitoringGrid.ChangeSquareState(square.Row, square.Column, SquareState.Sunken);
                    }

                    // TODO Eliminate squares around ship as Missed

                    break;
            }
        }

        private ShootingTactics currentTactics = ShootingTactics.Random;
        public ShootingTactics ShootingTactics => currentTactics;

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
            targetSelector = new RandomShooting(monitoringGrid, this.shipsToShoot[0]);
        }

        private INextTarget targetSelector;
    }
}
