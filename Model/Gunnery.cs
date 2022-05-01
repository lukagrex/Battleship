using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vsite.Battleship.Model
{
    // does not recognize evidenceGrid
    //private EvidenceGrid evidenceGrid; 

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
            //evidenceGrid = new EvidenceGrid(rows, columns);
        }
        
        public void ProcessHitResult(HitResult hitResult)
        {
            // za DZ
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
        //
        public ShootingTactics currentTactics = ShootingTactics.Random;

        public ShootingTactics ShootingTactics
        {
            get { return currentTactics; }
        }
        // that can also be written as public ShootingTactics ShootingTactics => currentTactics;
    }
}
