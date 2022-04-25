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
            /*
             * var found = Squares.FirstOrDefault(s => s.Row == row && s.Column == column)
             * if (found = null)
             *  return HitResult.Missed
             * if (found.SquareState == Sunken)
             *      return HitResult.Sunken
             * if (found.SquareState == Initial)
             * */
            if (!Squares.Contains(new Square(row, column)))
                return HitResult.Missed;
            var hitSquare = Squares.First(s => s.Row == row && s.Column == column);
            if (hitSquare.SquareState == SquareState.Sunken)
                return HitResult.Sunken;
            hitSquare.ChangeState(SquareState.Hit);
            int squaresHit = Squares.Count(s => s.SquareState == SquareState.Hit);
            if (squaresHit == Squares.Count())
            {
                foreach(var square in Squares)
                {
                    square.ChangeState(SquareState.Sunken);
                }
                return HitResult.Sunken;
            }
            return HitResult.Hit;

        }

        public readonly IEnumerable<Square> Squares;
    }
}
