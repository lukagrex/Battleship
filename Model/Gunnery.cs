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
            monitoringGrid = new EnemyGrid(rows, columns);
            squareEliminator = new SquareEliminator(rows, columns);
            shipsToShoot = new List<int>(shipLengths);
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
                        /*
                        int startRow = Math.Max(s.Row - 1, 0);
                        int endIRow = Math.Min(s.Row + 1, monitoringGrid.Rows);
                        int startColumn = Math.Max(s.Column - 1, 0);
                        int endColumn = Math.Min(s.Column + 1, monitoringGrid.Columns);
                        for (int r = startRow; r <= endIRow; ++r)
                        {
                            for (int c = startColumn; c <= endColumn; c++)
                            {
                                monitoringGrid.ChangeSquareState(r, c, SquareState.Missed);
                            }
                        }
                        */
                        monitoringGrid.ChangeSquareState(s.Row, s.Column, SquareState.Sunken);                       
                    }
                    var toEliminate = squareEliminator.ToEliminate(squaresHit);
                    foreach(var square in toEliminate)
                    {
                        monitoringGrid.ChangeSquareState(square.Row, square.Column, SquareState.Eliminated);
                    }
                    break;
            }
        }
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
            targetSelector = new SurroundingShooting(monitoringGrid, squaresHit.First(), shipsToShoot[0]);
        }
        private void ChangeToInlineTactics()
        {
            currentTactics = ShootingTactics.Inline;
            targetSelector = new InlineShooting(monitoringGrid, squaresHit, shipsToShoot[0]);
        }
        private void ChangeToRandomTactics()
        {
            currentTactics = ShootingTactics.Random;
            targetSelector = new RandomShooting(monitoringGrid, shipsToShoot[0]);
        }

        private EnemyGrid monitoringGrid;
        private List<int> shipsToShoot;
        private Square lastTarget = new Square(0, 0);
        private List<Square> squaresHit = new List<Square>();
        private SquareEliminator squareEliminator;

        private ShootingTactics currentTactics = ShootingTactics.Random;
        private INextTarget targetSelector;
    }
}