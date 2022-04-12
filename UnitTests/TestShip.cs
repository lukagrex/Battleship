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

        [TestMethod]
        public void ShootReturnsMissedIfTargetSquareIsNotInShip()
        {
            var ship = new Ship(new List<Square>
            {
                new Square(1, 1),
                new Square(1, 2),
                new Square(1, 3)
            });

            var hitResult = ship.Shoot(3, 2);
            Assert.AreEqual(HitResult.Missed, hitResult);
        }

        [TestMethod]
        public void ShootReturnsHitIfTargetSquareIsInShip()
        {
            var ship = new Ship(new List<Square>
            {
                new Square(1, 1),
                new Square(1, 2),
                new Square(1, 3)
            });

            var hitResult = ship.Shoot(1, 2);
            Assert.AreEqual(HitResult.Hit, hitResult);
        }

        [TestMethod]
        public void ShootReturnsSunkenIfTargetSquaresAreInShip()
        {
            var ship = new Ship(new List<Square>
            {
                new Square(1, 1),
                new Square(1, 2),
                new Square(1, 3)
            });

            var hitResult = ship.Shoot(1, 1);
            Assert.AreEqual(HitResult.Hit, hitResult);
            hitResult = ship.Shoot(1, 2);
            Assert.AreEqual(HitResult.Hit, hitResult);
            hitResult = ship.Shoot(1, 3);
            Assert.AreEqual(HitResult.Sunken, hitResult);
        }

        [TestMethod]
        public void ShootReturnsHitWhenHittingSameSquareWhichIsAlreadyHit()
        {
            var ship = new Ship(new List<Square>
            {
                new Square(1, 1),
                new Square(1, 2),
                new Square(1, 3)
            });

            var hitResult = ship.Shoot(1, 1);
            Assert.AreEqual(HitResult.Hit, hitResult);
            hitResult = ship.Shoot(1, 1);
            Assert.AreEqual(HitResult.Hit, hitResult);
        }

        [TestMethod]
        public void ShootReturnsSunkenWhenHittingAgainSunkenShip()
        {
            var ship = new Ship(new List<Square>
            {
                new Square(1, 1),
                new Square(1, 2),
                new Square(1, 3)
            });

            var hitResult = ship.Shoot(1, 1);
            Assert.AreEqual(HitResult.Hit, hitResult);
            hitResult = ship.Shoot(1, 2);
            Assert.AreEqual(HitResult.Hit, hitResult);
            hitResult = ship.Shoot(1, 3);
            Assert.AreEqual(HitResult.Sunken, hitResult);
            hitResult = ship.Shoot(1, 1);
            Assert.AreEqual(HitResult.Sunken, hitResult);
        }

        [TestMethod]
        public void ShootReturnsMissedWhenMissingSunkenShip()
        {
            var ship = new Ship(new List<Square>
            {
                new Square(1, 1),
                new Square(1, 2),
                new Square(1, 3)
            });

            var hitResult = ship.Shoot(1, 1);
            Assert.AreEqual(HitResult.Hit, hitResult);
            hitResult = ship.Shoot(1, 2);
            Assert.AreEqual(HitResult.Hit, hitResult);
            hitResult = ship.Shoot(1, 3);
            Assert.AreEqual(HitResult.Sunken, hitResult);
            hitResult = ship.Shoot(3, 1);
            Assert.AreEqual(HitResult.Missed, hitResult);
        }
    }
}
