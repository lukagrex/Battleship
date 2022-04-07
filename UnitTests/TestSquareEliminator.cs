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

            CollectionAssert.Contains(toEliminate.ToArray(), new Square(3, 2));
            CollectionAssert.Contains(toEliminate.ToArray(), new Square(5, 2));
            CollectionAssert.Contains(toEliminate.ToArray(), new Square(3, 7));
            CollectionAssert.Contains(toEliminate.ToArray(), new Square(5, 7));
        }

        [TestMethod]
        public void ToEliminateReturns8SquaresForShipInSquares0x3_0x4()
        {
            var eliminator = new SquareEliminator(10, 10);
            var toEliminate = eliminator.ToEliminate(new List<Square>
                {new Square(0, 3), new Square(0, 4)});
            Assert.AreEqual(8, toEliminate.Count());

            CollectionAssert.Contains(toEliminate.ToArray(), new Square(0, 2));
            CollectionAssert.Contains(toEliminate.ToArray(), new Square(1, 2));
            CollectionAssert.Contains(toEliminate.ToArray(), new Square(0, 5));
            CollectionAssert.Contains(toEliminate.ToArray(), new Square(1, 5));
        }

        [TestMethod]
        public void ToEliminateReturns12SquaresForShipInSquares7x5_9x5()
        {
            var eliminator = new SquareEliminator(10, 10);
            var toEliminate = eliminator.ToEliminate(new List<Square>
                {new Square(7, 5), new Square(8, 5), new Square(9, 5)});
            Assert.AreEqual(12, toEliminate.Count());

            CollectionAssert.Contains(toEliminate.ToArray(), new Square(6, 4));
            CollectionAssert.Contains(toEliminate.ToArray(), new Square(9, 4));
            CollectionAssert.Contains(toEliminate.ToArray(), new Square(6, 6));
            CollectionAssert.Contains(toEliminate.ToArray(), new Square(9, 6));
        }

        [TestMethod]
        public void ToEliminateReturns37SquaresForShipsInSquares5x0_5x1and0x3_0x4and3x9_4x9and7x5_9x5()
        {
            var eliminator = new SquareEliminator(10, 10);
            var toEliminate = eliminator.ToEliminate(new List<Square>
                {new Square(5, 0), new Square(5, 1),
                    new Square(0, 3), new Square(0, 4),
                    new Square(3, 9), new Square(4, 9),
                    new Square(7, 5), new Square(8, 5), new Square(9, 5)
                });
            Assert.AreEqual(37, toEliminate.Count());

            CollectionAssert.Contains(toEliminate.ToArray(), new Square(4, 0));
            CollectionAssert.Contains(toEliminate.ToArray(), new Square(6, 2));
            CollectionAssert.Contains(toEliminate.ToArray(), new Square(0, 2));
            CollectionAssert.Contains(toEliminate.ToArray(), new Square(1, 5));
            CollectionAssert.Contains(toEliminate.ToArray(), new Square(2, 8));
            CollectionAssert.Contains(toEliminate.ToArray(), new Square(5, 9));
            CollectionAssert.Contains(toEliminate.ToArray(), new Square(6, 4));
            CollectionAssert.Contains(toEliminate.ToArray(), new Square(9, 6));
        }

        [TestMethod]
        public void ToEliminateReturns12SquaresForShipsInSquares0x0_0x1and8x9_9x9()
        {
            var eliminator = new SquareEliminator(10, 10);
            var toEliminate = eliminator.ToEliminate(new List<Square>
                {new Square(0, 0), new Square(0, 1),
                    new Square(8, 9), new Square(9, 9)
                });
            Assert.AreEqual(12, toEliminate.Count());

            CollectionAssert.Contains(toEliminate.ToArray(), new Square(0, 0));
            CollectionAssert.Contains(toEliminate.ToArray(), new Square(1, 0));
            CollectionAssert.Contains(toEliminate.ToArray(), new Square(0, 2));
            CollectionAssert.Contains(toEliminate.ToArray(), new Square(1, 2));
            CollectionAssert.Contains(toEliminate.ToArray(), new Square(7, 8));
            CollectionAssert.Contains(toEliminate.ToArray(), new Square(7, 9));
            CollectionAssert.Contains(toEliminate.ToArray(), new Square(9, 8));
            CollectionAssert.Contains(toEliminate.ToArray(), new Square(9, 9));
        }
    }
}
