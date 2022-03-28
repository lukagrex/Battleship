using System.Collections.Generic;

namespace Vsite.Battleship.Model
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
