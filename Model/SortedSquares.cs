using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class SortedSquares : List<Square>
    {
        public SortedSquares() : base()
        {
        }

        public SortedSquares(IEnumerable<Square> collection) : base(collection)
        {
            this.SortSquares();
        }

        public new void Add(Square square)
        {
            base.Add(square);
            this.SortSquares();
        }

        private void SortSquares()
        {
            this.Sort((x, y) => x.Row - y.Row + x.Column - y.Column);
        }
    }
}
