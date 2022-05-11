using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vsite.Battleship.Model;
using System.Linq;
using System;

namespace Vsite.Battleship
{
    [TestClass]
    public class TestFleetGrid
    {
        [TestMethod]
        public void ConstructorCreatesGridOf100SquaresForAGridWith10Rows10Columns()
        {
            FleetGrid grid = new FleetGrid(10, 10);
            Assert.AreEqual(100, grid.Squares.Count());
            Assert.IsTrue(grid.Squares.Contains(new Square(0, 0)));
            Assert.IsTrue(grid.Squares.Contains(new Square(9, 0)));
            Assert.IsTrue(grid.Squares.Contains(new Square(9, 9)));
            Assert.IsTrue(grid.Squares.Contains(new Square(0, 9)));
        }


        [TestMethod]
        public void GetAvailablePlacementsReturns2PlacementsForAShip3SquaresLongOnGrid1Rows4Columns()
        {
            FleetGrid grid = new FleetGrid(1, 4);
            var placements = grid.GetAvailablePlacements(3);
            Assert.AreEqual(2, placements.Count());
        }

        [TestMethod]
        public void GetAvailablePlacementsReturns3PlacementsForAShip3SquaresLongOnGrid5Rows1Columns()
        {
            FleetGrid grid = new FleetGrid(5, 1);
            var placements = grid.GetAvailablePlacements(3);
            Assert.AreEqual(3, placements.Count());
        }

        [TestMethod]
        public void GetAvailablePlacementsReturns14PlacementsForAShip3SquaresLongOnGrid3Rows5Columns()
        {
            FleetGrid grid = new FleetGrid(3, 5);
            var placements = grid.GetAvailablePlacements(3);
            Assert.AreEqual(14, placements.Count());
        }

        [TestMethod]
        public void GetAlailablePlacementsReturns3PlacementsForAShip2SquaresLongOnGrid1Row6ColumnsAfterSquareInColumn2IsEliminated()
        {
            FleetGrid grid = new FleetGrid(1, 6);
            grid.EliminateSquare(0, 2);
            Assert.AreEqual(5, grid.Squares.Count());
            var placements = grid.GetAvailablePlacements(2);
            Assert.AreEqual(3, placements.Count());
        }

        [TestMethod]
        public void GetAlailablePlacementsReturns3PlacementsForAShip2SquaresTallOnGrid6Rows1ColumnAfterSquareInRow2IsEliminated()
        {
            FleetGrid grid = new FleetGrid(6, 1);
            grid.EliminateSquare(2, 0);
            Assert.AreEqual(5, grid.Squares.Count());
            var placements = grid.GetAvailablePlacements(2);
            Assert.AreEqual(3, placements.Count());
        }
    }
}