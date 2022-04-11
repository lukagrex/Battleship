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
        public void CreateShip(IEnumerable<Square> squares)
        {
            ships.Add(new Ship(squares));
        }

        //public HitResult Shoot(int row, int column)
        //{
        //    foreach (var ship in ships)
        //    {
        //        var hitResult = ship.Shoot(row, column);
        //        if (hitResult != HitResult.Missed)
        //        {
        //            return hitResult;
        //        }
        //        return HitResult.Missed;
        //    }
        //}


        private List<Ship> ships = new List<Ship>();

        public IEnumerable<Ship> Ships { get { return ships; } }
    }
}
