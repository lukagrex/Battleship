using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using Vsite.Battleship.Model;

namespace Vsite.Battleship
{
    [TestClass]
    public class RandomShootingTest
    {
        [TestMethod]
        public void RandomShootingSelectsOneOfSquaresFromEmptyGrid()
        {
            var grid = new Grid(10, 10);
            var randomShooting = new RandomShooting(grid, 3);

            var nextTarget = randomShooting.NextTarget();

            Assert.IsTrue(grid.Squares.Contains(nextTarget));
        }
    }
}
