using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Vsite.BattleShip
{
    [TestClass]
    public class TestSquare
    {
        [TestMethod]
        public void ConstructorCreatesSquareWithGivenCoodinates()
        {
            Square s = new Square(1, 5);
            Assert.AreEqual(1, s.row);
            Assert.AreEqual(5, s.col);
        }
    }
}
