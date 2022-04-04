using System;
using System.Collections.Generic;
using System.Linq;

namespace Model
{
    public class Shipwright
    {
        private readonly IEnumerable<int> shipLengths;
        private readonly Grid grid;
        private readonly Random random = new Random();
        private readonly SquareEliminator squareEliminator;

        public Shipwright(int rows, int columns, IEnumerable<int> shipLengths)
        {
            this.shipLengths = shipLengths;
            this.grid = new Grid(rows, columns);
            this.squareEliminator = new SquareEliminator(rows, columns);
        }

        public Fleet CreateFleet()
        {
            var fleet = new Fleet();
            foreach (var shipLength in shipLengths)
            {
                var availablePlacements = grid.GetAvailablePlacements(shipLength);
                int index = random.Next(availablePlacements.Count());
                var selectedPlacements = availablePlacements.ElementAt(index);
                fleet.CreateShip(selectedPlacements);
                var toEliminate =squareEliminator.ToEliminate(selectedPlacements);
                foreach (var square in toEliminate)
                {
                    grid.EliminateSquare(square.Row, square.Column);
                }
            }
            return fleet;
        }
    }
}
