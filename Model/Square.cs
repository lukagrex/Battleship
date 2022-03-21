using System;

namespace Vsite.Battleship.Model
{
    public class Square : IEquatable<Square>
    {
        public readonly int Row;
        public readonly int Column;


        public Square(int row, int column)
        {
            Row = row;
            Column = column;
        }

        public bool Equals(Square other)
        {
            return other != null && Row == other.Row && Column == other.Column;
        }

        public override int GetHashCode()
        {
            int hashCode = 240067226;
            hashCode = hashCode * -1521134295 + Row.GetHashCode();
            hashCode = hashCode * -1521134295 + Column.GetHashCode();
            return hashCode;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (GetType() != obj.GetType())
            {
                return false;
            }

            return Equals((Square)obj);
        }
    }




}
