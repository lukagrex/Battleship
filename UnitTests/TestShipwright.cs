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

            Assert.AreEqual(10, fleet.Ships.Count());
            Assert.AreEqual(1, fleet.Ships.Count(s => s.Squares.Count() == 5));
        }

        [TestMethod]
        public void CreateFleet_CreatesFleetFor9ShipLengthsProvided()
        {
            IEnumerable<int> shipLengths = new List<int>
            {
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

            Assert.AreEqual(9, fleet.Ships.Count());
            Assert.AreEqual(2, fleet.Ships.Count(s => s.Squares.Count() == 4));
        }

        [TestMethod]
        public void CreateFleet_CreatesFleetFor7ShipLengthsProvided()
        {
            IEnumerable<int> shipLengths = new List<int>
            {
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

            Assert.AreEqual(7, fleet.Ships.Count());
            Assert.AreEqual(3, fleet.Ships.Count(s => s.Squares.Count() == 3));
        }

        [TestMethod]
        public void CreateFleet_CreatesFleetFor4ShipLengthsProvided()
        {
            IEnumerable<int> shipLengths = new List<int>
            {
                2,
                2,
                2,
                2
            };

            var shipwright = new Shipwright(10, 10, shipLengths);

            var fleet = shipwright.CreateFleet();

            Assert.AreEqual(4, fleet.Ships.Count());
            Assert.AreEqual(4, fleet.Ships.Count(s => s.Squares.Count() == 2));
        }
    }
}
