using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using Vsite.Battleship.Model;

namespace Vsite.Battleship
{
    [TestClass]
    public class TestShip
    {
        [TestMethod]
        public void ConstructoCreatesShipWithSquaresProvided()
        {
            var ship = new Ship(new List<Square>
            {
                new Square(1, 1),
                new Square(1, 2),
                new Square(1, 3)
            });

            Assert.AreEqual(3, ship.Squares.Count());
            CollectionAssert.Contains(ship.Squares.ToList(), new Square(1, 1));
            CollectionAssert.Contains(ship.Squares.ToList(), new Square(1, 2));
            CollectionAssert.Contains(ship.Squares.ToList(), new Square(1, 3));
        }

        [TestMethod]
        public void ConstructoDoesNotCreatesShipWithSquaresWhichAreNotProvided()
        {
            var ship = new Ship(new List<Square>
            {
                new Square(1, 1),
                new Square(1, 2),
                new Square(1, 3)
            });

            Assert.AreEqual(3, ship.Squares.Count());
            Assert.IsFalse(ship.Squares.Contains(new Square(2, 1)));
            Assert.IsFalse(ship.Squares.Contains(new Square(3, 1)));
            Assert.IsFalse(ship.Squares.Contains(new Square(2, 2)));

        }
    }
}