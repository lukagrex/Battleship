using System;
using System.Collections.Generic;
using System.Drawing.Text;
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
            {
                return HitResult.Missed;
            }

            var hitSquare = Squares.First(s => s.Row == row && s.Column == column);
            if (hitSquare.SquareState == SquareState.Sunk)
            {
                return HitResult.Sunk;
            }

            hitSquare.ChangeState(SquareState.Hit);

            int squaresHit = Squares.Count(s => s.SquareState == SquareState.Hit);
            if (squaresHit == Squares.Count())
            {
                foreach (var square in Squares)
                {
                    square.ChangeState(SquareState.Sunk);
                }

                return HitResult.Sunk;
            }

            return HitResult.Hit;
        }


        public readonly IEnumerable<Square> Squares;
    }
}
