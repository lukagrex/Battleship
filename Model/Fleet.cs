using System.Collections.Generic;
using Vsite.BattleShip.Model;

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
        public void CreateShip(IEnumerable<Square> squares)
        {
            var ship = new Ship(squares);
            ships.Add(ship);
        }

        public HitResult Shoot(int row, int column)
        {
            foreach (var ship in ships)
            {
                var hitResult = ship.Shoot(row, column);
                if (hitResult != HitResult.Missed)
                    return hitResult;
            }
            return HitResult.Missed;
        }

        public IEnumerable<Ship> Ships
        { get { return ships; } }

        private List<Ship> ships = new List<Ship>();
    }
}