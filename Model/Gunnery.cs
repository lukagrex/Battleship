using System.Collections.Generic;

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

        public Gunnery(int rows, int columns, IEnumerable<int> shipLengths)
        {
            //TODO create evidenceGrid
        }

        public void ProcessHitResult(HitResult hitResult)
        {
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

        public ShootingTactics ShootingTactics => currentTactics;
    }
}
