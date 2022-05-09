using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vsite.Battleship.Model;

namespace Vsite.Battleship
{
    [TestClass]
    public class TestInlineShooting
    {
        [TestMethod]
        public void For3_3and4_3InlineShootingTargetsIs2_3Or5_3()
        {
            var grid = new EnemyGrid(10, 10);
            grid.ChangeSquareState(3, 3, SquareState.Hit);
            grid.ChangeSquareState(4, 3, SquareState.Hit);
            var inlineShooting = new InlineShooting(grid, new List<Square>()
                {
                    new Square(3, 3),
                    new Square(4, 3),
                }
            );

            var candidates = new List<Square>()
            {
                new Square(2, 3),
                new Square(5, 3),

            };

            var nextTarget = inlineShooting.NextTarget();

            Assert.IsTrue(candidates.Contains(nextTarget));
        }


        [TestMethod]
        public void For4_3and3_3InlineShootingTargetsIs2_3Or5_3()
        {
            var grid = new EnemyGrid(10, 10);
            grid.ChangeSquareState(4, 3, SquareState.Hit);
            grid.ChangeSquareState(3, 3, SquareState.Hit);
            var inlineShooting = new InlineShooting(grid, new List<Square>()
                {
                    new Square(4, 3),
                    new Square(3, 3),
                }
            );

            var candidates = new List<Square>()
            {
                new Square(2, 3),
                new Square(5, 3),

            };

            var nextTarget = inlineShooting.NextTarget();

            Assert.IsTrue(candidates.Contains(nextTarget));
        }

        [TestMethod]
        public void For3_4and3_3InlineShootingTargetsIs3_2Or3_5()
        {
            var grid = new EnemyGrid(10, 10);
            grid.ChangeSquareState(3, 3, SquareState.Hit);
            grid.ChangeSquareState(3, 4, SquareState.Hit);
            var inlineShooting = new InlineShooting(grid, new List<Square>()
                {
                    new Square(3, 3),
                    new Square(3, 4),
                }
            );

            var candidates = new List<Square>()
            {
                new Square(3, 2),
                new Square(3, 5),
            };

            var nextTarget = inlineShooting.NextTarget();

            Assert.IsTrue(candidates.Contains(nextTarget));
        }

        [TestMethod]
        public void For1_0and1_1InlineShootingTargetsIs1_2()
        {
            var grid = new EnemyGrid(10, 10);
            grid.ChangeSquareState(1, 0, SquareState.Hit);
            grid.ChangeSquareState(1, 1, SquareState.Hit);
            var inlineShooting = new InlineShooting(grid, new List<Square>()
                {
                    new Square(1, 0),
                    new Square(1, 1),
                }
            );

            var candidates = new List<Square>()
            {
                new Square(1, 2),
            };

            var nextTarget = inlineShooting.NextTarget();

            Assert.IsTrue(candidates.Contains(nextTarget));
        }

        [TestMethod]
        public void For0_1and1_1InlineShootingTargetsIs2_1()
        {
            var grid = new EnemyGrid(10, 10);
            grid.ChangeSquareState(0, 1, SquareState.Hit);
            grid.ChangeSquareState(1, 1, SquareState.Hit);
            var inlineShooting = new InlineShooting(grid, new List<Square>()
                {
                    new Square(0, 1),
                    new Square(1, 1),
                }
            );

            var candidates = new List<Square>()
            {
                new Square(2, 1),
            };

            var nextTarget = inlineShooting.NextTarget();

            Assert.IsTrue(candidates.Contains(nextTarget));
        }

        [TestMethod]
        public void For1_9and1_8InlineShootingTargetsIs1_7()
        {
            var grid = new EnemyGrid(10, 10);
            grid.ChangeSquareState(1, 9, SquareState.Hit);
            grid.ChangeSquareState(1, 8, SquareState.Hit);
            var inlineShooting = new InlineShooting(grid, new List<Square>()
                {
                    new Square(1, 9),
                    new Square(1, 8),
                }
            );

            var candidates = new List<Square>()
            {
                new Square(1, 7),
            };

            var nextTarget = inlineShooting.NextTarget();

            Assert.IsTrue(candidates.Contains(nextTarget));
        }

        [TestMethod]
        public void For9_1and8_1InlineShootingTargetsIs7_1()
        {
            var grid = new EnemyGrid(10, 10);
            grid.ChangeSquareState(9, 1, SquareState.Hit);
            grid.ChangeSquareState(8, 1, SquareState.Hit);
            var inlineShooting = new InlineShooting(grid, new List<Square>()
                {
                    new Square(9, 1),
                    new Square(8, 1),
                }
            );

            var candidates = new List<Square>()
            {
                new Square(7, 1),
            };

            var nextTarget = inlineShooting.NextTarget();

            Assert.IsTrue(candidates.Contains(nextTarget));
        }
    }
}