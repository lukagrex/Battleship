using System.Collections.Generic;
using System.Linq;

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
        private INextTarget targetSelector;
        private EnemyGrid monitoringFleetGrid;
        private SortedSquares squaresHit = new SortedSquares();
        private Square lastTarget = new Square(0, 0);
        private SquareEliminator squareEliminator;
        private List<int> liveShips;


        public Gunnery(int rows, int columns, IEnumerable<int> shipLengths)
        {
            monitoringFleetGrid = new EnemyGrid(rows, columns);
            liveShips = shipLengths.ToList();
            this.targetSelector = new RandomShooting(monitoringFleetGrid, liveShips.Max());
            this.squareEliminator = new SquareEliminator(rows, columns);
        }

        private ShootingTactics currentTactics = ShootingTactics.Random;

        public ShootingTactics ShootingTactics
        {
            get
            {
                return currentTactics;
            }
        }

        public Square NextTarget()
        {
            if (liveShips.Count == 0)
            {
                return null;
            }
            lastTarget = targetSelector.NextTarget();
            return lastTarget;
        }

        public bool HaveLiveShips()
        {
            if (liveShips.Count == 0)
            {
                return false;
            }

            return true;
        }

        public void ProcessHitResult(HitResult hitResult)
        {
            RecordOnMonitoringGrid(hitResult);

            if (hitResult == HitResult.Hit && currentTactics == ShootingTactics.Random)
            {
                squaresHit.Add(lastTarget);
                currentTactics = ShootingTactics.Surrounding;
                this.targetSelector = new SurroundingShooting(monitoringFleetGrid, squaresHit.First());
            }
            else if (hitResult == HitResult.Hit && currentTactics == ShootingTactics.Surrounding)
            {
                squaresHit.Add(lastTarget);
                currentTactics = ShootingTactics.Inline;
                this.targetSelector = new InlineShooting(monitoringFleetGrid, squaresHit);
            }
            else if (hitResult == HitResult.Hit && currentTactics == ShootingTactics.Inline)
            {
                squaresHit.Add(lastTarget);
            }
            else if (hitResult == HitResult.Sunken)
            {
                squaresHit.Clear();
                currentTactics = ShootingTactics.Random;

                if (liveShips.Count == 0)
                {
                    return;
                }

                this.targetSelector = new RandomShooting(monitoringFleetGrid, liveShips.Max());
            }
        }

        private void RecordOnMonitoringGrid(HitResult hitResult)
        {
            switch (hitResult)
            {
                case HitResult.Hit:
                    monitoringFleetGrid.ChangeSquareState(lastTarget.Row, lastTarget.Column, SquareState.Hit);
                    break;

                case HitResult.Sunken:

                    squaresHit.Add(lastTarget);

                    liveShips.Remove(squaresHit.Count);

                    foreach (var square in squaresHit)
                    {
                        monitoringFleetGrid.ChangeSquareState(square.Row, square.Column, SquareState.Sunken);
                    }

                    foreach (var square in squareEliminator.ToEliminate(squaresHit).Except(squaresHit))
                    {
                        monitoringFleetGrid.ChangeSquareState(square.Row, square.Column, SquareState.Eliminated);
                    }

                    break;

                case HitResult.Missed:
                    monitoringFleetGrid.ChangeSquareState(lastTarget.Row, lastTarget.Column, SquareState.Missed);
                    break;
            }
        }
    }
}
