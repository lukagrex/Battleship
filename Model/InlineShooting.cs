using System;
using System.Collections.Generic;
using System.Linq;

namespace Vsite.Battleship.Model
{
    public class InlineShooting : INextTarget
    {

        private Grid grid;
        private List<Square> squaresAlreadyHit;

        public InlineShooting(Grid grid, List<Square> squaresAlreadyHit)
        {
            this.grid = grid;
            this.squaresAlreadyHit = squaresAlreadyHit;
        }

        public Square NextTarget()
        {
            var isHorizontal = squaresAlreadyHit.All(squares => squares.Row == squaresAlreadyHit.First().Row);
            var isVertical = squaresAlreadyHit.All(squares => squares.Column == squaresAlreadyHit.First().Column);
            if (isVertical)
            {
                squaresAlreadyHit.Sort((square, square1) => square.Row - square1.Row);
                if (grid.Squares.Contains(new Square(squaresAlreadyHit.First().Row - 1,
                        squaresAlreadyHit.First().Column)))
                {
                    return new Square(squaresAlreadyHit.First().Row - 1,
                        squaresAlreadyHit.First().Column);
                }else if (grid.Squares.Contains(new Square(squaresAlreadyHit.Last().Row + 1,
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
            else if(isHorizontal)
            {
                squaresAlreadyHit.Sort((square, square1) => square.Column - square1.Column);
                if (grid.Squares.Contains(new Square(squaresAlreadyHit.First().Row,
                        squaresAlreadyHit.First().Column - 1)))
                {
                    return new Square(squaresAlreadyHit.First().Row,
                        squaresAlreadyHit.First().Column - 1);
                }
                else if (grid.Squares.Contains(new Square(squaresAlreadyHit.Last().Row,
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