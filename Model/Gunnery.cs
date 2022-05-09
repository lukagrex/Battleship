using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Gunnery
    {
        private ShootingTactics currentTactics = ShootingTactics.Random;
        private INextTarget targetSelector;
        private readonly EnemyGrid monitoringFleetGrid;
        private Square lastTarget = new Square(0, 0);
        private readonly List<int> shipsToShoot;


        private List<Square> squaresHit => new List<Square>();

        public Gunnery(int rows, int columns, IEnumerable<int> shipLenghts)
        {
            this.monitoringFleetGrid = new EnemyGrid(rows, columns);
            this.shipsToShoot = new List<int>();
            this.ChangeToRandomTactics();
        }

        public ShootingTactics ShootingTactics => currentTactics;

        public Square NextTarget()
        {
            this.lastTarget = this.targetSelector.NextTarget();
            return this.lastTarget;
        }

        public void ProcessHitResult(HitResult hitResult)
        {
            switch (hitResult)
            {
                case HitResult.Hit:
                    this.RecordOnMonitoringGrid(hitResult);
                    this.squaresHit.Add(this.lastTarget);
                    if (this.currentTactics == ShootingTactics.Inline)
                    {
                        return;
                    }
                    break;
                case HitResult.Missed:
                    this.squaresHit.Add(this.lastTarget);
                    this.RecordOnMonitoringGrid(hitResult);
                    return;
                case HitResult.Sunken:
                    this.squaresHit.Add(this.lastTarget);
                    this.shipsToShoot.Remove(this.squaresHit.Count());
                    this.RecordOnMonitoringGrid(hitResult);
                    this.squaresHit.Clear();
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
                case HitResult.Hit:
                    this.monitoringFleetGrid.ChangeSquareState(this.lastTarget.Row, this.lastTarget.Column, SquareState.Hit);
                    break;
                case HitResult.Missed:
                    this.monitoringFleetGrid.ChangeSquareState(this.lastTarget.Row, this.lastTarget.Column, SquareState.Missed);
                    break;
                case HitResult.Sunken:
                    foreach (var square in squaresHit)
                    {
                        this.monitoringFleetGrid.ChangeSquareState(square.Row, square.Column, SquareState.Sunken);
                    }
                    //TODO mark surrounding squares as missed
                    
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(hitResult), hitResult, null);
            }
        }

        public void ChangeCurrentTactics(HitResult hitResult)
        {
            if (hitResult == HitResult.Sunken)
            {
                this.ChangeToRandomTactics();
            }
        }

        private void ChangeToSurroundingTactics()
        {
            this.currentTactics = ShootingTactics.Surrounding;
            this.targetSelector = new SurroundingShooting(this.monitoringFleetGrid, this.squaresHit.First(), this.shipsToShoot.First());
        }

        private void ChangeToInlineTactics()
        {
            this.currentTactics = ShootingTactics.Inline;
            this.targetSelector = new InlineShooting(this.monitoringFleetGrid, this.squaresHit);
        }

        private void ChangeToRandomTactics()
        {
            this.currentTactics = ShootingTactics.Random;
            this.targetSelector = new RandomShooting(this.monitoringFleetGrid, this.shipsToShoot.First());
        }


    }
}
