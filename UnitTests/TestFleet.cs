using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
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
            Fleet fleet = new Fleet();
            fleet.CreateShip(new List<Square> { new Square(1, 1), new Square(1, 2), new Square(1, 3) });
            Assert.AreEqual(1, fleet.Ships.Count());
            fleet.CreateShip(new List<Square> { new Square(3, 2), new Square(4, 2), new Square(5, 2) });
            Assert.AreEqual(2, fleet.Ships.Count());
        }
    }
}
