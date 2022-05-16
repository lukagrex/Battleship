using System.Linq;

namespace Vsite.Battleship.Model
{
    public class SurroundingShooting : INextTarget
    {
        public SurroundingShooting(EnemyGrid grid, Square firstSquareHit, int shipLength)
        {
            this.grid = grid;
            this.firstSquareHit = firstSquareHit;
            this.shipLength = shipLength;
        }

        private readonly Square firstSquareHit;
        private EnemyGrid grid;
        private int shipLength;

        public Square NextTarget()
        {
            int r = firstSquareHit.Row;
            int c = firstSquareHit.Column;
            var candidates = grid.Squares.Where(s => s.SquareState == SquareState.Initial && ((s.Row == r && (s.Column == c - 1 || s.Column == c + 1)) || (s.Column == c && (s.Row == r - 1 || s.Row == r + 1))));

            if (!candidates.Any())
                return null;

            return candidates.FirstOrDefault();

        }
    }
}