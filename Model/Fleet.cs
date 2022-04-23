using System.Collections.Generic;

namespace Model
{
    public enum HitResult
    {
        Hit,
        Missed,
        Sunken
    }

    public class Fleet
    {
        private List<Ship> ships = new List<Ship>();

        public IEnumerable<Ship> Ships => ships;

        public void CreateShip(IEnumerable<Square> squares)
        {
            this.ships.Add(new Ship(squares));
        }

        public HitResult Shoot(int row, int column)
        {
            foreach (var ship in ships)
            {
                var hitResult = ship.Shoot(row, column);
                if (hitResult != HitResult.Missed)
                {
                    return hitResult;
                }
            }

            return HitResult.Missed;
        }

    }
}
