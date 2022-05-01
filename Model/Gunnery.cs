using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
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

        public Gunnery(int rows, int columns, IEnumerable<int> shipLenghts)
        {
            
        }
        
        public ShootingTactics ShootingTactics => currentTactics;

        public void ProcessHitResult(HitResult hitResult)
        {
            //TODO implementirati kod
        }
    }
}
