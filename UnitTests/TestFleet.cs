using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Vsite.Battleship.Model;
using System.Linq;
using System.Collections.Generic;

namespace Vsite.Battleship
{
    [TestClass]
    public class TestFleet
    {
        [TestMethod]
        public void CreateShipAddsNewShipToFleet()
        {
            Fleet fleet = new Fleet();
            fleet.CreateShip(new List<Square> { new Square(1, 1), new Square(1, 2), new Square(1, 3) });
            Assert.AreEqual(1, fleet.Ships.Count());
            fleet.CreateShip(new List<Square> { new Square(1, 8), new Square(2, 8), new Square(3, 8) });
            Assert.AreEqual(2, fleet.Ships.Count());
        }
    }
}
