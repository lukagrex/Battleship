using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vsite.BattleShip.Model
{
    public class Ship
    {
        public readonly IEnumerable<Square> Squares;

        public Ship(IEnumerable<Square> squares)
        {
            this.Squares = squares;
        }

        public HitResult Shoot(int row, int column)
        {
            if (!Squares.Contains(new Square(row, column)))
            {
                // The square doesn't belong to any ship
                return HitResult.Missed;
            }

            var hitSquare = Squares.First(s => s.Row == row && s.Column == column);
            if (hitSquare.SquareState == SquareState.Initial)
            {
                hitSquare.ChangeState(SquareState.Hit);
            }
            else
            {
                // This square is already Missed or Hit or Sunken
                return (HitResult)((int)hitSquare.SquareState - 1);
            }

            // Check how many ship squares are hit
            var squaresHit = Squares.Count(s => s.SquareState == SquareState.Hit);
            if (squaresHit != Squares.Count())
            {
                // The ship square is Hit
                return HitResult.Hit;
            }
            
            // All squares of the ship are hit --> Sunken
            foreach (var square in Squares)
            {
                square.ChangeState(SquareState.Sunken);
            }

            return HitResult.Sunken;
        }
    }
}
