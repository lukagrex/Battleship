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
        public void ForEmptyGridSurroundingShootingTargetsOneOfSquaresAroundHitOne()
        {
            var grid = new EnemyGrid(10, 10);
            grid.ChangeSquareState(3, 3, SquareState.Hit);
            var surroundingShooting = new SurroundingShooting(grid, new Square(3, 3));

            var candidates = new List<Square>()
            {
                new Square(2, 3),
                new Square(4, 3),
                new Square(3, 2),
                new Square(3, 4),

            };

            var nextTarget = surroundingShooting.NextTarget();

            Assert.IsTrue(candidates.Contains(nextTarget));
        }


        [TestMethod]
        public void ForEmptyGridSurroundingShootingTargetsOneOfSquaresAroundHitOneMarked2_3()
        {
            var grid = new EnemyGrid(10, 10);
            grid.ChangeSquareState(3, 3, SquareState.Hit);
            grid.ChangeSquareState(2, 3, SquareState.Hit);
            var surroundingShooting = new SurroundingShooting(grid, new Square(3, 3));

            var candidates = new List<Square>()
            {
                new Square(4, 3),
                new Square(3, 2),
                new Square(3, 4),

            };

            var nextTarget = surroundingShooting.NextTarget();

            Assert.IsTrue(candidates.Contains(nextTarget));
        }

        [TestMethod]
        public void ForEmptyGridSurroundingShootingTargetsOneOfSquaresAroundHitOneMarked4_3()
        {
            var grid = new EnemyGrid(10, 10);
            grid.ChangeSquareState(3, 3, SquareState.Hit);
            grid.ChangeSquareState(4, 3, SquareState.Hit);
            var surroundingShooting = new SurroundingShooting(grid, new Square(3, 3));

            var candidates = new List<Square>()
            {
                new Square(2, 3),
                new Square(3, 2),
                new Square(3, 4),

            };

            var nextTarget = surroundingShooting.NextTarget();

            Assert.IsTrue(candidates.Contains(nextTarget));
        }

        [TestMethod]
        public void ForEmptyGridSurroundingShootingTargetsOneOfSquaresAroundHitOneMarked3_2()
        {
            var grid = new EnemyGrid(10, 10);
            grid.ChangeSquareState(3, 3, SquareState.Hit);
            grid.ChangeSquareState(3, 2, SquareState.Hit);
            var surroundingShooting = new SurroundingShooting(grid, new Square(3, 3));

            var candidates = new List<Square>()
            {
                new Square(2, 3),
                new Square(4, 3),
                new Square(3, 4),

            };

            var nextTarget = surroundingShooting.NextTarget();

            Assert.IsTrue(candidates.Contains(nextTarget));
        }

        [TestMethod]
        public void ForEmptyGridSurroundingShootingTargetsOneOfSquaresAroundHitOneMarked3_4()
        {
            var grid = new EnemyGrid(10, 10);
            grid.ChangeSquareState(3, 3, SquareState.Hit);
            grid.ChangeSquareState(3, 4, SquareState.Hit);
            var surroundingShooting = new SurroundingShooting(grid, new Square(3, 3));

            var candidates = new List<Square>()
            {
                new Square(2, 3),
                new Square(4, 3),
                new Square(3, 2),

            };

            var nextTarget = surroundingShooting.NextTarget();

            Assert.IsTrue(candidates.Contains(nextTarget));
        }


        [TestMethod]
        public void ForEmptyGridSurroundingShootingTargetsOneOfSquaresAroundHitTwoMarked2_3And4_3()
        {
            var grid = new EnemyGrid(10, 10);
            grid.ChangeSquareState(3, 3, SquareState.Hit);
            grid.ChangeSquareState(2, 3, SquareState.Hit);
            grid.ChangeSquareState(4, 3, SquareState.Hit);
            var surroundingShooting = new SurroundingShooting(grid, new Square(3, 3));

            var candidates = new List<Square>()
            {
                new Square(3, 4),
                new Square(3, 2),

            };

            var nextTarget = surroundingShooting.NextTarget();

            Assert.IsTrue(candidates.Contains(nextTarget));
        }

        [TestMethod]
        public void ForEmptyGridSurroundingShootingTargetsOneOfSquaresAroundHitTwoMarked2_3And3_2()
        {
            var grid = new EnemyGrid(10, 10);
            grid.ChangeSquareState(3, 3, SquareState.Hit);
            grid.ChangeSquareState(2, 3, SquareState.Hit);
            grid.ChangeSquareState(3, 2, SquareState.Hit);
            var surroundingShooting = new SurroundingShooting(grid, new Square(3, 3));

            var candidates = new List<Square>()
            {
                new Square(3, 4),
                new Square(4, 3),

            };

            var nextTarget = surroundingShooting.NextTarget();

            Assert.IsTrue(candidates.Contains(nextTarget));
        }

        [TestMethod]
        public void ForEmptyGridSurroundingShootingTargetsOneOfSquaresAroundHitTwoMarked2_3And3_4()
        {
            var grid = new EnemyGrid(10, 10);
            grid.ChangeSquareState(3, 3, SquareState.Hit);
            grid.ChangeSquareState(2, 3, SquareState.Hit);
            grid.ChangeSquareState(3, 4, SquareState.Hit);
            var surroundingShooting = new SurroundingShooting(grid, new Square(3, 3));

            var candidates = new List<Square>()
            {
                new Square(3, 2),
                new Square(4, 3),

            };

            var nextTarget = surroundingShooting.NextTarget();

            Assert.IsTrue(candidates.Contains(nextTarget));
        }

        [TestMethod]
        public void ForEmptyGridSurroundingShootingTargetsOneOfSquaresAroundHitTwoMarked4_3And3_4()
        {
            var grid = new EnemyGrid(10, 10);
            grid.ChangeSquareState(3, 3, SquareState.Hit);
            grid.ChangeSquareState(4, 3, SquareState.Hit);
            grid.ChangeSquareState(3, 4, SquareState.Hit);
            var surroundingShooting = new SurroundingShooting(grid, new Square(3, 3));

            var candidates = new List<Square>()
            {
                new Square(3, 2),
                new Square(2, 3),

            };

            var nextTarget = surroundingShooting.NextTarget();

            Assert.IsTrue(candidates.Contains(nextTarget));
        }

        [TestMethod]
        public void ForEmptyGridSurroundingShootingTargetsOneOfSquaresAroundHitTwoMarked4_3And3_2()
        {
            var grid = new EnemyGrid(10, 10);
            grid.ChangeSquareState(3, 3, SquareState.Hit);
            grid.ChangeSquareState(4, 3, SquareState.Hit);
            grid.ChangeSquareState(3, 2, SquareState.Hit);
            var surroundingShooting = new SurroundingShooting(grid, new Square(3, 3));

            var candidates = new List<Square>()
            {
                new Square(3, 4),
                new Square(2, 3),

            };

            var nextTarget = surroundingShooting.NextTarget();

            Assert.IsTrue(candidates.Contains(nextTarget));
        }


        [TestMethod]
        public void ForEmptyGridSurroundingShootingTargetsOneOfSquaresAroundHitTwoMarked3_2And3_4()
        {
            var grid = new EnemyGrid(10, 10);
            grid.ChangeSquareState(3, 3, SquareState.Hit);
            grid.ChangeSquareState(3, 2, SquareState.Hit);
            grid.ChangeSquareState(3, 4, SquareState.Hit);
            var surroundingShooting = new SurroundingShooting(grid, new Square(3, 3));

            var candidates = new List<Square>()
            {
                new Square(4, 3),
                new Square(2, 3),

            };

            var nextTarget = surroundingShooting.NextTarget();

            Assert.IsTrue(candidates.Contains(nextTarget));
        }


        [TestMethod]
        public void ForEmptyGridSurroundingShootingTargetsOneOfSquaresAroundHitThreeMarked2_3And4_3And3_2()
        {
            var grid = new EnemyGrid(10, 10);
            grid.ChangeSquareState(3, 3, SquareState.Hit);
            grid.ChangeSquareState(2, 3, SquareState.Hit);
            grid.ChangeSquareState(4, 3, SquareState.Hit);
            grid.ChangeSquareState(3, 2, SquareState.Hit);

            var surroundingShooting = new SurroundingShooting(grid, new Square(3, 3));

            var candidates = new List<Square>()
            {
                new Square(3, 4),
            };

            var nextTarget = surroundingShooting.NextTarget();

            Assert.IsTrue(candidates.Contains(nextTarget));
        }

        [TestMethod]
        public void ForEmptyGridSurroundingShootingTargetsOneOfSquaresAroundHitThreeMarked2_3And4_3And3_4()
        {
            var grid = new EnemyGrid(10, 10);
            grid.ChangeSquareState(3, 3, SquareState.Hit);
            grid.ChangeSquareState(2, 3, SquareState.Hit);
            grid.ChangeSquareState(4, 3, SquareState.Hit);
            grid.ChangeSquareState(3, 4, SquareState.Hit);

            var surroundingShooting = new SurroundingShooting(grid, new Square(3, 3));

            var candidates = new List<Square>()
            {
                new Square(3, 2),
            };

            var nextTarget = surroundingShooting.NextTarget();

            Assert.IsTrue(candidates.Contains(nextTarget));
        }

        [TestMethod]
        public void ForEmptyGridSurroundingShootingTargetsOneOfSquaresAroundHitThreeMarked2_3And3_2And3_4()
        {
            var grid = new EnemyGrid(10, 10);
            grid.ChangeSquareState(3, 3, SquareState.Hit);
            grid.ChangeSquareState(2, 3, SquareState.Hit);
            grid.ChangeSquareState(3, 2, SquareState.Hit);
            grid.ChangeSquareState(3, 4, SquareState.Hit);

            var surroundingShooting = new SurroundingShooting(grid, new Square(3, 3));

            var candidates = new List<Square>()
            {
                new Square(4, 3),
            };

            var nextTarget = surroundingShooting.NextTarget();

            Assert.IsTrue(candidates.Contains(nextTarget));
        }

        [TestMethod]
        public void ForEmptyGridSurroundingShootingTargetsOneOfSquaresAroundHitThreeMarked4_3And3_2And3_4()
        {
            var grid = new EnemyGrid(10, 10);
            grid.ChangeSquareState(3, 3, SquareState.Hit);
            grid.ChangeSquareState(4, 3, SquareState.Hit);
            grid.ChangeSquareState(3, 2, SquareState.Hit);
            grid.ChangeSquareState(3, 4, SquareState.Hit);

            var surroundingShooting = new SurroundingShooting(grid, new Square(3, 3));

            var candidates = new List<Square>()
            {
                new Square(2, 3),
            };

            var nextTarget = surroundingShooting.NextTarget();

            Assert.IsTrue(candidates.Contains(nextTarget));
        }
    }
}
