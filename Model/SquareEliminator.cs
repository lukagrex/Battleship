using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class SquareEliminator
    {
        private readonly int rows;
        private readonly int columns;

        public SquareEliminator(int rows, int columns)
        {
            this.rows = rows;
            this.columns = columns;
        }

        public IEnumerable<Square> ToEliminate(IEnumerable<Square> shipSquares)
        {
            throw new NotImplementedException();
        }
    }
}
