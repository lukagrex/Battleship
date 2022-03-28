using System.Collections.Generic;

namespace Vsite.Battleship.Model
{
    public class Ship
    {
        public readonly IEnumerable<Square> Squares;

        public Ship(IEnumerable<Square> squares)
        {
            this.Squares = squares;
        }
    }
}
