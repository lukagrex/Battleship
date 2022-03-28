using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vsite.BattleShip.Model
{
    public class Fleet
    {
        private List<Ship> ships = new List<Ship>();

        public IEnumerable<Ship> Ships
        {
            get { return ships; }
        }

        public Fleet()
        {
            
        }

        public void CreateShip(IEnumerable<Square> squares)
        {

        }
    }
}
