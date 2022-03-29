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
            var toEliminate = eliminator.ToEliminate(new List<Square>
                {new Square(4, 3), new Square(4, 4), new Square(4, 5), new Square(4, 6)});
            Assert.AreEqual(18, toEliminate.Count());
        }

        [TestMethod]
        public void ToEliminateReturns12SquaresForShipInSquares1x3_1x6()
        {
            var eliminator = new SquareEliminator(10, 10);
            var toEliminate = eliminator.ToEliminate(new List<Square>
                {new Square(1, 3), new Square(1, 4), new Square(1, 5), new Square(1, 6)});
            Assert.AreEqual(12, toEliminate.Count());
        }

        [TestMethod]
        public void ToEliminateReturns6SquaresForShipInSquares10x9_10x10()
        {
            var eliminator = new SquareEliminator(10, 10);
            var toEliminate = eliminator.ToEliminate(new List<Square>
                {new Square(10, 9), new Square(10, 10)});
            Assert.AreEqual(6, toEliminate.Count());
        }
    }
}
