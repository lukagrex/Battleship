using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Vsite.BattleShip.Model;

namespace Vsite.BattleShip.UnitTests
{
    [TestClass]
    public class TestGrid
    {
        [TestMethod]
        public void ConstructorCreatesGridOf100SquaresForGridWith10Rows10Columns()
        {
            var grid = new Grid(10, 10);
            Assert.AreEqual(100, grid.Squares.Count());
            Assert.IsTrue(grid.Squares.Contains(new Square(0, 0)));
            Assert.IsTrue(grid.Squares.Contains(new Square(9, 9)));
            Assert.IsTrue(grid.Squares.Contains(new Square(0, 9)));
            Assert.IsTrue(grid.Squares.Contains(new Square(9, 0)));
        }

        [TestMethod]
        public void GetAvailablePlacementsReturns2PlacementsForShip3SquaresOnGrid1Row4Columns()
        {
            var grid = new Grid(1, 4);
            var placements = grid.GetAvailablePlacements(3);
            Assert.AreEqual(2, placements.Count());
        }

        [TestMethod]
        public void GetAvailablePlacementsReturns2PlacementsForShip3SquaresOnGrid5Rows1Column()
        {
            var grid = new Grid(5, 1);
            var placements = grid.GetAvailablePlacements(3);
            Assert.AreEqual(3, placements.Count());
        }

        [TestMethod]
        public void GetAvailablePlacementsReturns3PlacementsForShip2SquaresLongOnGrid5Rows1Row6ColumnAfterSquareInColumn2IsEliminated()
        {
            var grid = new Grid(1, 6);
            grid.EliminateSquares(0, 2);
            Assert.AreEqual(5, grid.Squares.Count());

            var placements = grid.GetAvailablePlacements(2);
            Assert.AreEqual(3, placements.Count());
        }
    }
}
