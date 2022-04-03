using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using Vsite.Battleship.Model;

namespace Vsite.Battleship
{
    [TestClass]
    public class TestSquareEliminator
    {
        [TestMethod]
        public void ToEliminateReturns18SquaresForShipInSquares4x3_4x6()
        {
            var eliminator = new SquareEliminator(10, 10);
            var toEliminate = eliminator.ToEliminate(new List<Square> { new Square(4, 3), new Square(4, 4), new Square(4, 5), new Square(4, 6) });
            Assert.AreEqual(18, toEliminate.Count());
        }

        [TestMethod]
        public void ToElimnateReturns6SqaresForShipInSquares9x0_9x1()
        {
            var eliminator = new SquareEliminator(10, 10);
            var toEliminate = eliminator.ToEliminate(new List<Square> { new Square(9, 0), new Square(9, 1) });
            Assert.AreEqual(6, toEliminate.Count());
        }

        [TestMethod]
        public void ToElimnateReturns6SqaresForShipInSquares8x0_9x0()
        {
            var eliminator = new SquareEliminator(10, 10);
            var toEliminate = eliminator.ToEliminate(new List<Square> { new Square(8, 0), new Square(9, 0) });
            Assert.AreEqual(6, toEliminate.Count());
        }
    }
}
