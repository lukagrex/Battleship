using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Model;

namespace UnitTests
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class TestSurroundingShooting
    {
        [TestMethod]
        public void EmptyGrid_SurroundingShootingTargetsOneOfSquaresAround_HitOne()
        {
            var grid = new EnemyGrid(10, 10);
            var firstHit = new Square(3, 3);
            int shipLength = 3;

            var surroundingShooting = new SurroundingShooting(grid, firstHit, shipLength);
            var next = surroundingShooting.NextTarget();
            var candidates = new List<Square>
            {
                new Square(3, 2),
                new Square(3, 4),
                new Square(2, 3),
                new Square(4, 3)
            };

            CollectionAssert.Contains(candidates, next);
        }

        [TestMethod]
        public void EmptyGrid_SurroundingShootingTargetsOnlySquaresThatAreNotMarked1()
        {
            var grid = new EnemyGrid(10, 10);
            grid.ChangeSquareState(3, 2, SquareState.Hit);

            var firstHit = new Square(3, 3);
            int shipLength = 3;

            var surroundingShooting = new SurroundingShooting(grid, firstHit, shipLength);
            var next = surroundingShooting.NextTarget();
            var candidates = new List<Square>
            {
                new Square(3, 4),
                new Square(2, 3),
                new Square(4, 3)
            };

            CollectionAssert.Contains(candidates, next);
        }

        [TestMethod]
        public void EmptyGrid_SurroundingShootingTargetsOnlySquaresThatAreNotMarked2()
        {
            var grid = new EnemyGrid(10, 10);
            grid.ChangeSquareState(3, 2, SquareState.Hit);
            grid.ChangeSquareState(3, 4, SquareState.Hit);

            var firstHit = new Square(3, 3);
            int shipLength = 3;

            var surroundingShooting = new SurroundingShooting(grid, firstHit, shipLength);
            var next = surroundingShooting.NextTarget();
            var candidates = new List<Square>
            {
                new Square(2, 3),
                new Square(4, 3)
            };

            CollectionAssert.Contains(candidates, next);
        }

        [TestMethod]
        public void EmptyGrid_SurroundingShootingTargetsOnlySquaresThatAreNotMarked3()
        {
            var grid = new EnemyGrid(10, 10);
            grid.ChangeSquareState(3, 2, SquareState.Hit);
            grid.ChangeSquareState(3, 4, SquareState.Hit);
            grid.ChangeSquareState(4, 3, SquareState.Hit);


            var firstHit = new Square(3, 3);
            int shipLength = 3;

            var surroundingShooting = new SurroundingShooting(grid, firstHit, shipLength);
            var next = surroundingShooting.NextTarget();

            Assert.AreEqual(new Square(2, 3), next);
        }
        //TODO popraviti testove i kod za testove
    }
}
