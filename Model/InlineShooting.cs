using System.Collections.Generic;
using System.Linq;

namespace Vsite.Battleship.Model
{
    public enum ShipPosition
    {
        Horizontal,
        Vertical
    }
    public class InlineShooting : INextTarget
    {
        public InlineShooting(EnemyGrid grid, List<Square> squaresAlreadyHit, int shipLength)
        {
            this.grid = grid;
            this.squaresAlreadyHit = squaresAlreadyHit;
            this.shipLength = shipLength;
        }

        private EnemyGrid grid;
        private List<Square> squaresAlreadyHit;
        private int shipLength;

        public Square NextTarget()
        {
            IEnumerable<Square> candidatesFirst;
            IEnumerable<Square> candidatesLast;

            var shipPosition = getShipPosition();

            if (shipPosition == ShipPosition.Horizontal)
            {
                int row = squaresAlreadyHit.FirstOrDefault().Row;
                int firstColumn = squaresAlreadyHit.Min(x => x.Column);
                int lastColumn = squaresAlreadyHit.Max(x => x.Column);
                candidatesFirst = grid.GetAvailableSquares(row, firstColumn, Direction.Leftwards);
                candidatesLast = grid.GetAvailableSquares(row, lastColumn, Direction.Rightwards);
            }
            else
            {
                int column = squaresAlreadyHit.FirstOrDefault().Column;
                int firstRow = squaresAlreadyHit.Min(x => x.Row);
                int lastRow = squaresAlreadyHit.Max(x => x.Row);

                candidatesFirst = grid.GetAvailableSquares(firstRow, column, Direction.Upwards);
                candidatesLast = grid.GetAvailableSquares(lastRow, column, Direction.Bottomwards);
            }

            return candidatesFirst.Count() > candidatesLast.Count() ? candidatesFirst.First() : candidatesLast.First();

        }

        ShipPosition getShipPosition()
        {
            if (squaresAlreadyHit.First().Row == squaresAlreadyHit.Last().Row &&
                squaresAlreadyHit.First().Column != squaresAlreadyHit.Last().Column)
                return ShipPosition.Horizontal;

            return ShipPosition.Vertical;
        }
    }
}