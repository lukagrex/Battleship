using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vsite.BattleShip.Model
{
    public enum HitResult
    {
        Missed,
        Hit,
        Sunken
    }

    public class Fleet
    {
        private readonly List<Ship> ships = new List<Ship>();

        public IEnumerable<Ship> Ships => ships;

        public Fleet()
        {
            
        }

        public void CreateShip(IEnumerable<Square> squares)
        {
            this.ships.Add(new Ship(squares));
        }

        public HitResult Shoot(int row, int column)
        {
            foreach (var ship in ships)
            {
                var hitResult = ship.Shoot(row, column);
                if (hitResult != HitResult.Missed)
                    return hitResult;
            }

            return HitResult.Missed;
        }
    }
}
