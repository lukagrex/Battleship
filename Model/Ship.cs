using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vsite.Battleship.Model
{
    public class Ship
    {
        public Ship(IEnumerable<Square> squares)
        {
            this.Squares = squares;
        }

        public HitResult Shoot(int row, int column)
        {
            if (!Squares.Contains(new Square(row, column)))
                return HitResult.Missed;
            var hitSquares = Squares.First(s => s.Row == row && s.Column == column);
            hitSquares.ChangeState(SquareState.Hit);
            int squaresHit = Squares.Count(s => s.SquareState != SquareState.Missed);

            if (squaresHit == Squares.Count())
            {
                foreach (var squares in Squares)
                    squares.ChangeState(SquareState.Sunken);
                return HitResult.Sunken;
            }

            return HitResult.Hit;
        }

        public readonly IEnumerable<Square> Squares;
    }
}
