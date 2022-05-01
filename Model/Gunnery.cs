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

        }

        public void ProcessHitResult(HitResult hitResult)
        {
            if (currentTactics.Equals(ShootingTactics.Random) && hitResult.Equals(HitResult.Hit))
            {
                currentTactics = ShootingTactics.Surrounding;
                return;
            }
            if (currentTactics.Equals(ShootingTactics.Surrounding) && hitResult.Equals(HitResult.Hit))
            {
                currentTactics = ShootingTactics.Inline;
                return;
            }
            if (hitResult.Equals(HitResult.Sunk))
            {
                currentTactics = ShootingTactics.Random;
                return;
            }
        }

        private ShootingTactics currentTactics = Model.ShootingTactics.Random;


        public ShootingTactics ShootingTactics
        {
            // Can also be implemented as:
            // public ShootingTactics ShootingTactics => currentTactics;
            get
            {
                return currentTactics;
            }
        }
    }
}
