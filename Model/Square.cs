using System;
namespace Vsite.Battleship.Model
{
    public class Square : IEquatable<Square>
    {
        public Square(int row, int column)
        {
            this.Row = row;
            this.Column = column;
        }

        public readonly int Row;
        public readonly int Column;

        public bool Equals (Square otherSquare)
        {
            return this.Row == otherSquare.Row && this.Column == otherSquare.Column;   
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (GetType() != obj.GetType())
                return false;
            return Equals((Square)obj);
        }

        public override int GetHashCode()
        {
            return Row ^ Column;
            //int hashCode = 240067226;
            //hashCode = hashCode * -1521134295 + Row.GetHashCode();
            //hashCode = hashCode * -1521134295 + Column.GetHashCode();
            //return hashCode;
        }
    }
}
