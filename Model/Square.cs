using System;

namespace Vsite.BattleShip.Model
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
        public readonly int Row;
        public readonly int Column;

        private SquareState squareState = SquareState.Initial;

        public void ChangeState(SquareState newState)
        {
            if ((int)squareState < (int)newState)
            {
                squareState = newState;
            }
        }

        public SquareState SquareState => squareState;

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
