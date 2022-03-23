using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vsite.Battleship.Model;

namespace Vsite.Battleship
{
    [TestClass]
    public class TestSquare
    {
        [TestMethod]
        public void ConstructorCreatesSquareWithGivenCoordinates()
        {
            Square s = new Square(1, 5);
            Assert.AreEqual(1, s.Row);
            Assert.AreEqual(5, s.Column);
        }
    }
}
