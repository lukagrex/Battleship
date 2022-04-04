using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vsite.Battleship.Model
{
    public class LimitedQueue <T> : Queue<T>
    // google in msdn pages for queue.enqueue method
    {
        public LimitedQueue(int length)
        {
            this.length = length;
        }

        public new void Enqueue(T item)
        {
            if (Count >= length)
            {
                Dequeue();  //Removes first element            }
            }
            base.Enqueue(item);
        }

        private readonly int length;
    }
}
