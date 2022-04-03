using System.Collections.Generic;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vsite.BattleShip.Model
{
    public class Ship
    {
        public Ship(IEnumerable<Square> squares)
        {
            this.Squares = squares;
        }

        public readonly IEnumerable<Square> Squares;
    }
}
