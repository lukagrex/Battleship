﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Vsite.BattleShip.Model;

namespace Vsite.Battleship
{
    [TestClass]
    public class TestFleetGrid
    {
        [TestMethod]
        public void ConstructorCreatesGridOf100SquaresForAGridWith10Rows10Columns()
        {
            EnemyGrid grid = new EnemyGrid(10, 10);
            Assert.AreEqual(100, grid.Squares.Count());
            Assert.IsTrue(grid.Squares.Contains(new Square(0, 0)));
            Assert.IsTrue(grid.Squares.Contains(new Square(9, 9)));
            Assert.IsTrue(grid.Squares.Contains(new Square(0, 9)));
            Assert.IsTrue(grid.Squares.Contains(new Square(9, 0)));
        }

        [TestMethod]
        public void GetAvailablePlacementsReturns2PlacementsForAShip3SquaresLongOnGrid1Row4Columns()
        {
            FleetGrid grid = new FleetGrid(1, 4);
            var placements = grid.GetAvailablePlacements(3);
            Assert.AreEqual(2, placements.Count());
        }

        [TestMethod]
        public void GetAvailablePlacementsReturns3PlacementsForAShip3SquaresLongOnGrid5Rows1Column()
        {
            var grid = new FleetGrid(5, 1);
            var placements = grid.GetAvailablePlacements(3);
            Assert.AreEqual(3, placements.Count());
        }

        [TestMethod]
        public void GetAvailablePlacementsReturns3PlacementsForAShip2SquaresLongOnGrid1Row6ColumnsAfterSquareInColumn2IsElimanated()
        {
            var grid = new FleetGrid(1, 6);
            grid.EliminateSquare(0, 2);
            Assert.AreEqual(5, grid.Squares.Count());
            var placements = grid.GetAvailablePlacements(2);
            Assert.AreEqual(3, placements.Count());
        }
    }
}