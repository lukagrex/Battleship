using System.Collections.Generic;

namespace Vsite.Battleship.Model
{
    public class Fleet
    {
        public void CreateShip(IEnumerable<Square> squares)
        {
            //TODO CREATE SHIP
        }

        public IEnumerable<Ship> Ships
        {
            get { return ships; }
        }
        //TODO: konstruktor broda dodat u kolekciju shipova
        private List<Ship> ships = new List<Ship>();
    }
}
