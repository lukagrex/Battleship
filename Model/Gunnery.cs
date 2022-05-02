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
        private INextTarget targetSelector;
        private Grid monitoringGrid;
        private List<Square> squaresHit = new List<Square>();
        private Square lastTarget = new Square(0,0);
        private SquareEliminator squareEliminator;
        private List<int> liveShips;


        public Gunnery(int rows, int columns, IEnumerable<int> shipLengths)
        {
            monitoringGrid = new Grid(rows, columns);
            liveShips = shipLengths.ToList();
            this.targetSelector = new RandomShooting(monitoringGrid, liveShips.Max());
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
            lastTarget = targetSelector.NextTarget();
            return lastTarget;
        }

        public void ProcessHitResult(HitResult hitResult)
        {
            RecordOnMonitoringGrid(hitResult);

            if (hitResult == HitResult.Hit && currentTactics == ShootingTactics.Random)
            {
                squaresHit.Add(lastTarget);
                currentTactics = ShootingTactics.Surrounding;
                this.targetSelector = new SurroundingShooting(monitoringGrid, squaresHit.First());
            }
            else if (hitResult == HitResult.Hit && currentTactics == ShootingTactics.Surrounding)
            {
                squaresHit.Add(lastTarget);
                currentTactics = ShootingTactics.Inline;
                this.targetSelector = new InlineShooting(monitoringGrid, squaresHit);
            }
            else if (hitResult == HitResult.Sunken)
            {
                squaresHit.Clear();
                currentTactics = ShootingTactics.Random;
                this.targetSelector = new RandomShooting(monitoringGrid, liveShips.Max());
            }
        }

        private void RecordOnMonitoringGrid(HitResult hitResult)
        {
            switch (hitResult)
            {
                case HitResult.Hit:
                    monitoringGrid.ChangeSquareState(lastTarget.Row, lastTarget.Column, SquareState.Hit);
                    break;

                case HitResult.Sunken:

                    squaresHit.Add(lastTarget);

                    liveShips.Remove(squaresHit.Count);

                    foreach (var square in squaresHit)
                    {
                        monitoringGrid.ChangeSquareState(square.Row, square.Column, SquareState.Sunken);
                    }

                    foreach (var square in squareEliminator.ToEliminate(squaresHit).Except(squaresHit))
                    {
                        monitoringGrid.ChangeSquareState(square.Row, square.Column, SquareState.Missed);
                    }

                    break;

                case HitResult.Missed:
                    monitoringGrid.ChangeSquareState(lastTarget.Row, lastTarget.Column, SquareState.Missed);
                    break;
            }
        }
    }
}
