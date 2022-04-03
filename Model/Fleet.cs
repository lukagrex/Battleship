using System.Collections.Generic;

namespace Vsite.Battleship.Model
{
    public class Fleet
    {
        //TODO: konstruktor broda dodat u kolekciju shipova
        private List<Ship> ships = new List<Ship>();

        public void CreateShip(IEnumerable<Square> squares)
        {
            
            ships.Add(new Ship(squares));
        }

        public IEnumerable<Ship> Ships
        {
            get { return ships; }
        }
        
    }
}
