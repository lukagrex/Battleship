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
    public class TestGrid
    {
        [TestMethod]
        public void ConstructorCreatesGridOf100SquaresForAGridWith10Rows10Columns()
        {
            var grid = new Grid(10, 10);

            Assert.AreEqual(true, grid.Squares.Contains(new Square(0, 0)));
            Assert.AreEqual(true, grid.Squares.Contains(new Square(2, 2)));
            Assert.AreEqual(true, grid.Squares.Contains(new Square(4, 4)));
            Assert.AreEqual(true, grid.Squares.Contains(new Square(9, 9)));

            Assert.AreEqual(100, grid.Squares.Count());
        }

        [TestMethod]
        public void TGetAvailablePlacementsReturns2PlacementsForAShip3SquaresLongOnGrid1Row4Columns()
        {
            Grid grid = new Grid(1, 4);
            var placements = grid.GetAvailablePlacements(3);
            Assert.AreEqual(2, placements.Count());
        }

        [TestMethod]
        public void TGetAvailablePlacementsReturns3PlacementsForAShip3SquaresLongOnGrid5Rows1Column()
        {
            Grid grid = new Grid(5, 1);
            var placements = grid.GetAvailablePlacements(3);
            Assert.AreEqual(3, placements.Count());
        }
    }
}
