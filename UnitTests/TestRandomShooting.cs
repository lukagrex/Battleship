using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Vsite.BattleShip.Model;

namespace Vsite.BattleShip.UnitTests
{
    [TestClass]
    public class TestRandomShooting
    {
        [TestMethod]
        public void RandomShootingSelectsOneOfSquaresFromEmptyGrid()
        {
            var grid = new Grid(10, 10);
            int shipLength = 3;

            var random = new RandomShooting(grid, shipLength);
            var next = random.NextTarget();
            CollectionAssert.Contains(grid.Squares.ToArray(), next);
        }
    }
}
