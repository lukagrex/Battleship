using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;

namespace UnitTests
{
    [TestClass]
    public class TestSquare
    {
        [TestMethod]
        public void ConstructorCreatesSquareWithGivenCoordinates()
        {
            var square = new Square(1, 5);

            Assert.AreEqual(1, square.Row);
            Assert.AreEqual(5, square.Column);
        }
    }
}
