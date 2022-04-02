using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Vsite.Battleship.Model;
using System.Linq;

namespace Vsite.Battleship
{
    [TestClass]
    public class TestSquareEliminator
    {
        [TestMethod]
        public void ToElimnateReturns18SqaresForShipInSquares4x3_4x6()
        {
            var eliminator = new SquareEliminator(10, 10);
            var toEliminate = eliminator.ToEliminate(new List<Square>{new Square(4, 3), new Square(4, 4), new Square(4, 5), new Square(4, 6)});
            Assert.AreEqual(18, toEliminate.Count());
        }

        [TestMethod]
        public void ToElimnateReturns6SqaresForShipInSquares0x0_0x1()
        {
            var eliminator = new SquareEliminator(10, 10);
            var toEliminate = eliminator.ToEliminate(new List<Square> { new Square(0, 0), new Square(0, 1) });
            Assert.AreEqual(6, toEliminate.Count());
        }

        [TestMethod]
        public void ToElimnateReturns6SqaresForShipInSquares8x9_9x9()
        {
            var eliminator = new SquareEliminator(10, 10);
            var toEliminate = eliminator.ToEliminate(new List<Square> { new Square(8, 9), new Square(9, 9) });
            Assert.AreEqual(6, toEliminate.Count());
        }
    }
}
