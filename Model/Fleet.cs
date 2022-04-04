using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vsite.Battleship.Model
{
    public class Fleet
    {
        public void CreateShip(IEnumerable<Square> squares)
        {
            ships.Add(new Ship(squares));
        }

        private List<Ship> ships = new List<Ship>();

        public IEnumerable<Ship> Ships { get { return ships; } }
    }
}
