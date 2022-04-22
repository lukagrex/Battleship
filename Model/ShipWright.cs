using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vsite.Battleship.Model
{
    public class Shipwright
    {

        private Grid grid;
        private IEnumerable<int> shipLengths;
        private Random random = new Random();
        private SquareEliminator squareEliminator;

        public Shipwright(int rows, int columns, IEnumerable<int> shipLengths)
        {
            this.grid = new Grid(rows, columns);
            this.squareEliminator = new SquareEliminator(rows, columns);
            this.shipLengths = shipLengths;
        }


        public Fleet CreateFleet()
        {
            var fleet = new Fleet();

            do
            {
                foreach (var shipLength in shipLengths)
                {
                    var availablePlacements = grid.GetAvailablePlacements(shipLength);
                    if (availablePlacements.Count() == 0)
                    {
                        fleet = new Fleet();
                        grid = new Grid(grid.Rows, grid.Columns);
                        squareEliminator = new SquareEliminator(grid.Rows, grid.Columns);
                        break;
                    }

                    int index = random.Next(availablePlacements.Count());
                    var selectedPlacement = availablePlacements.ElementAt(index);
                    fleet.CreateShip(selectedPlacement);

                    var squaresToEliminate = squareEliminator.ToEliminate(selectedPlacement);
                    foreach (var square in squaresToEliminate)
                    {
                        grid.EliminateSquare(square.Row, square.Column);
                    }
                }
            }
            while (fleet.Ships.Count() != shipLengths.Count());

            return fleet;
        }

    }
}
