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
            grid = new FleetGrid(rows, columns);
            this.shipLengths = shipLengths;
            squareEliminator = new SquareEliminator(rows, columns);
        }

        //private Fleet fleet = new Fleet();
        private FleetGrid grid;
        private IEnumerable<int> shipLengths;
        private Random random = new Random();
        private SquareEliminator squareEliminator;

        public Fleet CreateFleet()
        {
            //get { return fleet; } 
            var fleet = new Fleet();
            do
            {
                foreach (int shipLength in shipLengths)
                {
                    var availablePlacements = grid.GetAvailablePlacements(shipLength);
                    if (!availablePlacements.Any())
                    {
                        fleet = new Fleet();
                        grid = new FleetGrid(grid.Rows, grid.Columns);
                        break;
                    }

                    int index = random.Next(availablePlacements.Count());
                    var selectedPlacements = availablePlacements.ElementAt(index);
                    fleet.CreateShip(selectedPlacements);
                    var toEliminate = squareEliminator.ToEliminate(selectedPlacements);
                    foreach (var square in toEliminate)
                    {
                        grid.EliminateSquare(square.Row, square.Column);
                    }
                }
            } while (fleet.Ships.Count() != shipLengths.Count());

            return fleet;
        }
    }
}
