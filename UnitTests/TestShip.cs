using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using Vsite.BattleShip.Model;

namespace Vsite.BattleShip.UnitTests
{
    [TestClass]
    public class TestShip
    {
        [TestMethod]
        public void ConstructorCreatesShipWithSquaresProvided()
        {
            var ship = new Ship(new List<Square>
            {
                new Square(1, 1),
                new Square(1, 2),
                new Square(1, 3)
            });

            Assert.AreEqual(3, ship.Squares.Count());
            CollectionAssert.Contains(ship.Squares.ToArray(), new Square(1, 1));
            CollectionAssert.Contains(ship.Squares.ToArray(), new Square(1, 2));
            CollectionAssert.Contains(ship.Squares.ToArray(), new Square(1, 3));
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

            var result = ship.Shoot(2, 5);
            Assert.AreEqual(HitResult.Missed, result);

            // The State of this square is already Missed
            var result2 = ship.Shoot(2, 5);
            Assert.AreEqual(HitResult.Missed, result2);
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

            var result = ship.Shoot(1, 2);
            Assert.AreEqual(HitResult.Hit, result);

            // The state of this square is already Hit
            var result2 = ship.Shoot(1, 2);
            Assert.AreEqual(HitResult.Hit, result2);
        }

        [TestMethod]
        public void ShootReturnsSunkenIfTargetSquareIsInShip()
        {
            var ship = new Ship(new List<Square>
            {
                new Square(1, 1),
                new Square(1, 2),
                new Square(1, 3)
            });

            var result = ship.Shoot(1, 2);
            Assert.AreEqual(HitResult.Hit, result);

            var result1 = ship.Shoot(1, 1);
            Assert.AreEqual(HitResult.Hit, result1);

            var result2 = ship.Shoot(1, 3);
            Assert.AreEqual(HitResult.Sunken, result2);

            // The state of this square is already Sunken
            var result3 = ship.Shoot(1, 2);
            Assert.AreEqual(HitResult.Sunken, result3);
        }
    }
}
