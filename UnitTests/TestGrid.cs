using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Vsite.Battleship.Model;

namespace Vsite.Battleship
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
        public void GetAvailablePlacementsReturns2PlacmentsForAShip3SquaresLongOnGrid1Rows4Columns()
        {
            var grid = new Grid(1, 4);

            var availablePlacements = grid.GetAvailablePlacements(3);

            Assert.AreEqual(2, availablePlacements.Count());
        }


        [TestMethod]
        public void GetAvailablePlacementsReturns2PlacmentsForAShip3SquaresLongOnGrid5Rows1Columns()
        {
            var grid = new Grid(5, 1);

            var availablePlacements = grid.GetAvailablePlacements(3);

            Assert.AreEqual(3, availablePlacements.Count());
        }
    }
}
