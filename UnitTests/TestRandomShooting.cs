using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using Model;

namespace UnitTests
{
    [TestClass]
    public class TestRandomShooting
    {
        [TestMethod]
        public void RandomShootingSelectsOneOfSquaresFromEmptyGrid()
        {
            var grid = new EnemyGrid(10, 10);
            int shipLength = 3;

            var random = new RandomShooting(grid, shipLength);

            var next = random.NextTarget();

            CollectionAssert.Contains(grid.Squares.ToList(), next);
        }
        //TODO završiti
    }
}
