using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vsite.BattleShip.Model
{
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
    }
}
