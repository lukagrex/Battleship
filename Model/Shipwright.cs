using System;
using System.Collections.Generic;
using System.Linq;

namespace Vsite.Battleship.Model
{
    public class Shipwright
    {
        private FleetGrid fleetGrid;
        private IEnumerable<int> shipLengths;
        private Random random = new Random();
        private SquareEliminator squareEliminator;

        public Shipwright(int numOfRows, int numOfColumns, IEnumerable<int> shipLengths)
        {
            fleetGrid = new FleetGrid(numOfRows, numOfColumns);
            squareEliminator = new SquareEliminator(numOfRows, numOfColumns);
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
                    if (availablePlacements.Count() == 0)
                    {
                        fleet = new Fleet();
                        fleetGrid = new FleetGrid(fleetGrid.numOfRows, fleetGrid.numOfRows);
                        squareEliminator = new SquareEliminator(fleetGrid.numOfRows, fleetGrid.numOfRows);
                        break;
                    }

                    int index = random.Next(availablePlacements.Count());
                    var selectedPlacement = availablePlacements.ElementAt(index);
                    fleet.CreateShip(selectedPlacement);

                    var squaresToEliminate = squareEliminator.ToEliminate(selectedPlacement);
                    foreach (var square in squaresToEliminate)
                    {
                        fleetGrid.EliminateSquare(square.Row, square.Column);
                    }
                }
            } while (fleet.Ships.Count() != shipLengths.Count());

            return fleet;
        }
    }
}
