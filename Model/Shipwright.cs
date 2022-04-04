using System;
using System.Collections.Generic;
using System.Linq;

namespace Vsite.Battleship.Model
{
    public class Shipwright
    {
        private Grid grid;
        private IEnumerable<int> shipLengths;
        private Random random = new Random();
        private SquareEliminator squareEliminator;

        public Shipwright(int numOfRows, int numOfColumns, IEnumerable<int> shipLengths)
        {
            grid = new Grid(numOfRows, numOfColumns);
            squareEliminator = new SquareEliminator(numOfRows, numOfColumns);
            this.shipLengths = shipLengths;
        }

        public Fleet CreateFleet()
        {
            var fleet = new Fleet();

            foreach (var shipLength in shipLengths)
            {
                var availablePlacements = grid.GetAvailablePlacements(shipLength);
                int index = random.Next(availablePlacements.Count());
                var selectedPlacement = availablePlacements.ElementAt(index);
                fleet.CreateShip(selectedPlacement);

                var squaresToEliminate = squareEliminator.ToEliminate(selectedPlacement);
                foreach (var square in squaresToEliminate)
                {
                    grid.EliminateSquare(square.Row, square.Column);
                }
            }

            return fleet;
        }
    }
}
