using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vsite.Battleship.Model
{
    public class Ship
    {
        // za DZ metoda CreateShip
        
        public Ship(IEnumerable<Square> squares)
        {
            this.Squares = squares;
        }

        public HitResult Shoot(int row, int column)
        {
            // tu možda fali var found, za DZ ispraviti
            if (Squares.Contains(new Square(row, column)))
                return HitResult.Missed;
            
            var HitSquare = Squares.First(s => s.Row == row && s.Column == column);
            if (HitSquare.SquareState == SquareState.Sunken)
            {
                return HitResult.Sunken;
            }

            HitSquare.ChangeState(SquareState.Hit);
            int squareHit = Squares.Count(s => s.SquareState != SquareState.Missed);
            if (squareHit == Squares.Count())
            {
                foreach (var square in Squares)
                    square.ChangeState(SquareState.Sunken);
                return HitResult.Sunken;
            }
            return HitResult.Hit;
        }

        public readonly IEnumerable<Square> Squares;
    }
}
