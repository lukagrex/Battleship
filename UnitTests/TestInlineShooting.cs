using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Model;

namespace UnitTests
{
    [TestClass]
    public class TestInlineShooting
    {
        [TestMethod]
        public void NextTargetIsSquare2x3OrSquare5x3AfterSquares3x3And4x3AreHit()
        {
            var grid = new EnemyGrid(10, 10);

            var squaresAlreadyHit = new List<Square> 
            {
                new Square(3,4), 
                new Square(4,3)

            };
            var inline = new InlineShooting(grid, squaresAlreadyHit, 5);
            var target = inline.NextTarget();

            var expected = new List<Square>
            {
                new Square(2,3),
                new Square(5,3)
            };

            CollectionAssert.Contains(expected, target);
        }

        [TestMethod]
        public void NextTargetIsSquare2x3OrSquare5x3AfterSquares4x3And3x3AreHit()
        {
            var grid = new EnemyGrid(10, 10);

            var squaresAlreadyHit = new List<Square>
            {
                new Square(4,3),
                new Square(3,3)

            };
            var inline = new InlineShooting(grid, squaresAlreadyHit, 5);
            var target = inline.NextTarget();

            var expected = new List<Square>
            {
                new Square(2,3),
                new Square(5,3)
            };

            CollectionAssert.Contains(expected, target);
        }

        [TestMethod]
        public void NextTargetIsSquare4x2OrSquare4x7AfterSquares4x4And4x5And4x6And4x3AreHit()
        {
            var grid = new EnemyGrid(10, 10);

            var squaresAlreadyHit = new List<Square>
            {
                new Square(4,4),
                new Square(4,5),
                new Square(4,6),
                new Square(4,3)

            };
            var inline = new InlineShooting(grid, squaresAlreadyHit, 5);
            var target = inline.NextTarget();

            var expected = new List<Square>
            {
                new Square(4,2),
                new Square(4,7)
            };

            CollectionAssert.Contains(expected, target);
        }
    }
}
