using System;
using System.Collections.Generic;
using System.Linq;

namespace Vsite.Battleship.Model
{
    public class Shipwright
    {
        private FleetGrid _fleetGrid;
        private IEnumerable<int> shipLengths;
        private Random random = new Random();
        private SquareEliminator squareEliminator;

        public Shipwright(int numOfRows, int numOfColumns, IEnumerable<int> shipLengths)
        {
            _fleetGrid = new FleetGrid(numOfRows, numOfColumns);
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
                    var availablePlacements = _fleetGrid.GetAvailablePlacements(shipLength);
                    if (availablePlacements.Count() == 0)
                    {
                        fleet = new Fleet();
                        _fleetGrid = new FleetGrid(_fleetGrid.numOfRows, _fleetGrid.numOfRows);
                        squareEliminator = new SquareEliminator(_fleetGrid.numOfRows, _fleetGrid.numOfRows);
                        break;
                    }

                    int index = random.Next(availablePlacements.Count());
                    var selectedPlacement = availablePlacements.ElementAt(index);
                    fleet.CreateShip(selectedPlacement);

                    var squaresToEliminate = squareEliminator.ToEliminate(selectedPlacement);
                    foreach (var square in squaresToEliminate)
                    {
                        _fleetGrid.EliminateSquare(square.Row, square.Column);
                    }
                }
            } while (fleet.Ships.Count() != shipLengths.Count());

            return fleet;
        }
    }
}
