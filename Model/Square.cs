using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public enum SquareState
    {
        Initial,
        Missed,
        Hit,
        Sunken,
    }

    public class Square : IEquatable<Square>
    {
        private SquareState squareState = SquareState.Initial;
        
        public Square(int row, int column)
        {
            Row = row;
            Column = column;
        }

        public readonly int Row;
        public readonly int Column;
        public SquareState SquareState => squareState;


        public void ChangeState(SquareState newState)
        {
            squareState = newState;
        }

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
