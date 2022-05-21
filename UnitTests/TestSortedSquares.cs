using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vsite.Battleship.Model;

namespace Vsite.Battleship
{
    [TestClass]
    public class TestSortedSquares
    {
        [TestMethod]
        public void ConstructorCreatesCollectionOfSquaresSortedByColumnForHorizontallyPlacedSquares()
        {
            var sortedSquares = new SortedSquares(new Square[]{
                new Square(3, 4),
                new Square(3, 2),
                new Square(3, 3),
                new Square(3, 5),
            });

            Assert.AreEqual(new Square(3, 2), sortedSquares[0]);
            Assert.AreEqual(new Square(3, 3), sortedSquares[1]);
            Assert.AreEqual(new Square(3, 4), sortedSquares[2]);
            Assert.AreEqual(new Square(3, 5), sortedSquares[3]);
        }

        [TestMethod]
        public void ConstructorCreatesCollectionOfSquaresSortedByRowForVerticallyPlacedSquares()
        {
            var sortedSquares = new SortedSquares(new Square[]
            {
                new Square(4, 1),
                new Square(2, 1),
                new Square(3, 1),
                new Square(5, 1),
            });

            Assert.AreEqual(new Square(2, 1), sortedSquares[0]);
            Assert.AreEqual(new Square(3, 1), sortedSquares[1]);
            Assert.AreEqual(new Square(4, 1), sortedSquares[2]);
            Assert.AreEqual(new Square(5, 1), sortedSquares[3]);
        }


        [TestMethod]
        public void AddSquaresToSquaresSortedByColumnForHorizontallyPlacedSquares()
        {
            var sortedSquares = new SortedSquares()
            {
                new Square(3, 4),
                new Square(3, 2),
                new Square(3, 3),
                new Square(3, 5),
            };

            Assert.AreEqual(new Square(3, 2), sortedSquares[0]);
            Assert.AreEqual(new Square(3, 3), sortedSquares[1]);
            Assert.AreEqual(new Square(3, 4), sortedSquares[2]);
            Assert.AreEqual(new Square(3, 5), sortedSquares[3]);
        }

        [TestMethod]
        public void AddSquaresToSquaresSortedByRowForVerticallyPlacedSquares()
        {
            var sortedSquares = new SortedSquares()
            {
                new Square(4, 1),
                new Square(2, 1),
                new Square(3, 1),
                new Square(5, 1),
            };

            Assert.AreEqual(new Square(2, 1), sortedSquares[0]);
            Assert.AreEqual(new Square(3, 1), sortedSquares[1]);
            Assert.AreEqual(new Square(4, 1), sortedSquares[2]);
            Assert.AreEqual(new Square(5, 1), sortedSquares[3]);
        }
    }
}
