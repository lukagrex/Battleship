using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vsite.Battleship.Model
{
    public class SurroundingShooting : INextTarget
    {

        public SurroundingShooting(Grid grid, Square firstSquareHit, int shipLength)
        {
            this.grid = grid;
            this.firstSquareHit = firstSquareHit;
            this.shipLength = shipLength;

            if (firstSquareHit.Row > 0 && grid.GetSquare(firstSquareHit.Row - 1, firstSquareHit.Column).SquareState == SquareState.Initial)
                hitList.Add(new Square(firstSquareHit.Row - 1, firstSquareHit.Column));

            if (firstSquareHit.Row < grid.Rows - 1 && grid.GetSquare(firstSquareHit.Row + 1, firstSquareHit.Column).SquareState == SquareState.Initial)
                hitList.Add(new Square(firstSquareHit.Row + 1, firstSquareHit.Column));

            if (firstSquareHit.Column > 0 && grid.GetSquare(firstSquareHit.Row, firstSquareHit.Column - 1).SquareState == SquareState.Initial)
                hitList.Add(new Square(firstSquareHit.Row, firstSquareHit.Column - 1));

            if (firstSquareHit.Column > grid.Columns - 1 && grid.GetSquare(firstSquareHit.Row, firstSquareHit.Column + 1).SquareState == SquareState.Initial)
                hitList.Add(new Square(firstSquareHit.Row, firstSquareHit.Column + 1));

        }

        private readonly Square firstSquareHit;
        private Grid grid;
        private int shipLength;
        private Random random = new Random();
        private List<Square> hitList = new List<Square>();

        public Square NextTarget()
        {
            int index = random.Next(hitList.Count());
            var selectedSquare = hitList.ElementAt(index);
            hitList.RemoveAt(index);
            return selectedSquare;
        }
    }
}