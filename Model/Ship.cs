using System.Collections.Generic;

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
