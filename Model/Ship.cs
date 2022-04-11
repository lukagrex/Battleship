using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vsite.Battleship.Model
{
    public class Ship : IEquatable<Ship>
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
                return HitResult.Missed;
            }

            var hitSquare = Squares.First(s => s.Row == row && s.Column == column);
            hitSquare.ChangeState(SquareState.Hit);

            int squaresHit = Squares.Count(s => s.SquareState != SquareState.Missed || s.SquareState != SquareState.Initial);

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

        public override bool Equals(object obj)
        {
            return this.Equals(obj as Ship);
        }

        public bool Equals(Ship other)
        {
            if (other == null)
            {
                return false;
            }

            if (this.GetType() != other.GetType())
            {
                return false;
            }

            return this.Squares.SequenceEqual(other.Squares);
        }
    }
}
