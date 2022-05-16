using System;
using System.Collections.Generic;
using System.Linq;
using Vsite.BattleShip.Model;

namespace Vsite.Battleship.Model
{
    using SquareSequence = IEnumerable<Square>;

    public class InlineShooting : INextTarget
    {
        public InlineShooting(EnemyGrid grid, List<Square> squaresAlreadyHit, int shipLength)
        {
            this.grid = grid;
            this.squaresHit = squaresAlreadyHit;
            this.shipLength = shipLength;
        }

        public Square NextTarget()
        {
            // Sort squares so that leftmost/topmost is the first, rightmost/bottommost is the last
            squaresHit.Sort((s1, s2) => s1.Row + s1.Column - (s2.Row + s2.Column));
            Square first = squaresHit.First();
            Square last = squaresHit.Last();
            List<SquareSequence> candidates = new List<SquareSequence>();
            // For horizontally oriented squares
            if (first.Row == last.Row)
            {
                var available = grid.GetAvailableSquares(first.Row, first.Column, EnemyGrid.Direction.Leftwards);
                if (available.Count() > 0)
                    candidates.Add(available);
                available = grid.GetAvailableSquares(last.Row, last.Column, EnemyGrid.Direction.Rightwards);
                if (available.Count() > 0)
                    candidates.Add(available);
            }
            else
            {
                var available = grid.GetAvailableSquares(first.Row, first.Column, EnemyGrid.Direction.Upwards);
                if (available.Count() > 0)
                    candidates.Add(available);
                available = grid.GetAvailableSquares(last.Row, last.Column, EnemyGrid.Direction.Bottomwards);
                if (available.Count() > 0)
                    candidates.Add(available);
            }
            int index = random.Next(candidates.Count);
            return candidates[index].First();
        }

        private EnemyGrid grid;
        private List<Square> squaresHit;
        private int shipLength;
        Random random = new Random();
    }
}