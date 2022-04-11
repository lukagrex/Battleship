using System.Collections.Generic;

namespace Vsite.Battleship.Model
{
    public enum HitResult
    {
        Missed, 
        Hit, 
        Sunken
    }

    public class Fleet
    {
   
        private List<Ship> ships = new List<Ship>();

        public void CreateShip(IEnumerable<Square> squares)
        {
            
            ships.Add(new Ship(squares));
        }

        public HitResult Shoot(int row, int column)
        {
            foreach (var ship in ships)
            {
                var hitResult = ship.Shoot(row, column); 
                if(hitResult != HitResult.Missed)
                {
                    return hitResult;
                }
                else
                {
                    return HitResult.Missed;
                }
            }
        }
        

        public IEnumerable<Ship> Ships
        {
            get { return ships; }
        }
        
    }
}
