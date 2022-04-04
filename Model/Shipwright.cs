using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vsite.BattleShip.Model
{
    public class Shipwright
    {
        private Fleet fleet = new Fleet();
        private Grid grid;
        private IEnumerable<int> shipLengths;
        private Random random = new Random();
        private SquareEliminator squareEliminator;
        public Shipwright(int rows,int columns, IEnumerable<int> shipLengths)
        {
            grid = new Grid(rows, columns);
            this.shipLengths = shipLengths;
            squareEliminator = new SquareEliminator(rows, columns);
        }
        public Fleet CreateFleet()
        {
            Fleet fleet = new Fleet();
            foreach(int shipLength in shipLengths)
            {
                var availablePlacements = grid.GetAvailablePlacements(shipLength);
                int index = random.Next(availablePlacements.Count());
                var selectedPlacement = availablePlacements.ElementAt(index);
                fleet.CreateShip(selectedPlacement);
                var toEliminate = squareEliminator.ToEliminate(selectedPlacement);
                foreach (var square in toEliminate)
                {
                    grid.EliminateSquare(square.Row, square.Column);
                }
            }
            return fleet;
        }

       
    }
}
