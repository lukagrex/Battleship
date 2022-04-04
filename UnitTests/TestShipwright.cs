using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Collections.Generic;
using Vsite.Battleship.Model;

namespace Vsite.Battleship
{
    [TestClass]
    public class TestShipwright
    {
        [TestMethod]
        public void CreateFleetCreatesFleetForShipLengthsProvided()
        {
            IEnumerable<int> shipLength = new List<int>() { 5, 4, 4, 3, 3, 3, 2, 2, 2, 2 };
            var shipWright = new Shipwright(10, 10, shipLength);
            var fleet = shipWright.CreateFleet();
            Assert.AreEqual(fleet.Ships.Count(), 10);
            Assert.AreEqual(fleet.Ships.Count(s => s.Squares.Count() == 5), 1);
        }
    }
}
