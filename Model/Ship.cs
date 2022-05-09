using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
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
            if (!this.Squares.Contains(new Square(row, column)))
            {
                return HitResult.Missed;
            }

            var hitSquare = this.Squares.First(s => s.Row == row && s.Column == column);
            hitSquare.ChangeState(SquareState.Hit);

            int squaresHit = this.Squares.Count(s => s.SquareState != SquareState.Missed && s.SquareState != SquareState.Initial);

            if (squaresHit == this.Squares.Count())
            {
                foreach (var square in this.Squares)
                {
                    square.ChangeState(SquareState.Sunken);
                }

                return HitResult.Sunken;
            }

            return HitResult.Hit;
        }

    }
}
