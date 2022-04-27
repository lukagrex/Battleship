using System;
using System.Collections.Generic;

namespace Vsite.BattleShip.Model
{
    public enum ShootingTactics
    {
        Random,
        Surrounding,
        Inline
    }
    public class Gunnery
    {
        private Grid enemyGrid;
        private Random random = new Random();


        //        private List<int> shipLengths;
        public Gunnery(int rows, int columns, IEnumerable<int> shipLengths)
        {
            this.enemyGrid = new Grid(rows, columns);
            var availablePlacements = this.enemyGrid.Squares;

        }
        public void ProcessHitResults(HitResult hitResult)
        {
            switch (hitResult)
            {
                case HitResult.Missed:
                    switch (this.currentTactics)
                    {
                        case ShootingTactics.Surrounding:
                            // continue with surrounding
                            this.currentTactics = ShootingTactics.Surrounding;
                            break;

                        case ShootingTactics.Inline:
                            // check opposite side of the ship
                            this.currentTactics = ShootingTactics.Inline;
                            break;

                        case ShootingTactics.Random:
                        default:
                            // continue with random
                            this.currentTactics = ShootingTactics.Random;
                            break;
                    }
                    break;

                case HitResult.Hit:
                    this.currentTactics = this.currentTactics == ShootingTactics.Random ? ShootingTactics.Surrounding : ShootingTactics.Inline;
                    break;

                case HitResult.Sunken:
                    // continue with random
                    this.currentTactics = ShootingTactics.Random;
                    break;

                default: // throw error
                    break;
            }
        }
        private ShootingTactics currentTactics = ShootingTactics.Random;
        public ShootingTactics ShootingTactics => currentTactics;
    }
}
