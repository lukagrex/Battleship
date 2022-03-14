using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using System;

namespace UnitTests
{
    [TestClass]
    public class TestSquare
    {
        [TestMethod]
        public void ConstructorCreateSquareWithGivenCoordinates()
        {
            Square s = new Square(1, 5);
            Assert.AreEqual(1, s.Row);
            Assert.AreEqual(5, s.Column);
        }
    }
}
