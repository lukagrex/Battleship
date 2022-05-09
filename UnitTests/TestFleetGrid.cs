using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;

namespace UnitTests
{
    [TestClass]
    public class TestFleetGrid
    {
        [TestMethod]
        public void ConstructorCreatesGridOf100SquaresForAGridWith10Rows10Columns()
        {
            FleetGrid fleetGrid = new FleetGrid(10, 10);
            Assert.AreEqual(100, fleetGrid.Squares.Count());
            Assert.IsTrue(fleetGrid.Squares.Contains(new Square(0, 0)));
            Assert.IsTrue(fleetGrid.Squares.Contains(new Square(9, 9)));
            Assert.IsTrue(fleetGrid.Squares.Contains(new Square(0, 9)));
            Assert.IsTrue(fleetGrid.Squares.Contains(new Square(9, 0)));
        }

        [TestMethod]
        public void GetAvailablePlacements_Returns2PlacementsForAShip3SquaresLongOnGrid1Row4Columns()
        {
            FleetGrid fleetGrid = new FleetGrid(1, 4);
            var placements = fleetGrid.GetAvailablePlacements(3);
            Assert.AreEqual(2, placements.Count());
        }

        [TestMethod]
        public void GetAvailablePlacements_Returns3PlacementsForAShip3SquaresLongOnGrid5Rows1Column()
        {
            FleetGrid fleetGrid = new FleetGrid(5, 1);
            var placements = fleetGrid.GetAvailablePlacements(3);
            Assert.AreEqual(3, placements.Count());
        }

        [TestMethod]
        public void GetAvailablePlacements_Returns3PlacementsForAShip2SquaresLongOnGrid1Row6ColumnsAfterSquareInColumn2IsEliminated()
        {
            FleetGrid fleetGrid = new FleetGrid(1, 6);
            fleetGrid.EliminateSquare(0,2);
            Assert.AreEqual(5, fleetGrid.Squares.Count());

            var placements = fleetGrid.GetAvailablePlacements(2);
            Assert.AreEqual(3, placements.Count());
        }

        [TestMethod]
        public void GetAvailablePlacements_Returns3PlacementsForAShip2SquaresLongOnGrid6Rows1ColumnAfterSquareInColumn2IsEliminated()
        {
            FleetGrid fleetGrid = new FleetGrid(6, 1);
            fleetGrid.EliminateSquare(2, 0);
            Assert.AreEqual(5, fleetGrid.Squares.Count());

            var placements = fleetGrid.GetAvailablePlacements(2);
            Assert.AreEqual(3, placements.Count());
        }
    }
}
