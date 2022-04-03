using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vsite.Battleship.Model
{
    public class Ship
    {
        // za dz metoda CreateShip
        
        public Ship(IEnumerable<Square> squares)
        {
            this.Squares = squares;
        }

        public readonly IEnumerable<Square> Squares;
    }
}
