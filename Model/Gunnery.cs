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

        public Gunnery(int rows, int columns, IEnumerable<int> shipLengths)
        {
            //TODO create evidenceGrid
        }

        public void ProcessHitResult(HitResult hitResult)
        {
            //TODO Implement to change currentTactics
        }

        public ShootingTactics ShootingTactics => currentTactics;
    }
}
