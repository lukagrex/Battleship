using System.Collections.Generic;

namespace Vsite.BattleShip.Model
{
    public class Fleet
    {
        public void CreateShip(IEnumerable<Square> squares)
        {
            //pozovi konstruktor broda i dodaj ga u kolekciju
        }

        IEnumerable<Ship> Ships
        {
            get { return ships; }
        }
        private List<Ship> ships = new List<Ship>();
    }
}
