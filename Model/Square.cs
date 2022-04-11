using System;

namespace Vsite.Battleship.Model
{

    public enum SquareState
    {
        Initial,
        Missed,
        Hit,
        Sunken
    }

    public class Square : IEquatable<Square>
    {
        public readonly int Row;
        public readonly int Column;
        private SquareState squareState = SquareState.Initial;

        public Square(int row, int column)
        {
            this.Row = row;
            this.Column = column;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (this.GetType() != obj.GetType())
                return false;

            return this.Equals(obj as Square);
        }

        public bool Equals(Square other)
        {
            if (other == null)
                return false;

            return this.Row == other.Row && this.Column == other.Column;
        }

        public override int GetHashCode()
        {
            int hashCode = 240067226;

            hashCode = hashCode * -1521134295 + Row.GetHashCode();
            hashCode = hashCode * -1521134295 + Column.GetHashCode();

            return hashCode;
        }

        public void ChangeState(SquareState newState)
        {
            squareState = newState;
        }

        public SquareState SquareState
        {
            get
            {
                return squareState;
            }
        }
    }
}
