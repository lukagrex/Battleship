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
        // Konstruktor Gunnery-ja
        public Gunnery(int rows, int columns, IEnumerable<int> shipLengths)
        {

        }
        
        public void ProcessHitResult(HitResult hitResult)
        {
            // za DZ
        }

        public ShootingTactics currentTactics = ShootingTactics.Random;

        public ShootingTactics ShootingTactics
        {
            get { return currentTactics; }
        }
    }
}
