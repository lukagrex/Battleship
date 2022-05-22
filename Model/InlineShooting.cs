using System;
using System.Collections.Generic;
using System.Linq;

namespace Model
{
    public class InlineShooting : INextTarget
    {

        private EnemyGrid enemyGrid;
        private SortedSquares squaresAlreadyHit;

        public InlineShooting(EnemyGrid enemyGrid, SortedSquares squaresAlreadyHit)
        {
            this.enemyGrid = enemyGrid;
            this.squaresAlreadyHit = squaresAlreadyHit;
        }

        public Square NextTarget()
        {
            var isHorizontal = squaresAlreadyHit.All(squares => squares.Row == squaresAlreadyHit.First().Row);
            var isVertical = squaresAlreadyHit.All(squares => squares.Column == squaresAlreadyHit.First().Column);

            if (isVertical)
            {
                squaresAlreadyHit.Sort((square, square1) => square.Row - square1.Row);
                if (enemyGrid.Squares.Where(square => square.SquareState == SquareState.Initial)
                    .Contains(new Square(squaresAlreadyHit.First().Row - 1,
                        squaresAlreadyHit.First().Column)))
                {
                    return new Square(squaresAlreadyHit.First().Row - 1,
                        squaresAlreadyHit.First().Column);
                }
                else if (enemyGrid.Squares.Where(square => square.SquareState == SquareState.Initial)
                         .Contains(new Square(squaresAlreadyHit.Last().Row + 1,
                             squaresAlreadyHit.Last().Column)))
                {
                    return new Square(squaresAlreadyHit.Last().Row + 1,
                        squaresAlreadyHit.Last().Column);
                }
                else
                {
                    return null;
                }

            }
            else if (isHorizontal)
            {
                squaresAlreadyHit.Sort((square, square1) => square.Column - square1.Column);
                if (enemyGrid.Squares.Where(square => square.SquareState == SquareState.Initial)
                    .Contains(new Square(squaresAlreadyHit.First().Row,
                        squaresAlreadyHit.First().Column - 1)))
                {
                    return new Square(squaresAlreadyHit.First().Row,
                        squaresAlreadyHit.First().Column - 1);
                }
                else if (enemyGrid.Squares.Where(square => square.SquareState == SquareState.Initial)
                         .Contains(new Square(squaresAlreadyHit.Last().Row,
                             squaresAlreadyHit.Last().Column + 1)))
                {
                    return new Square(squaresAlreadyHit.Last().Row,
                        squaresAlreadyHit.Last().Column + 1);
                }
                else
                {
                    return null;
                }
            }

            return null;
        }
    }
}