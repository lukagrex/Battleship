using System;
using System.Linq;

namespace Vsite.Battleship.Model
{
    public class SurroundingShooting : INextTarget
    {
        private Grid grid;
        private readonly Square firstSquareHit;
        private int shipLength;
        private Random random = new Random();

        public SurroundingShooting(Grid grid, Square firstSquareHit, int shipLength)
        {
            this.grid = grid;
            this.firstSquareHit = firstSquareHit;
            this.shipLength = shipLength;
        }
        public Square NextTarget()
        {
            var all = grid.Squares.Where(s => s.SquareState == SquareState.Initial &&
                                              (IsSameRowAdjacentSquare(s) || IsSameColumnAdjacentSquare(s)));

            int index = random.Next(all.Count());
            return all.ElementAt(index);
        }

        private bool IsSameRowAdjacentSquare(Square square)
        {
            return square.Column == firstSquareHit.Column && (square.Row == firstSquareHit.Row + 1 || square.Row == firstSquareHit.Row - 1);
        }

        private bool IsSameColumnAdjacentSquare(Square square)
        {
            return square.Row == firstSquareHit.Row && (square.Column == firstSquareHit.Column + 1 || square.Column == firstSquareHit.Column - 1);
        }
    }
}
