using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;

namespace UnitTests
{
    [TestClass]
    public class TestShip
    {

        [TestMethod]
        public void ConstructorCreatesShipWithSquaresProvided()
        {
            var ship = new Ship(new List<Square>{new Square(1,1),new Square(1,2), new Square(1,3)});
            Assert.AreEqual(3, ship.Squares.Count());
            CollectionAssert.Contains(ship.Squares.ToArray(), new Square(1, 1));
            CollectionAssert.Contains(ship.Squares.ToArray(), new Square(1, 2));
            CollectionAssert.Contains(ship.Squares.ToArray(), new Square(1, 3));
        }

        //TODO popraviti testove

        [TestMethod]
        public void Shoot_ReturnsMissedIfTargetIsNotShip()
        {
            var ship = new Ship(new List<Square> { new Square(1, 1), new Square(1, 2), new Square(1, 3) });

            var result = ship.Shoot(2, 5);

            Assert.AreEqual(HitResult.Missed, result);
        }

        [TestMethod]
        public void Shoot_ReturnsHitIfTargetIsNotShip()
        {
            var ship = new Ship(new List<Square> { new Square(1, 1), new Square(1, 2), new Square(1, 3) });

            var result = ship.Shoot(1, 2);

            Assert.AreEqual(HitResult.Hit, result);
        }

        [TestMethod]
        public void Shoot_ReturnsHitForSecondAttemptIfTargetSquareIsInShip()
        {
            var ship = new Ship(new List<Square> { new Square(1, 1), new Square(1, 2), new Square(1, 3) });

            var result = ship.Shoot(1, 2);

            Assert.AreEqual(HitResult.Hit, result);

            result = ship.Shoot(1, 2);

            Assert.AreEqual(HitResult.Hit, result);
        }


        [TestMethod]
        public void Shoot_ReturnsSunkenForTheLastShipSquare()
        {
            var ship = new Ship(new List<Square> { new Square(1, 1), new Square(1, 2), new Square(1, 3) });

            var result = ship.Shoot(1, 2);

            Assert.AreEqual(HitResult.Hit, result);

            result = ship.Shoot(1, 3);

            Assert.AreEqual(HitResult.Hit, result);

            result = ship.Shoot(1, 1);

            Assert.AreEqual(HitResult.Sunken, result);
        }

        [TestMethod]
        public void Shoot_ReturnsSunkenForTheLastShipSquareIfIsHitAgain()
        {
            var ship = new Ship(new List<Square> { new Square(1, 1), new Square(1, 2), new Square(1, 3) });

            var result = ship.Shoot(1, 2);

            Assert.AreEqual(HitResult.Hit, result);

            result = ship.Shoot(1, 3);

            Assert.AreEqual(HitResult.Hit, result);

            result = ship.Shoot(1, 1);

            Assert.AreEqual(HitResult.Sunken, result);

            result = ship.Shoot(1, 3);

            Assert.AreEqual(HitResult.Sunken, result);
        }
    }
}
