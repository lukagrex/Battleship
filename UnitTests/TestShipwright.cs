using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using Vsite.Battleship.Model;

namespace Vsite.Battleship
{
    [TestClass]
    public class TestShipwright
    {
        [TestMethod]
        public void CreateFleetCreatesFleetForShipLengthsProvided()
        {
            IEnumerable<int> shipLengths = new List<int> { 5, 4, 4, 3, 3, 3, 2, 2, 2, 2 };
            var shipwright = new Shipwright(10, 10, shipLengths);
            var fleet = shipwright.CreateFleet();
            Assert.AreEqual(10, fleet.Ships.Count());
            Assert.AreEqual(1,fleet.Ships.Count(s => s.Squares.Count() == 5)); 
        }
    }
}
