using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Vsite.Battleship.Model;
using Vsite.BattleShip.Model;

namespace Vsite.BattleShip.UnitTests
{
    [TestClass]
    public class TestInlineShooting
    {
        [TestMethod]
        public void NexTargetIsSquare2_3orSquare5_3AfterSquares3_3and4_3AreHit()
        {
            var grid = new EnemyGrid(10, 10);
            var inLine = new InlineShooting(grid, new List<Square>() { new Square(3, 3), new Square(4, 3) }, 5);
            var target = inLine.NextTarget();
            var expected = new List<Square>() { new Square(2, 3), new Square(5, 3) };
            CollectionAssert.Contains(expected, target);
        }

        [TestMethod]
        public void NexTargetIsSquare2_3orSquare5_3AfterSquares4_3and3_3AreHit()
        {
            var grid = new EnemyGrid(10, 10);
            var inLine = new InlineShooting(grid, new List<Square>() { new Square(4, 3), new Square(3, 3) }, 5);
            var target = inLine.NextTarget();
            var expected = new List<Square>() { new Square(2, 3), new Square(5, 3) };
            CollectionAssert.Contains(expected, target);
        }

        [TestMethod]
        public void NexTargetIsSquare4_2orSquare4_7AfterSquares4_4and4_5and4_6and_4_3AreHit()
        {
            var grid = new EnemyGrid(10, 10);
            var inLine = new InlineShooting(grid, new List<Square>() { new Square(4, 4), new Square(4, 5), new Square(4, 6), new Square(4, 3) }, 5);
            var target = inLine.NextTarget();
            var expected = new List<Square>() { new Square(4, 2), new Square(4, 7) };
            CollectionAssert.Contains(expected, target);
        }
    }
}
