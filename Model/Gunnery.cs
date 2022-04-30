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

        public ShootingTactics ShootingTactics
        {
            get { return currentTactics; }
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
            if (hitResult.Equals(HitResult.Sunken))
            {
                currentTactics = ShootingTactics.Random;
                return;
            }
        }

        private Grid grid;
        private ShootingTactics currentTactics = ShootingTactics.Random;
    }
}
