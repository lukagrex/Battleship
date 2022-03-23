using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Vsite.Battleship.Model;
using System.Linq;

namespace Vsite.Battleship
{
    [TestClass]
    public class TestGrid
    {
        [TestMethod]
        public void ConstructorCreatesGridOf100SquaresForAGridWith10Rows10Columns()
        {
            Grid grid = new Grid(10, 10);
            Assert.AreEqual(100, grid.Squares.Count());
            Assert.IsTrue(grid.Squares.Contains(new Square(0, 0)));
            Assert.IsTrue(grid.Squares.Contains(new Square(0, 9)));
            Assert.IsTrue(grid.Squares.Contains(new Square(9, 0)));
            Assert.IsTrue(grid.Squares.Contains(new Square(9, 9)));
        }


        [TestMethod]
        public void GetAvailablePlacementsReturns2PlacementsForAShip3SquaresLongOnGrid1Rowsx4Columns()
        {
            Grid grid = new Grid(1, 4);
            var placements = grid.GetAvailablePlacements(3);
            Assert.AreEqual(2, placements.Count());
        }

        [TestMethod]
        public void GetAvailablePlacementsReturns3PlacementsForAShip3SquaresLongOnGrid5Rowsx1Column()
        {
            Grid grid = new Grid(5, 1);
            var placements = grid.GetAvailablePlacements(3);
            Assert.AreEqual(3, placements.Count());
        }
    }
}
