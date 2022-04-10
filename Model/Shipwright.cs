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
            grid = new Grid(rows, columns);
            this.shipLengths = shipLengths;
            squareEliminator = new SquareEliminator(rows, columns);
        }

        private Fleet fleet = new Fleet();
        private Grid grid;
        private IEnumerable<int> shipLengths;
        private Random random = new Random();
        private SquareEliminator squareEliminator;

        public Fleet CreateFleet()
        { 
            //get { return fleet; } 
            foreach (int shipLength in shipLengths)
            {
                var availablePlacements = grid.GetAvailablePlacements(shipLength);
                int index = random.Next(availablePlacements.Count());
                var selectedPlacements = availablePlacements.ElementAt(index);
                fleet.CreateShip(selectedPlacements);
                var toEliminate = squareEliminator.ToEliminate(selectedPlacements);
                foreach (var square in toEliminate)
                {
                    grid.EliminateSquare(square.Row, square.Column);
                }
            }

            return fleet;

        }
    }
}
