using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vsite.Battleship.Model
{
    public class EvidenceGrid : Grid
    {
        public EvidenceGrid(int rows, int columns) : base(rows, columns)
        {
        }

        public IEnumerable<Square> GetAvailableSquares()
        {
            throw new NotImplementedException();
            //return Squares; // consider using this line
        }

        public void RecordTheShooting()
        {
            throw new NotImplementedException();
        }
    }
}
