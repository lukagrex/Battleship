using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vsite.Battleship.Model
{
    public enum SquareState
    {
        // inicijalno stanje, empty
        Initial,
        Missed,
        Hit,
        Sunken
        //dodati bodove za square state, ako je sunken, ne može se promijeniti stanje u missed ili hit
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

        // samo iznutra se može mijenjati, nije public
        private SquareState squareState = SquareState.Initial;

        public void ChangeState(SquareState newState)
        {
            squareState = newState;
        }

        public SquareState SquareState { get { return squareState; } }
        public bool Equals(Square other)
        {
            return other != null && Row == other.Row && Column == other.Column;
        }

        public override bool Equals(object obj)
        {
            // usporedba sa objektom
            // 1. provjeriti da li je null referenca
            // 2. usporedba da li su istog tipa
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
