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

        public Shipwright(int rows, int columns, IEnumerable<int> shipLengths)
        {
            grid = new Grid(rows, columns);
            squareEliminator = new SquareEliminator(rows, columns);
            this.shipLengths = shipLengths;
        }


        public Fleet CreateFleet()
        {
            var fleet = new Fleet();

            foreach (var shipLength in shipLengths)
            {

                var availablePlacements = grid.GetAvailablePlacements(shipLength);
                if (availablePlacements.Count() == 0)
                {
                    //TODO dodaj petlju oko ovog koda i istraži jel ok
                    break;
                }

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
