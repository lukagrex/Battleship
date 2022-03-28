using System.Collections.Generic;

namespace Vsite.BattleShip
{
    [TestClass]
    public class TestShip
    {
        [TestMethod]
        public void ConstructorCreatesShipWithSquareProvided()
        {
            var ship = new Ship(new List<Square> { new Square(1, 1), new Square(1, 2), new Square(1, 3) });
            Assert.AreEqual(3, ship.Squares.Count());
            CollectionAssert.Contains(ship.Squares.ToArray(), new Square(1, 1));
            CollectionAssert.Contains(ship.Squares.ToArray(), new Square(1, 2));
            CollectionAssert.Contains(ship.Squares.ToArray(), new Square(1, 3));
        }
    }
}
