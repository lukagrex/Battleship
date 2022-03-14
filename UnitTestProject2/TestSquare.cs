using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;

namespace UnitTestProject2
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
