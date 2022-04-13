using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using Vsite.Battleship.Model;

namespace Vsite.Battleship
{
    [TestClass]
    public class TestShip
    {
        [TestMethod]
        public void CounstructorCreatesShipWithSquareProvided()
        {
            var ship = new Ship(new List<Square> {new Square(1, 1), new Square(1, 2), new Square(1, 3)});
            Assert.AreEqual(3, ship.Squares.Count());
            CollectionAssert.Contains(ship.Squares.ToArray(), new Square(1,1));
            CollectionAssert.Contains(ship.Squares.ToArray(), new Square(1,2));
            CollectionAssert.Contains(ship.Squares.ToArray(), new Square(1,3));
        }
        
        [TestMethod]
        public void ShootReturnsMissedIfTargetSquareIsNotInShip()
        {
            var ship = new Ship(new List<Square> {new Square(1, 1), new Square(1, 2), new Square(1, 3)});
            var result = ship.Shoot(2, 5);
            Assert.AreEqual(HitResult.Missed, result);
        }

        [TestMethod]
        public void ShootReturnsHitIfTargetSquareIsInShip()
        {
            var ship = new Ship(new List<Square> {new Square(1, 1), new Square(1, 2), new Square(1, 3)});
            var result = ship.Shoot(1, 2);
            Assert.AreEqual(HitResult.Hit, result);
        }

        [TestMethod]
        public void ShootReturnsHitForSecondAttemptIfTargetSquareIsInShip()
        {
            var ship = new Ship(new List<Square> {new Square(1, 1), new Square(1, 2), new Square(1, 3)});
            var result = ship.Shoot(1, 2);
            Assert.AreEqual(HitResult.Hit, result);
            result = ship.Shoot(1, 2);
            Assert.AreEqual(HitResult.Hit, result);
        }

        [TestMethod]
        public void ShootReturnsSunkenForTheLastShipSquare()
        {
            var ship = new Ship(new List<Square> {new Square(1, 1), new Square(1, 2), new Square(1, 3)});
            ship.Shoot(1, 2);
            ship.Shoot(1, 3);
            var result = ship.Shoot(1, 1);
            Assert.AreEqual(HitResult.Sunken, result);
        }

        [TestMethod]
        public void ShootReturnsSunkenForTheLastShipSquareIfItIsHitAgain()
        {
            var ship = new Ship(new List<Square> {new Square(1, 1), new Square(1, 2), new Square(1, 3)});
            ship.Shoot(1, 2);
            ship.Shoot(1, 3);
            ship.Shoot(1, 1);
            var result = ship.Shoot(1, 3);
            Assert.AreEqual(HitResult.Sunken, result);
        }
    }
}
