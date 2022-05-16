using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Vsite.Battleship.Model;

namespace Vsite.Battleship
{
    [TestClass]
    public class TestSortedSquares
    {
        [TestMethod]
        public void ConstructorCreatesCollectionOfSquaresSortedByColumnForHorizontallyPLacedSquares()
        {
            SortedSquares coll = new SortedSquares(new Square[]{ new Square(3, 4), new Square(3, 3), new Square(3, 5)});
            Assert.AreEqual(3, coll.Count);
            Assert.AreEqual(new Square(3, 3), coll[0]);
            Assert.AreEqual(new Square(3, 4), coll[1]);
            Assert.AreEqual(new Square(3, 5), coll[2]);
        }

        [TestMethod]
        public void ConstructorCreatesCollectionOfSquaresSortedByRowForVerticallyPLacedSquares()
        {
            SortedSquares coll = new SortedSquares(new Square[] { new Square(4, 4), new Square(5, 4), new Square(3, 4) });
            Assert.AreEqual(3, coll.Count);
            Assert.AreEqual(new Square(3, 4), coll[0]);
            Assert.AreEqual(new Square(4, 4), coll[1]);
            Assert.AreEqual(new Square(5, 4), coll[2]);
        }

        [TestMethod]
        public void AfterAddMethodIsInvokedSquaresAreSortedByColumnsHorizontally()
        {
            SortedSquares coll = new SortedSquares(new Square[]{ new Square(3, 4), new Square(3, 5) });
            Assert.AreEqual(2, coll.Count);
            coll.Add(new Square(3, 3));
            Assert.AreEqual(new Square(3, 3), coll[0]);
            Assert.AreEqual(new Square(3, 4), coll[1]);
            Assert.AreEqual(new Square(3, 5), coll[2]);
        }

        [TestMethod]
        public void AfterAddMethodIsInvokedSquaresAreSortedByRowsVertically()
        {
            SortedSquares coll = new SortedSquares(new Square[] { new Square(4, 4), new Square(3, 4) });
            Assert.AreEqual(2, coll.Count);
            coll.Add(new Square(5, 4));
            Assert.AreEqual(new Square(3, 4), coll[0]);
            Assert.AreEqual(new Square(4, 4), coll[1]);
            Assert.AreEqual(new Square(5, 4), coll[2]);
        }
    }
}
