using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;

namespace UnitTests
{
    [TestClass]
    public class TestShipwright
    {
        [TestMethod]
        public void CreateFleet_CreatesFleetForShipLengthsProvided()
        {
            IEnumerable<int> shipLengths = new List<int>
            {
                5,
                4,
                4,
                3,
                3,
                3,
                2,
                2,
                2,
                2
            };
            var shipwright = new Shipwright(10, 10, shipLengths);

            var fleet = shipwright.CreateFleet();

            Assert.AreEqual(10, fleet.Ships);
            Assert.AreEqual(1, fleet.Ships.Count(s => s.Squares.Count() == 5));
        }

        ////TODO napraviti testove za dva broda duljine 4, 3 broda duljine 3...
    }
}
