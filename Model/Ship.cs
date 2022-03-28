using System;
using System.Collections.Generic;
using System.Linq;

namespace Vsite.Battleship.Model
{
    public class Ship : IEquatable<Ship>
    {
        public readonly IEnumerable<Square> Squares;

        public Ship(IEnumerable<Square> squares)
        {
            this.Squares = squares;
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
