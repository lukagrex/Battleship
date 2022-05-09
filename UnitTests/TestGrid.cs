using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
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
            Grid grid = new Grid(10, 10);
            Assert.AreEqual(100, grid.Squares.Count());
            Assert.IsTrue(grid.Squares.Contains(new Square(0, 0)));
            Assert.IsTrue(grid.Squares.Contains(new Square(9, 9)));
            Assert.IsTrue(grid.Squares.Contains(new Square(0, 9)));
            Assert.IsTrue(grid.Squares.Contains(new Square(9, 0)));
        }

        [TestMethod]
        public void GetAvailablePlacementsReturns2PlacementsForAShip3SquaresLongOnGrid1Row4Columns()
        {
            Grid grid = new Grid(1, 4);
            var placements = grid.GetAvailablePlacements(3);
            Assert.AreEqual(2, placements.Count());
        }

        [TestMethod]
        public void GetAvailablePlacementsReturns3PlacementsForAShip3SquaresLongOnGrid5Rows1Column()
        {
            Grid grid = new Grid(5, 1);
            var placements = grid.GetAvailablePlacements(3);
            Assert.AreEqual(3, placements.Count());
        }

        [TestMethod]
        public void GetAvailablePlacementsReturns3PlacementsForAShip2SquaresLongOnGrid1Row6ColumnsAfterSquareInColumn2IsElimanated()
        {
            Grid grid = new Grid(1, 6);
            grid.EliminateSquare(0, 2);
            Assert.AreEqual(5, grid.Squares.Count());
            var placements = grid.GetAvailablePlacements(2);
            Assert.AreEqual(3, placements.Count());
        }
        [TestMethod]
        public void GetAvailableSquaresReturns3SquaresLeftToSquare8_3OnGrid10x10()
        {
            Grid grid = new Grid(10, 10);
            var result = grid.GetAvailableSquares(8, 3, Direction.Leftwards);
            Assert.AreEqual(3, result.Count());
        }
        [TestMethod]
        public void GetAvailableSquaresReturns1SquareLeftToSquare8_3OnGrid10x10IfSquare8_1IsMarkedMissed()
        {
            Grid grid = new Grid(10, 10);
            grid.ChangeSquareState(8, 1, SquareState.Missed);
            var result = grid.GetAvailableSquares(8, 3, Direction.Leftwards);
            Assert.AreEqual(1, result.Count());
        }
        [TestMethod]
        public void GetAvailableSquaresReturns6SquaresRightToSquare8_3OnGrid10x10()
        {
            Grid grid = new Grid(10, 10);
            var result = grid.GetAvailableSquares(8, 3, Direction.Rightwards);
            Assert.AreEqual(6, result.Count());
        }
        [TestMethod]
        public void GetAvailableSquaresReturns4SquaresRightToSquare8_3OnGrid10x10IfSquare8_8IsMarkedHit()
        {
            Grid grid = new Grid(10, 10);
            grid.ChangeSquareState(8, 8, SquareState.Hit);
            var result = grid.GetAvailableSquares(8, 3, Direction.Rightwards);
            Assert.AreEqual(4, result.Count());
        }
        [TestMethod]
        public void GetAvailableSquaresReturns8SquaresAboveSquare8_3OnGrid10x10()
        {
            Grid grid = new Grid(10, 10);
            var result = grid.GetAvailableSquares(8, 3, Direction.Upwards);
            Assert.AreEqual(8, result.Count());
        }
        [TestMethod]
        public void GetAvailableSquaresReturn7SquaresAboveSquare8_3OnGrid10x10IfSquare0_3IsMarkedSunken()
        {
            Grid grid = new Grid(10, 10);
            grid.ChangeSquareState(0, 3, SquareState.Sunken);
            var result = grid.GetAvailableSquares(8, 3, Direction.Upwards);
            Assert.AreEqual(7, result.Count());
        }
        [TestMethod]
        public void GetAvailableSquaresReturns1SquareBelowSquare8_3OnGrid10x10()
        {
            Grid grid = new Grid(10, 10);
            var result = grid.GetAvailableSquares(8, 3, Direction.Bottomwards);
            Assert.AreEqual(1, result.Count());
        }
        [TestMethod]
        public void GetAvailableSquaresReturns0SquaresBelowSquare8_3OnGrid10x10IfSquare9_3IsMarkedMissed()
        {
            Grid grid = new Grid(10, 10);
            grid.ChangeSquareState(9, 3, SquareState.Missed);
            var result = grid.GetAvailableSquares(8, 3, Direction.Bottomwards);
            Assert.AreEqual(0, result.Count());
        }
    }
}
