using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vsite.Battleship.Model;
using System.Linq;

namespace Vsite.Battleship
{
    [TestClass]
    public class TestFleet
    {
        [TestMethod]
        public void CreateShipAddsNewShipToFleet()
        {
            Fleet fleet = new Fleet();

            fleet.CreateShip(new Square(1, 1), new Square(1, 2), new Square(1, 3));

        }
    }
}
