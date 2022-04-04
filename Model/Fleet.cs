using System.Collections.Generic;

namespace Model
{
    public class Fleet
    {
        private List<Ship> ships = new List<Ship>();

        public IEnumerable<Ship> Ships => ships;

        public void CreateShip(IEnumerable<Square> squares)
        {
            this.ships.Add(new Ship(squares));
        }
    }
}
