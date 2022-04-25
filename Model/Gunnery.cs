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
        public Gunnery(int rows, int columns, IEnumerable<int> shipLengths)
        {

        }
        public void ProcessHitResults(HitResult hitResult)
        {
            // TODO Home work
        }
        private ShootingTactics currentTatctics = ShootingTactics.Random;
        public ShootingTactics ShootingTactics
        {
            get { return currentTatctics; }
        }
    }
}
