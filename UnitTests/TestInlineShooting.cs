using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Vsite.Battleship.Model;

namespace Vsite.Battleship
{
    [TestClass]
    public class TestInlineShooting
    {
        [TestMethod]
        public void NextTargetIsSquare2_3orSquare5_3AfterSquares3_3And4_3AreHit()
        {
            var grid = new EnemyGrid(10, 10);
            int shipLength = 5;
            var inline = new InlineShooting(grid, new List<Square> { new Square(3, 3), new Square(4, 3) }, shipLength);
            var next = inline.NextTarget();
            var candidates = new List<Square> { new Square(2, 3), new Square(5, 3) };
            CollectionAssert.Contains(candidates, next);
        }

        [TestMethod]
        public void NextTargetIsSquare2_3orSquare5_3AfterSquares4_3And3_3AreHit()
        {
            var grid = new EnemyGrid(10, 10);
            int shipLength = 5;
            var inline = new InlineShooting(grid, new List<Square> { new Square(4, 3), new Square(3, 3) }, shipLength);
            var next = inline.NextTarget();
            var candidates = new List<Square> { new Square(2, 3), new Square(5, 3) };
            CollectionAssert.Contains(candidates, next);
        }

        [TestMethod]
        public void NextTargetIsSquare4_2orSquare4_7AfterSquares4_4__4_5__4_6And4_3AreHit()
        {
            var grid = new EnemyGrid(10, 10);
            int shipLength = 5;
            var inline = new InlineShooting(grid, new List<Square> { new Square(4, 4), new Square(4, 5), new Square(4, 6), new Square(4, 3) }, shipLength);
            var next = inline.NextTarget();
            var candidates = new List<Square> { new Square(4, 2), new Square(4, 7) };
            CollectionAssert.Contains(candidates, next);
        }

    }
}
