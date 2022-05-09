﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Model
{
    public class Shipwright
    {
        private readonly IEnumerable<int> shipLengths;
        private readonly FleetGrid fleetGrid;
        private readonly Random random = new Random();
        private readonly SquareEliminator squareEliminator;

        public Shipwright(int rows, int columns, IEnumerable<int> shipLengths)
        {
            this.shipLengths = shipLengths;
            this.fleetGrid = new FleetGrid(rows, columns);
            this.squareEliminator = new SquareEliminator(rows, columns);
        }

        public Fleet CreateFleet()
        {
            var fleet = new Fleet();
            foreach (var shipLength in shipLengths)
            {
                var availablePlacements = this.fleetGrid.GetAvailablePlacements(shipLength);
                if (!availablePlacements.Any())
                {
                    break;
                }
                int index = random.Next(availablePlacements.Count());
                var selectedPlacements = availablePlacements.ElementAt(index);
                for (int i = 0; i < 3; i++)
                {
                    fleet.CreateShip(selectedPlacements);
                    if (fleet.Ships.Last().Squares.SequenceEqual(selectedPlacements))
                    {
                        break;
                    }

                    if (i == 2)
                    {
                        throw new ArgumentOutOfRangeException();
                    }
                }
                
                var toEliminate =squareEliminator.ToEliminate(selectedPlacements);
                foreach (var square in toEliminate)
                {
                    this.fleetGrid.EliminateSquare(square.Row, square.Column);
                }
            }
            return fleet;
        }
    }
}
