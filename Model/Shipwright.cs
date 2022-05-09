using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vsite.BattleShip.Model
{
    public  class Shipwright
    {
        private IEnumerable<int> shipLengths;

        private FleetGrid grid;

        private Random random = new Random();

        private SquareEliminator squareEliminator;

        private readonly int rows;
        private readonly int columns;

        public Shipwright(int rows, int columns, IEnumerable<int> shipLengths)
        {
            this.shipLengths = shipLengths;
            this.rows= rows;
            this.columns = columns;
        }

        public Fleet CreateFleet()
        {
            Fleet fleet;
            int cnt = 0;

            do
            {
                this.grid = new FleetGrid(this.rows, this.columns);
                this.squareEliminator = new SquareEliminator(this.rows, this.columns);
                fleet = new Fleet();

                foreach (var shipLength in this.shipLengths)
                {
                    var availablePlacements = grid.GetAvailablePlacements(shipLength);
                    if (!availablePlacements.Any())
                    {
                        break;
                    }

                    // Random select one available placement
                    int index = random.Next(availablePlacements.Count());
                    var selectedPlacement = availablePlacements.ElementAt(index);

                    // Create Ship
                    fleet.CreateShip(selectedPlacement);

                    // Eliminate squares
                    var toEliminate = this.squareEliminator.ToEliminate(selectedPlacement);
                    foreach (var square in toEliminate)
                    {
                        grid.EliminateSquares(square.Row, square.Column);
                    }
                }

                cnt++;
                // To avoid long running calculation make some limitation
                if (cnt > 1000)
                {
                    // TODO
                    // Change strategy
                    // The biggest put in the corner or.....
                    throw new NotImplementedException();
                }

            } while (fleet.Ships.Count() != this.shipLengths.Count());

            return fleet;
        }

    }
}
