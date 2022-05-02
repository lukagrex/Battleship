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
        private ShootingTactics currentTactics = ShootingTactics.Random;
        private EvidenceGrid evidenceGrid;

        public Gunnery(int rows, int columns, IEnumerable<int> shipLengths)
        {
            evidenceGrid = new EvidenceGrid(rows, columns);
            monitoringGrid = new Grid(rows, columns);
        }

        private Grid monitoringGrid;
        private List<Square> squaresHit = new List<Square>();
        private Square lastTarget;

        public Square NextTarget()
        {
            return targetSelector.NextTarget();
        }

        public void ProcessHitResult(HitResult hitResult)
        {
            RecordOnMonitoringGrid(hitResult);
            switch (hitResult)
            {
                case HitResult.Missed:
                    return;
                case HitResult.Hit:
                    switch (ShootingTactics)
                    {
                        case ShootingTactics.Random:
                            currentTactics = ShootingTactics.Surrounding;
                            return;
                        case ShootingTactics.Surrounding:
                            currentTactics = ShootingTactics.Inline;
                            return;
                        case ShootingTactics.Inline:
                            return;
                    }
                    return;
                case HitResult.Sunken:
                    currentTactics = ShootingTactics.Random;
                    return;
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
                case HitResult.Sunken:
                    foreach (var s in squaresHit)
                    {
                        monitoringGrid.ChangeSquareState(s.Row, s.Column, SquareState.Sunken);
                    }
                    //TODO: mark surrounding squares as missed
                    break;
            }
        }

        public ShootingTactics ShootingTactics => currentTactics;

        private INextTarget targetSelector;
    }
}
