using System;

namespace Vsite.BattleShip.Model
{
    public class Square : IEquatable<Square>
    {
        public readonly int Row;
        public readonly int Column;


        public Square(int row, int column)
        {
            this.Row = row;
            this.Column = column;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            return GetType() == obj.GetType() && Equals((Square)obj);
        }

        public bool Equals(Square other)
        {
            return other != null && Row == other.Row && Column == other.Column;
        }

        public override int GetHashCode()
        {
            return Row;
        }
    }
}
