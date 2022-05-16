using System;

namespace Vsite.Battleship.Model
{
    public enum SquareState
    {
        Initial,
        Eliminated,
        Missed,
        Hit,
        Sunken
    }
    public class Square : IEquatable<Square>
    {
        public Square(int row, int column)
        {
            Row = row;
            Column = column;
        }

        public readonly int Row;
        public readonly int Column;

        private SquareState squareState = SquareState.Initial;

        public void ChangeState(SquareState newState)
        {
            if ((int)SquareState < (int)newState)
            {
                squareState = newState;
            }
        }

        public SquareState SquareState { get { return squareState; } }

        public bool Equals(Square other)
        {
            return other != null && Row == other.Row && Column == other.Column;
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
        }
    }
}