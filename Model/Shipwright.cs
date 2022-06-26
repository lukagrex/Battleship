using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vsite.Battleship.Model
{
    public class Shipwright
    {
        public Shipwright(int rows, int columns, IEnumerable<int> shipLengths)
        {
            this.shipLengths = shipLengths;
            squareEliminator = new SquareEliminator(rows, columns);
            fleetGrid = new FleetGrid(rows, columns);
        }

        private FleetGrid fleetGrid;
        private IEnumerable<int> shipLengths;
        private Random random = new Random(Guid.NewGuid().GetHashCode());
        private SquareEliminator squareEliminator;

        /*
        public Fleet CreateFleet()
        {
            for (int i = 0; i < 3; ++i)
            {
                var fleet = BuildFleet();
                if (fleet != null)
                    return fleet;
            }
            throw new InvalidOperationException();
        }
        */

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
                        fleetGrid = new FleetGrid(fleetGrid.Columns, fleetGrid.Rows);
                        squareEliminator = new SquareEliminator(fleetGrid.Rows, fleetGrid.Columns);
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

        private Fleet BuildFleet()
        {
            Fleet fleet = new Fleet();
            foreach (int shipLength in shipLengths)
            {
                var availablePlacements = fleetGrid.GetAvailablePlacements(shipLength);
                if (availablePlacements.Count() == 0)
                    return null;
                int index = random.Next(availablePlacements.Count());
                var selectedPlacement = availablePlacements.ElementAt(index);
                fleet.CreateShip(selectedPlacement);
                var toEliminate = squareEliminator.ToEliminate(selectedPlacement);
                foreach (var square in toEliminate)
                {
                    fleetGrid.EliminateSquare(square.Row, square.Column);
                }
            }
            return fleet;
        }

    }
}
