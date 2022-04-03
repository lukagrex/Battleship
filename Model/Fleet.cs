using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vsite.BattleShip.Model
{
    public class Fleet
    {
        public void CreateShip(IEnumerable<Square> squares)
        {
            //pozovi konstruktor broda i dodaj ga u kolekciju
            ships.Add(new Ship(squares));
        }

        public IEnumerable<Ship> Ships
        {
            get { return ships; }
        }
        private List<Ship> ships = new List<Ship>();
    }
}
