using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vsite.Battleship.Model
{
    public class Fleet
    {
        //: konstruktor broda dodat u kolekciju shipova
        
        public void CreateShip(IEnumerable<Square> squares)
        {
            ships.Add(new Ship(squares));
        }
        
        public IEnumerable<Ship> Ships
        {
            get { return ships; }
        }

        // lista brodova
        private List<Ship> ships = new List<Ship>();

    }
}
