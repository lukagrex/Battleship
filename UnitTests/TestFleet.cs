using System.Collections.Generic;

namespace Vsite.BattleShip
{
    [TestClass]
    public class TestFleet
    {
        [TestMethod]
        public void CreateShipAndAddsNewShipToFleet()
        {
            Fleet fleet = new Fleet();
            fleet.CreateShip(new List<Square>(){
                new Square(1, 1), new Square(1, 2), new Square(1, 3)});
            Assert.AreEqual(1, fleet.Ships.Count);
        }
    }
}
}
