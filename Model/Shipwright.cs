using System;
using System.Collections.Generic;
using System.Linq;

namespace Model
{
    public class Shipwright
    {
        private FleetGrid fleetGrid;
        private IEnumerable<int> shipLengths;
        private Random random = new Random();
        private SquareEliminator squareEliminator;

        public Shipwright(int rows, int columns, IEnumerable<int> shipLengths)
        {
            fleetGrid = new FleetGrid(rows, columns);
            squareEliminator = new SquareEliminator(rows, columns);
            this.shipLengths = shipLengths;
        }


        public Fleet CreateFleet()
        {
            var fleet = new Fleet();

            do
            {
                foreach (var shipLength in shipLengths)
                {
                    var availablePlacements = fleetGrid.GetAvailablePlacements(shipLength);
                    if (!availablePlacements.Any())
                    {
                        fleet = new Fleet();
                        fleetGrid = new FleetGrid(fleetGrid.numOfRows, fleetGrid.numOfColumns);
                        break;
                    }

                    int index = random.Next(availablePlacements.Count());
                    var selectedPlacement = availablePlacements.ElementAt(index);
                    fleet.CreateShip(selectedPlacement);
                    var toEliminate = squareEliminator.ToEliminate(selectedPlacement);
                    foreach (var square in toEliminate)
                    {
                        fleetGrid.EliminateSquare(square.Row, square.Column);
                    }

                }
            } while (fleet.Ships.Count() != shipLengths.Count());

            return fleet;
        }

    }
}
