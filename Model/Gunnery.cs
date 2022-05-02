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
            shipsToShoot = new List<int>(shipLengths);
        }

        private Grid monitoringGrid;
        private List<Square> squaresHit = new List<Square>();
        private Square lastTarget;
        private List<int> shipsToShoot;

        public Square NextTarget()
        {
            lastTarget = targetSelector.NextTarget();
            return lastTarget;
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

        public void ProcessHitResult(HitResult hitResult)
        {
            RecordOnMonitoringGrid(hitResult);
            switch (hitResult)
            {
                case HitResult.Missed:
                    RecordOnMonitoringGrid(hitResult);
                    break;
                case HitResult.Hit:
                    squaresHit.Add(lastTarget);
                    RecordOnMonitoringGrid(hitResult);
                    break;
            }
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
                case HitResult.Sunk:
                    foreach (var s in squaresHit)
                    {
                    monitoringGrid.ChangeSquareState(lastTarget.Row, lastTarget.Column, SquareState.Sunk);
                    }
                    //TODO mark surrounding squares as missed

                    monitoringGrid.ChangeSquareState(lastTarget.Row, lastTarget.Column, SquareState.Hit);
                    break;
            }
        }

        private INextTarget targetSelector;
    }
}
