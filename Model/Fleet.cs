using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vsite.Battleship.Model
{
    public enum HitResult
    {
        Missed,
        Hit,
        Sunken
    }
    public class Fleet
    {
        //: konstruktor broda dodat u kolekciju shipova
        
        public void CreateShip(IEnumerable<Square> squares)
        {
            var ship = new Ship(squares);
            ships.Add(new Ship(squares));
        }

        public HitResult Shoot(int row, int column)
        {
            foreach (var ship in ships)
            {
                var HitResult = ship.Shoot(row, column);
                if (HitResult != HitResult.Missed)
                    return HitResult;
            }
            return HitResult.Missed;
        }

        public IEnumerable<Ship> Ships
        {
            get { return ships; }
        }

        // lista brodova
        private List<Ship> ships = new List<Ship>();

    }
}
