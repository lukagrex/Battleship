using System.Collections.Generic;

namespace Vsite.Battleship.Model
{
    public class Fleet
    {
        public void CreateShip(IEnumerable<Square> squares)
        {
            //TODO ship contructor and add it to ships collection
        }

        public IEnumerable<Ship> Ships
        {
            get { return ships; }
        }

        private List<Ship> ships = new List<Ship>();
    }
}
