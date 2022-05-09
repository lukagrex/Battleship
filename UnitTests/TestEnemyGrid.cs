using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Vsite.Battleship.Model;

namespace Vsite.Battleship
{
    [TestClass]
    public class TestEnemyGrid
    {
        [TestMethod]
        public void GetAvailableSquaresReturns3SquaresLeftToSquare8_3OnGrid10x10()
        {
            EnemyGrid grid = new EnemyGrid(10, 10);
            var result = grid.GetAvailableSquares(8, 3, Direction.Leftwards);
            Assert.AreEqual(3, result.Count());
        }
        [TestMethod]
        public void GetAvailableSquaresReturns1SquareLeftToSquare8_3OnGrid10x10IfSquare8_1IsMarkedMissed()
        {
            EnemyGrid grid = new EnemyGrid(10, 10);
            grid.ChangeSquareState(8, 1, SquareState.Missed);
            var result = grid.GetAvailableSquares(8, 3, Direction.Leftwards);
            Assert.AreEqual(1, result.Count());
        }
        [TestMethod]
        public void GetAvailableSquaresReturns6SquaresRightToSquare8_3OnGrid10x10()
        {
            EnemyGrid grid = new EnemyGrid(10, 10);
            var result = grid.GetAvailableSquares(8, 3, Direction.Rightwards);
            Assert.AreEqual(6, result.Count());
        }
        [TestMethod]
        public void GetAvailableSquaresReturns4SquaresRightToSquare8_3OnGrid10x10IfSquare8_8IsMarkedHit()
        {
            EnemyGrid grid = new EnemyGrid(10, 10);
            grid.ChangeSquareState(8, 8, SquareState.Hit);
            var result = grid.GetAvailableSquares(8, 3, Direction.Rightwards);
            Assert.AreEqual(4, result.Count());
        }
        [TestMethod]
        public void GetAvailableSquaresReturns8SquaresAboveSquare8_3OnGrid10x10()
        {
            EnemyGrid grid = new EnemyGrid(10, 10);
            var result = grid.GetAvailableSquares(8, 3, Direction.Upwards);
            Assert.AreEqual(8, result.Count());
        }
        [TestMethod]
        public void GetAvailableSquaresReturn7SquaresAboveSquare8_3OnGrid10x10IfSquare0_3IsMarkedSunken()
        {
            EnemyGrid grid = new EnemyGrid(10, 10);
            grid.ChangeSquareState(0, 3, SquareState.Sunken);
            var result = grid.GetAvailableSquares(8, 3, Direction.Upwards);
            Assert.AreEqual(7, result.Count());
        }
        [TestMethod]
        public void GetAvailableSquaresReturns1SquareBelowSquare8_3OnGrid10x10()
        {
            EnemyGrid grid = new EnemyGrid(10, 10);
            var result = grid.GetAvailableSquares(8, 3, Direction.Bottomwards);
            Assert.AreEqual(1, result.Count());
        }
        [TestMethod]
        public void GetAvailableSquaresReturns0SquaresBelowSquare8_3OnGrid10x10IfSquare9_3IsMarkedMissed()
        {
            EnemyGrid grid = new EnemyGrid(10, 10);
            grid.ChangeSquareState(9, 3, SquareState.Missed);
            var result = grid.GetAvailableSquares(8, 3, Direction.Bottomwards);
            Assert.AreEqual(0, result.Count());
        }
    }
}
