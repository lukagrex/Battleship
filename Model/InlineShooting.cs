using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vsite.Battleship.Model
{
    public class InlineShooting : INextTarget
    {
        public InlineShooting(EnemyGrid grid, List<Square> squaresAlreadyHit, int shipLength)
        {
            this.grid = grid;
            this.squaresAlreadyHit = squaresAlreadyHit;
            this.shipLength = shipLength;

            var isHorizontal = squaresAlreadyHit.Select(x => x.Row).Distinct().Count() == 1;

            if (isHorizontal)
            {
                var first = squaresAlreadyHit.FirstOrDefault(x => x.Column == squaresAlreadyHit.Select(y => y.Column).Min());
                var last = squaresAlreadyHit.FirstOrDefault(x => x.Column == squaresAlreadyHit.Select(y => y.Column).Max());

                var leftCount = grid.GetAvailableSquares(first.Row, first.Column, Direction.Leftwards).Count();
                var rightCount = grid.GetAvailableSquares(last.Row, last.Column, Direction.Rightwards).Count();

                if (leftCount > 0)
                    hitList.Add(Direction.Leftwards, new Square(first.Row, first.Column - 1));
                    numOfSquaresInDirection.Add(Direction.Leftwards, leftCount);

                if (rightCount > 0)
                    hitList.Add(Direction.Rightwards, new Square(last.Row, last.Column + 1));
                    numOfSquaresInDirection.Add(Direction.Rightwards, rightCount);
            }
            else
            {
                var first = squaresAlreadyHit.FirstOrDefault(x => x.Row == squaresAlreadyHit.Select(y => y.Row).Min());
                var last = squaresAlreadyHit.FirstOrDefault(x => x.Row == squaresAlreadyHit.Select(y => y.Row).Max());

                var upCount = grid.GetAvailableSquares(first.Row, first.Column, Direction.Upwards).Count();
                var bottomCount = grid.GetAvailableSquares(last.Row, last.Column, Direction.Bottomwards).Count();

                if (upCount > 0)
                    hitList.Add(Direction.Upwards, new Square(first.Row - 1, first.Column));
                    numOfSquaresInDirection.Add(Direction.Upwards, upCount);

                if (bottomCount > 0)
                    hitList.Add(Direction.Bottomwards, new Square(last.Row + 1, last.Column));
                    numOfSquaresInDirection.Add(Direction.Bottomwards, bottomCount);
            }
            
        }

        private EnemyGrid grid;
        private List<Square> squaresAlreadyHit;
        private int shipLength;
        private Dictionary<Direction, Square> hitList = new Dictionary<Direction, Square>();
        private Dictionary<Direction, int> numOfSquaresInDirection = new Dictionary<Direction, int>();

        public Square NextTarget()
        {
            var bestDirectionCount = numOfSquaresInDirection.Values.Max();
            var bestDirection = numOfSquaresInDirection.FirstOrDefault(x => x.Value == bestDirectionCount).Key;
            hitList.TryGetValue(bestDirection, out var selectedSquare);
            hitList.Remove(bestDirection);
            return selectedSquare;
        }
     }
}
