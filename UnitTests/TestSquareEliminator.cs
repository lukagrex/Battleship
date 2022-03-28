using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using Vsite.BattleShip.Model;

namespace Vsite.BattleShip.UnitTests
{
    [TestClass]
    public class TestSquareEliminator
    {
        [TestMethod]
        public void ToEliminateReturn18SquaresForShipIn4x3_4x6()
        {
            var eliminator = new SquareEliminator(10, 10);
            var toEliminate = eliminator.ToEliminate(new List<Square>
            {
                new Square(4, 4),
                new Square(4, 4),
                new Square(4, 5),
                new Square(4, 6)
            });

            Assert.AreEqual(18, toEliminate.Count());
        }
    }
}
