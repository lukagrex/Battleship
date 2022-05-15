using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vsite.Battleship.Model
{
    public class SurroundingShooting : INextTarget
    {

        public SurroundingShooting(EnemyGrid grid, Square firstSquareHit, int shipLength)
        {
            this.grid = grid;
            this.firstSquareHit = firstSquareHit;
            this.shipLength = shipLength;

            if (firstSquareHit.Row > 0 && grid.GetSquare(firstSquareHit.Row - 1, firstSquareHit.Column).SquareState == SquareState.Initial)
                hitList.Add(Direction.Upwards, new Square(firstSquareHit.Row - 1, firstSquareHit.Column));

            if (firstSquareHit.Row < grid.Rows - 1 && grid.GetSquare(firstSquareHit.Row + 1, firstSquareHit.Column).SquareState == SquareState.Initial)
                hitList.Add(Direction.Bottomwards, new Square(firstSquareHit.Row + 1, firstSquareHit.Column));

            if (firstSquareHit.Column > 0 && grid.GetSquare(firstSquareHit.Row, firstSquareHit.Column - 1).SquareState == SquareState.Initial)
                hitList.Add(Direction.Leftwards, new Square(firstSquareHit.Row, firstSquareHit.Column - 1));

            if (firstSquareHit.Column < grid.Columns - 1 && grid.GetSquare(firstSquareHit.Row, firstSquareHit.Column + 1).SquareState == SquareState.Initial)
                hitList.Add(Direction.Rightwards, new Square(firstSquareHit.Row, firstSquareHit.Column + 1));
        }

        private readonly Square firstSquareHit;
        private EnemyGrid grid;
        private int shipLength;
        private Dictionary<Direction, Square> hitList = new Dictionary<Direction, Square>();
        private Dictionary<Direction, int> numOfSquaresInDirection = new Dictionary<Direction, int>();

        public Square NextTarget()
        {
            numOfSquaresInDirection.Add(Direction.Upwards, grid.GetAvailableSquares(firstSquareHit.Row, firstSquareHit.Column, Direction.Upwards).Count());
            numOfSquaresInDirection.Add(Direction.Rightwards, grid.GetAvailableSquares(firstSquareHit.Row, firstSquareHit.Column, Direction.Rightwards).Count());
            numOfSquaresInDirection.Add(Direction.Bottomwards, grid.GetAvailableSquares(firstSquareHit.Row, firstSquareHit.Column, Direction.Bottomwards).Count());
            numOfSquaresInDirection.Add(Direction.Leftwards, grid.GetAvailableSquares(firstSquareHit.Row, firstSquareHit.Column, Direction.Leftwards).Count());
            var bestDirectionCount = numOfSquaresInDirection.Values.Max();
            var bestDirection = numOfSquaresInDirection.FirstOrDefault(x => x.Value == bestDirectionCount).Key;
            hitList.TryGetValue(bestDirection, out var selectedSquare);
            hitList.Remove(bestDirection);
            return selectedSquare;
        }
    }
}