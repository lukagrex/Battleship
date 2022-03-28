﻿using System.Collections.Generic;

namespace Vsite.BattleShip
{
    [TestClass]
    public class TestSquareEliminator
    {
        [TestMethod]
        public void ToEliminateReturns18SquaresForShipInSquares4x3_4x6()
        {
            var eliminator = new SquareEliminator(10, 10);
            eliminator.ToEliminate(new List<Square>()
            {
                new Square(4, 3), new Square(4, 4), new Square(4, 5), new Square(4, 6)
            });
            Assert.AreEqual(18, ToEliminate.Count());
        }
    }
}
