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
        public void ConstructorCreatesShipWithSquareProvided()
        {
            var ship = new Ship(new List<Square> { new Square(1, 1), new Square(1, 2), new Square(1, 3) });
            Assert.AreEqual(3, ship.Squares.Count());
            CollectionAssert.Contains(ship.Squares.ToArray(), new Square(1, 1));
            CollectionAssert.Contains(ship.Squares.ToArray(), new Square(1, 2));
            CollectionAssert.Contains(ship.Squares.ToArray(), new Square(1, 3));
        }

        [TestMethod]
        public void ShouldReturnsMissedIfTargetSquareIsNotInSheep()
        {
            var ship = new Ship(new List<Square> { new Square(1, 1), new Square(1, 2), new Square(1, 3) });
            var result = ship.Shoot(2, 5);
            Assert.AreEqual(HitResult.Missed, result);
        
        }

        [TestMethod]
        public void ShootReturnsHitIfTargetSquareIsNotInSheep()
        {
            var ship = new Ship(new List<Square> { new Square(1, 1), new Square(1, 2), new Square(1, 3) });
            var result = ship.Shoot(2, 5);
            Assert.AreEqual(HitResult.Hit, result);

        }
        [TestMethod]
        public void ShootReturnsHitForSeccondAttemptIfTargetSquareIsNotInSheep()
        {
            var ship = new Ship(new List<Square> { new Square(1, 1), new Square(1, 2), new Square(1, 3) });
            var result = ship.Shoot(2, 5);
            Assert.AreEqual(HitResult.Hit, result);
            result = ship.Shoot(2, 5);
            Assert.AreEqual(HitResult.Hit, result);

        }
        
        [TestMethod]
        public void ShootReturnsSunkenForTheLastShipSquare()
        {
            var ship = new Ship(new List<Square> { new Square(1, 1), new Square(1, 2), new Square(1, 3) });
            var result = ship.Shoot(2, 2);
             result = ship.Shoot(2, 3);
             result = ship.Shoot(2, 4);
            Assert.AreEqual(HitResult.Hit, result);

        }
        //[TestMethod]
        //public void ShootReturnsSunkenForTheLastShipSquare()
        //{
        //    var ship = new Ship(new List<Square> { new Square(1, 1), new Square(1, 2), new Square(1, 3) });
        //    var result = ship.Shoot(2, 2);
        //     result = ship.Shoot(2, 3);
        //     result = ship.Shoot(2, 4);
        //    Assert.AreEqual(HitResult.Hit, result);

        //}
    }
}
