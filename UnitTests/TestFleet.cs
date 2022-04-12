using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using Vsite.Battleship.Model;

namespace Vsite.Battleship
{
    [TestClass]
    public class TestFleet
    {
        [TestMethod]
        public void CreateShipAddsNewShipToFleet()
        {
            var fleet = new Fleet();

            fleet.CreateShip(new List<Square>
            {
                new Square(1, 1),
                new Square(1, 2),
                new Square(1, 3)
            });

            Assert.AreEqual(1, fleet.Ships.Count());


            fleet.CreateShip(new List<Square>
            {
                new Square(1, 8),
                new Square(2, 8),
                new Square(3, 8)
            });

            Assert.AreEqual(2, fleet.Ships.Count());
        }

        [TestMethod]
        public void HittingShipInAFleetReturnsHit()
        {
            var fleet = new Fleet();

            fleet.CreateShip(new List<Square>
            {
                new Square(1, 1),
                new Square(1, 2),
                new Square(1, 3)
            });

            fleet.CreateShip(new List<Square>
            {
                new Square(1, 8),
                new Square(2, 8),
                new Square(3, 8)
            });

            var hitResult = fleet.Shoot(1, 2);

            Assert.AreEqual(HitResult.Hit, hitResult);

            hitResult = fleet.Shoot(2, 8);

            Assert.AreEqual(HitResult.Hit, hitResult);

            hitResult = fleet.Shoot(3, 8);

            Assert.AreEqual(HitResult.Hit, hitResult);
        }

        [TestMethod]
        public void SunkenShipInAFleetReturnsSunken()
        {
            var fleet = new Fleet();

            fleet.CreateShip(new List<Square>
            {
                new Square(1, 1),
                new Square(1, 2),
                new Square(1, 3)
            });

            fleet.CreateShip(new List<Square>
            {
                new Square(1, 8),
                new Square(2, 8),
                new Square(3, 8)
            });

            var hitResult = fleet.Shoot(1, 8);

            Assert.AreEqual(HitResult.Hit, hitResult);

            hitResult = fleet.Shoot(2, 8);

            Assert.AreEqual(HitResult.Hit, hitResult);

            hitResult = fleet.Shoot(3, 8);

            Assert.AreEqual(HitResult.Sunken, hitResult);
        }

        [TestMethod]
        public void SunkenAllShipsInAFleetReturnsSunken()
        {
            var fleet = new Fleet();

            fleet.CreateShip(new List<Square>
            {
                new Square(1, 1),
                new Square(1, 2),
                new Square(1, 3)
            });

            fleet.CreateShip(new List<Square>
            {
                new Square(1, 8),
                new Square(2, 8),
                new Square(3, 8)
            });

            //Sunken second ship

            var hitResult = fleet.Shoot(1, 8);

            Assert.AreEqual(HitResult.Hit, hitResult);

            hitResult = fleet.Shoot(2, 8);

            Assert.AreEqual(HitResult.Hit, hitResult);

            hitResult = fleet.Shoot(3, 8);

            Assert.AreEqual(HitResult.Sunken, hitResult);

            //Sunken first ship

            hitResult = fleet.Shoot(1, 1);

            Assert.AreEqual(HitResult.Hit, hitResult);

            hitResult = fleet.Shoot(1, 2);

            Assert.AreEqual(HitResult.Hit, hitResult);

            hitResult = fleet.Shoot(1, 3);

            Assert.AreEqual(HitResult.Sunken, hitResult);
        }

        [TestMethod]
        public void MissingShipInAFleetReturnsMissed()
        {
            var fleet = new Fleet();

            fleet.CreateShip(new List<Square>
            {
                new Square(1, 1),
                new Square(1, 2),
                new Square(1, 3)
            });

            fleet.CreateShip(new List<Square>
            {
                new Square(1, 8),
                new Square(2, 8),
                new Square(3, 8)
            });

            var hitResult = fleet.Shoot(8, 8);

            Assert.AreEqual(HitResult.Missed, hitResult);
        }
    }
}
