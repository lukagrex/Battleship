using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using Vsite.Battleship.Model;

namespace Vsite.Battleship
{
    [TestClass]
    public class TestSquareEliminator
    {
        [TestMethod]
        public void ToEliminateReturn18SquaresShipInSquares4x3_4x6()
        {
            var eliminator = new SquareEliminator(10, 10);

            var toEliminate = eliminator.ToEliminate(new List<Square>
            {
                new Square(4, 3),
                new Square(4, 4),
                new Square(4, 5),
                new Square(4, 6)
            });

            Assert.AreEqual(18, toEliminate.Count());

            for (int i = 3; i <= 5; i++)
            {
                for (int j = 2; j <= 7; j++)
                {
                    Assert.IsTrue(toEliminate.Contains(new Square(i, j)));
                }
            }
        }

        [TestMethod]
        public void ToEliminateReturn31SquaresShipInSquares4x3_4x6AndSecondShip6x7_8x7()
        {
            var eliminator = new SquareEliminator(10, 10);

            var toEliminate = eliminator.ToEliminate(new List<Square>
            {
                new Square(4, 3),
                new Square(4, 4),
                new Square(4, 5),
                new Square(4, 6)
            });


            toEliminate = toEliminate.Concat(eliminator.ToEliminate(new List<Square>
            {
                new Square(6, 7),
                new Square(7, 7),
                new Square(8, 7)
            })).Distinct();

            Assert.AreEqual(31, toEliminate.Count());

            for (int i = 3; i <= 5; i++)
            {
                for (int j = 2; j <= 7; j++)
                {
                    Assert.IsTrue(toEliminate.Contains(new Square(i, j)));
                }
            }

            for (int i = 5; i <= 9; i++)
            {
                for (int j = 6; j <= 8; j++)
                {
                    Assert.IsTrue(toEliminate.Contains(new Square(i, j)));
                }
            }
        }

        [TestMethod]
        public void ToEliminateReturn8SquaresShipInSquares0x3_0x4()
        {
            var eliminator = new SquareEliminator(10, 10);

            var toEliminate = eliminator.ToEliminate(new List<Square>
            {
                new Square(0, 3),
                new Square(0, 4)
            });

            Assert.AreEqual(8, toEliminate.Count());

            for (int i = 0; i <= 1; i++)
            {
                for (int j = 2; j <= 5; j++)
                {
                    Assert.IsTrue(toEliminate.Contains(new Square(i, j)));
                }
            }
        }

        [TestMethod]
        public void ToEliminateReturn8SquaresShipInSquares3x9_4x9()
        {
            var eliminator = new SquareEliminator(10, 10);

            var toEliminate = eliminator.ToEliminate(new List<Square>
            {
                new Square(3, 9),
                new Square(4, 9)
            });

            Assert.AreEqual(8, toEliminate.Count());

            for (int i = 2; i <= 5; i++)
            {
                for (int j = 8; j <= 9; j++)
                {
                    Assert.IsTrue(toEliminate.Contains(new Square(i, j)));
                }
            }
        }

        [TestMethod]
        public void ToEliminateReturn12SquaresShipInSquares7x5_9x5()
        {
            var eliminator = new SquareEliminator(10, 10);

            var toEliminate = eliminator.ToEliminate(new List<Square>
            {
                new Square(7, 5),
                new Square(8, 5),
                new Square(9, 5)
            });

            Assert.AreEqual(12, toEliminate.Count());

            for (int i = 6; i <= 9; i++)
            {
                for (int j = 4; j <= 6; j++)
                {
                    Assert.IsTrue(toEliminate.Contains(new Square(i, j)));
                }
            }
        }

        [TestMethod]
        public void ToEliminateReturn9SquaresShipInSquares5x0_5x1()
        {
            var eliminator = new SquareEliminator(10, 10);

            var toEliminate = eliminator.ToEliminate(new List<Square>
            {
                new Square(5, 0),
                new Square(5, 1)
            });

            Assert.AreEqual(9, toEliminate.Count());

            for (int i = 4; i <= 6; i++)
            {
                for (int j = 0; j <= 2; j++)
                {
                    Assert.IsTrue(toEliminate.Contains(new Square(i, j)));
                }
            }
        }


        [TestMethod]
        public void ToEliminateReturn6SquaresShipInSquares0x0_0x1()
        {
            var eliminator = new SquareEliminator(10, 10);

            var toEliminate = eliminator.ToEliminate(new List<Square>
            {
                new Square(0, 0),
                new Square(0, 1)
            });

            Assert.AreEqual(6, toEliminate.Count());

            for (int i = 0; i <= 1; i++)
            {
                for (int j = 0; j <= 2; j++)
                {
                    Assert.IsTrue(toEliminate.Contains(new Square(i, j)));
                }
            }
        }

        [TestMethod]
        public void ToEliminateReturn6SquaresShipInSquares8x9_9x9()
        {
            var eliminator = new SquareEliminator(10, 10);

            var toEliminate = eliminator.ToEliminate(new List<Square>
            {
                new Square(8, 9),
                new Square(9, 9)
            });

            Assert.AreEqual(6, toEliminate.Count());

            for (int i = 7; i <= 9; i++)
            {
                for (int j = 8; j <= 9; j++)
                {
                    Assert.IsTrue(toEliminate.Contains(new Square(i, j)));
                }
            }
        }
    }
}