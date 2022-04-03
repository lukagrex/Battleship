using System;
using System.Collections.Generic;

namespace Vsite.Battleship.Model
{
    public class SquareEliminator
    {
        private readonly int rows;
        private readonly int columns;

        //public IEnumerable<Square> ToEliminate(IEnumerable<Square> shipSquares)
        //{
        //    HashSet<Square> eliminated = new HashSet<Square>();

        //    foreach (var square in shipSquares)
        //    {
        //        for (int i = Math.Max(square.Row - 1, 0); i <= Math.Min(square.Row + 1, rows - 1); ++i)
        //        {
        //            for (int j = Math.Max(square.Column - 1, 0); j <= Math.Min(square.Column + 1, columns - 1); ++j)
        //            {
        //                eliminated.Add(new Square(i, j));
        //            }
        //        }
        //    }
        //    return eliminated;
        //}

        public IEnumerable<Square> ToEliminate(IEnumerable<Square> shipSquares)
        {
            HashSet<Square> eliminated = new HashSet<Square>();

            foreach (var square in shipSquares)
            {
                int startPosX = Math.Max(square.Row - 1, 0);
                int startPosY = Math.Max(square.Column - 1, 0);
                int endPosX = Math.Min(square.Row + 1, rows - 1);
                int endPosY = Math.Min(square.Column + 1, columns - 1);


                for (int i = startPosX; i <= endPosX; ++i)
                {
                    for (int j = startPosY; j <= endPosY;  ++j)
                    {
                        eliminated.Add(new Square(i, j));
                    }
                }
            }
            return eliminated;
        }


        public SquareEliminator(int rows, int columns)
        {
            this.rows = rows;
            this.columns = columns;

        }
    }
}
