using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vsite.Battleship.Model
{
    public class SortedSquares : List<Square>
    {
        public SortedSquares()
        {
        }

        public SortedSquares(IEnumerable<Square> collection) : base(collection)
        {
            SortSquares();
        }

        public new void Add(Square square)
        {
            base.Add(square);
            SortSquares();
        }

        private void SortSquares()
        {
            Sort((sq1, sq2) => sq1.Column + sq1.Row - (sq2.Column + sq2.Row));
        }
    }
}
