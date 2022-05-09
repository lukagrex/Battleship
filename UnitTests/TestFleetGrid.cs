using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Vsite.Battleship.Model;

namespace Vsite.Battleship
{
    [TestClass]
    public class TestFleetGrid
    {
        [TestMethod]
        public void ConstructorCreatesGridOf100SquaresForAGridWith10Rows10Columns()
        {
            var fleetGrid = new FleetGrid(10, 10);
            Assert.AreEqual(100, fleetGrid.Squares.Count());
            Assert.IsTrue(fleetGrid.Squares.Contains(new Square(0, 0)));
            Assert.IsTrue(fleetGrid.Squares.Contains(new Square(9, 9)));
            Assert.IsTrue(fleetGrid.Squares.Contains(new Square(0, 9)));
            Assert.IsTrue(fleetGrid.Squares.Contains(new Square(9, 0)));
        }

        [TestMethod]
        public void GetAvailablePlacementsReturns2PlacementsForAShip3SquaresLongOnGrid1Rows4Columns()
        {
            var fleetGrid = new FleetGrid(1, 4);
            var placements = fleetGrid.GetAvailablePlacements(3);
            Assert.AreEqual(2, placements.Count());
        }

        [TestMethod]
        public void GetAvailablePlacementsReturns3PlacementsForAShip3SquaresLongOnGrid5Rows1Columns()
        {
            var fleetGrid = new FleetGrid(5, 1);
            var placements = fleetGrid.GetAvailablePlacements(3);
            Assert.AreEqual(3, placements.Count());
        }

        [TestMethod]
        public void
            GetAvailablePlacementsReturns3PlacementsForAShip2SquaresLongOnGrid1Row6ColumnsAfterSquareInColumn2IsEliminated()
        {
            var fleetGrid = new FleetGrid(1, 6);
            fleetGrid.EliminateSquare(0, 2);
            Assert.AreEqual(5, fleetGrid.Squares.Count());
            var placements = fleetGrid.GetAvailablePlacements(2);
            Assert.AreEqual(3, placements.Count());
        }

        [TestMethod]
        public void
            GetAvailablePlacementsReturns2PlacementsForAShip2SquaresLongOnGrid5Row1ColumnsAfterSquareInRow2IsEliminated()
        {
            var fleetGrid = new FleetGrid(5, 1);
            fleetGrid.EliminateSquare(2, 0);
            Assert.AreEqual(4, fleetGrid.Squares.Count());
            var placements = fleetGrid.GetAvailablePlacements(2);
            Assert.AreEqual(2, placements.Count());
        }

    }
}
